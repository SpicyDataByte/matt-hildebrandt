# test_iot_pipeline.py - Unit tests for the IoT data pipeline

import unittest
import pytest
from unittest.mock import MagicMock, patch
from pyspark.sql import SparkSession
from pyspark.sql import Row
from iot_functions import SensorFileHelper
from logging import IOTLogger
from security import IOTSecurity, IOTSecVars

def generate_sample_data(spark):
    """Fixture to generate sample sensor data."""
    data = [
        Row(sensor_id=1, temperature=22.5, humidity=60.0, timestamp="2025-03-07T12:00:00Z"),
        Row(sensor_id=2, temperature=23.0, humidity=55.0, timestamp="2025-03-07T12:05:00Z"),
        Row(sensor_id=3, temperature=21.8, humidity=65.0, timestamp="2025-03-07T12:10:00Z"),
    ]
    return spark.createDataFrame(data)

@pytest.fixture(scope="module")
def spark_session():
    """Fixture to provide a Spark session for tests."""
    spark = SparkSession.builder.master("local").appName("test").getOrCreate()
    yield spark
    spark.stop()

@pytest.fixture
def sample_data(spark_session):
    """Fixture that generates sample sensor data."""
    return generate_sample_data(spark_session)

class TestIOTPipeline(unittest.TestCase):
    """Unit tests for IoT data pipeline components."""
    
    def test_get_full_target_path(self):
        helper = SensorFileHelper(container="test-container", storage_acct="test-storage")
        expected_path = "abfss://test-container@test-storage.dfs.core.windows.net/test-path"
        self.assertEqual(helper.get_full_target_path("test-path"), expected_path)
    
    def test_df_rdd_isEmpty(self, spark_session):
        helper = SensorFileHelper(container="test-container", storage_acct="test-storage")
        empty_df = spark_session.createDataFrame([], schema="id INT")
        assert helper.df_rdd_isEmpty(empty_df) is True
    
    @patch("dbutils.secrets.get", return_value="mocked_secret")
    def test_get_iot_sensor_vars(self, mock_secrets):
        sec = IOTSecurity()
        vars = sec.get_iot_sensor_vars("dev")
        assert isinstance(vars, IOTSecVars)
        assert vars.container == "sensor-data"
    
    @patch("logging.getLogger")
    def test_logging(self, mock_logger):
        logger = IOTLogger("dev", "TestProcess", "run123", "2023-12-17 16:00:00", "temperature")
        logger.info("Test log message")
        mock_logger.assert_called()
    
    def test_pipeline_with_sample_data(self, sample_data):
        """Test the data pipeline by processing sample sensor data."""
        assert sample_data.count() == 3  # Ensure sample data is loaded
        assert "sensor_id" in sample_data.columns
        assert "temperature" in sample_data.columns
        assert "humidity" in sample_data.columns
    
if __name__ == "__main__":
    pytest.main()
