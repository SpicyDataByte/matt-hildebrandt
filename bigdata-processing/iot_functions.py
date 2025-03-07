# iot_functions.py - Helper functions for handling IoT sensor data

from delta.tables import DeltaTable
import pyspark.sql.functions as F
from pyspark.sql import DataFrame
from dataclasses import dataclass

@dataclass(frozen=True)
class SensorFileHelper:
    """Helper class for interacting with sensor data files."""
    container: str
    storage_acct: str

    def get_full_target_path(self, target_path: str) -> str:
        """Constructs the full path to a data file."""
        return f"abfss://{self.container}@{self.storage_acct}.dfs.core.windows.net/{target_path}"

    def df_rdd_isEmpty(self, df: DataFrame) -> bool:
        """Checks if a DataFrame is empty."""
        return df is None or df.rdd.isEmpty()

    def read_source_data_delta(self, source_path: str) -> DataFrame:
        """Reads sensor data from a Delta table."""
        return spark.read.format("delta").load(source_path)

    def read_source_data_csv(self, source_path: str) -> DataFrame:
        """Reads sensor data from a CSV file."""
        return spark.read.option("header", True).option('inferSchema', True).csv(source_path)

    def write_delta_file(self, df: DataFrame, target_path: str) -> None:
        """Writes a DataFrame to a Delta file."""
        df.write.format("delta").mode("overwrite").option('mergeSchema', 'true').save(target_path)
    
    def merge_data_with_partitions(self, df_raw: DataFrame, target_table_path: str, primary_keys: list, partition_cols: list) -> DataFrame:
        """Merges sensor data with partitioning."""
        df_with_hash = df_raw.withColumn("pk_hash", F.sha2(F.concat_ws("||", *primary_keys), 256))
        
        if DeltaTable.isDeltaTable(spark, target_table_path):
            delta_table = DeltaTable.forPath(spark, target_table_path)
            delta_table.alias("tgt")\
                .merge(df_with_hash.alias("src"), "tgt.pk_hash = src.pk_hash")\
                .whenMatchedUpdateAll()\
                .whenNotMatchedInsertAll()\
                .execute()
        else:
            df_with_hash.write.format("delta").mode("overwrite").partitionBy(*partition_cols).save(target_table_path)
        
        return self.read_source_data_delta(target_table_path)
    
    def merge_cdc_delta(self, df_raw: DataFrame, target_table_path: str, primary_keys: list, logger) -> DataFrame:
        """Merges sensor data using Change Data Capture (CDC) logic."""
        df_with_hash = df_raw.withColumn("pk_hash", F.sha2(F.concat_ws("||", *primary_keys), 256))
        
        if DeltaTable.isDeltaTable(spark, target_table_path):
            delta_table = DeltaTable.forPath(spark, target_table_path)
            logger.info("Merging new changes...")
            delta_table.alias("tgt")\
                .merge(df_with_hash.alias("src"), "tgt.pk_hash = src.pk_hash")\
                .whenMatchedUpdateAll()\
                .whenNotMatchedInsertAll()\
                .execute()
        else:
            logger.info("Creating new Delta table.")
            df_with_hash.write.format("delta").mode("overwrite").save(target_table_path)
        
        return self.read_source_data_delta(target_table_path)
