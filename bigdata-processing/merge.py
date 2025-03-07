# merge.py - Merges raw IoT sensor data into a curated dataset

from delta.tables import DeltaTable
import json
import traceback
from pyspark.sql import functions as F
from iot_functions import SensorFileHelper
from security import IOTSecurity
from logging import IOTLogger

def merge_data(input_json: str):
    """Handles merging raw IoT sensor data into a curated dataset."""
    
    # Parse input parameters
    params = json.loads(input_json)
    environment, file_type, run_id, batch_datetime = params['environment'], params['file_type'], params['run_id'], params['batch_datetime']
    file_name_to_process, backfill = params['file_name_to_process'], params['backfill']
    
    # Define paths
    src_path = "inbound/iot/sensors/data/"
    tgt_path = f"staging/iot/sensors/daily/curated/merged/{file_type}"
    
    # Logging
    logger = IOTLogger(environment, f"Merge-{file_type}", run_id, batch_datetime, file_type)
    logger.info("Starting merge process...")
    
    try:
        # Set up security
        sec = IOTSecurity()
        sec_vars = sec.get_iot_sensor_vars(environment)
        sec.set_device_security_context(sec_vars)

        # Initialize file helpers
        file_helper = SensorFileHelper(sec_vars.container, sec_vars.storage_account)
        
        # Retrieve data
        source_path = file_helper.get_full_target_path(src_path)
        target_path = file_helper.get_full_target_path(tgt_path)
        
        if file_name_to_process != 'NONE':
            logger.info("Reprocessing a specific file")
            df_source = file_helper.read_source_data_csv(f"{source_path}/{file_name_to_process}")
        elif backfill == 'Y':
            logger.info("Processing backfill data")
            df_source = file_helper.read_source_data_delta(source_path)
        else:
            logger.info("Processing latest daily file")
            df_source = file_helper.read_source_data_delta(source_path)
        
        if file_helper.df_rdd_isEmpty(df_source):
            logger.info("No new records found.")
            return {"status": "No new data"}
        
        # Data transformation and deduplication
        df_deduped = df_source.drop("file_name", "file_size").distinct().cache()
        df_merged = file_helper.merge_data_with_partitions(df_deduped, target_path, ["sensor_id"], ["date_partition"])
        
        logger.info("Merge process completed successfully.")
        return {"status": "Success", "records_updated": df_merged.count()}
    
    except Exception as e:
        error_msg = traceback.format_exc()
        logger.error(error_msg)
        raise Exception(error_msg)
    
    finally:
        logger.stop()
