# curate.py - Curates and upserts IoT batch sensor data

from delta.tables import DeltaTable
import json
import traceback
from pyspark.sql import functions as F
from iot_functions import SensorFileHelper
from security import IOTSecurity
from logging import IOTLogger

def curate_data(input_json: str):
    """Handles the curation of IoT sensor data and upserts it into a Delta table."""
    
    # Parse input parameters
    params = json.loads(input_json)
    environment, file_type, run_id, batch_datetime = params['environment'], params['file_type'], params['run_id'], params['batch_datetime']
    
    # Define paths
    file_ext = 'hourly_measurements' if file_type == 'measurement' else "sensor_alerts"
    src_path = f'staging/iot/sensors/daily/curated/merged/{file_type}'
    tgt_path = f'sensors/monitoring/iot/{file_ext}'
    
    # Logging
    logger = IOTLogger(environment, f"Curate-{file_type}", run_id, batch_datetime, file_type)
    logger.info("Starting curation process...")
    
    try:
        # Set up security
        sec = IOTSecurity()
        src_sec, tgt_sec = sec.get_iot_sensor_vars(environment), sec.get_iot_public_vars(environment)
        sec.set_device_security_context(src_sec)
        sec.set_device_security_context(tgt_sec)

        # Initialize file helpers
        src_helper = SensorFileHelper(src_sec.container, src_sec.storage_account)
        tgt_helper = SensorFileHelper(tgt_sec.container, tgt_sec.storage_account)
        
        # Process data
        source_path = src_helper.get_full_target_path(src_path)
        target_path = tgt_helper.get_full_target_path(tgt_path)
        df = src_helper.read_source_data_delta(source_path)
        
        if src_helper.df_rdd_isEmpty(df):
            logger.info(f"No new records for {file_type}.")
            return {"status": "No new data"}
        
        df_transformed = df.drop("file_size", "FileName").cache()
        df_curated = tgt_helper.merge_cdc_delta(df_transformed, target_path, ["sensor_id"], logger)
        
        logger.info("Curation completed successfully.")
        return {"status": "Success", "records_updated": df_curated.count()}
    
    except Exception as e:
        error_msg = traceback.format_exc()
        logger.error(error_msg)
        raise Exception(error_msg)
    
    finally:
        logger.stop()
