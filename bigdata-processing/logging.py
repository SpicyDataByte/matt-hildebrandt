# logging.py - Logging and Azure Monitor integration

import sys
import logging
import json
from datetime import datetime
from pytz import timezone
from opencensus.ext.azure.log_exporter import AzureLogHandler

class IOTLogger:
    """Logger for IoT sensor data processing."""
    def __init__(self, environment: str, process_name: str, run_id: str, batch_datetime: str, file_type: str, level=logging.INFO):
        self.environment = environment
        self.process_name = process_name
        self.run_id = run_id
        self.batch_datetime = batch_datetime
        self.file_type = file_type
        self.logging_level = level

        # Get logging connection string
        secret_scope = "iot-sensor-kv-databricks"
        logging_conn_str = dbutils.secrets.get(scope=secret_scope, key="iot-sensor-appinsight-connstr")
        
        # Configure logger
        self.logger = logging.getLogger(self.process_name)
        self.logger.setLevel(level)
        self._clear_handlers()
        
        # Console handler
        console_handler = logging.StreamHandler(sys.stdout)
        console_handler.setFormatter(self._get_formatter())
        self.logger.addHandler(console_handler)
        
        # Azure logging
        if logging_conn_str:
            azure_handler = AzureLogHandler(connection_string=logging_conn_str)
            self.logger.addHandler(azure_handler)
        
        self.extraproperties = {
            "custom_dimensions": {
                "environment": self.environment,
                "process": self.process_name,
                "run_id": self.run_id,
                "batch_datetime": self.batch_datetime,
                "file_type": self.file_type
            }
        }

    def _clear_handlers(self):
        """Removes existing handlers to avoid duplicate logs."""
        for handler in list(self.logger.handlers):
            self.logger.removeHandler(handler)

    def _get_formatter(self):
        """Returns a log formatter with timestamp and metadata."""
        return logging.Formatter(
            "[%(asctime)s] - %(name)s - %(levelname)s --- %(message)s",
            datefmt="%Y-%m-%d %H:%M:%S"
        )

    def info(self, msg):
        self.logger.info(msg, extra=self.extraproperties)
    
    def error(self, msg):
        self.logger.error(msg, extra=self.extraproperties)
    
    def debug(self, msg):
        self.logger.debug(msg, extra=self.extraproperties)
    
    def warning(self, msg):
        self.logger.warning(msg, extra=self.extraproperties)
    
    def stop(self):
        """Flush and close all log handlers."""
        for handler in list(self.logger.handlers):
            handler.flush()
            handler.close()
