# security.py - Handles authentication and security for IoT sensor data

from dataclasses import dataclass

@dataclass(frozen=True)
class IOTSecVars:
    """Class to store IoT sensor security credentials."""
    device_id: str
    device_secret: str
    tenant_id: str
    storage_account: str
    container: str

class IOTSecurity:
    """Handles security for IoT sensor data access."""
    
    def set_device_security_context(self, vars: IOTSecVars) -> None:
        """Configures security context for device authentication."""
        spark.conf.set(f"fs.azure.account.auth.type.{vars.storage_account}.dfs.core.windows.net", "OAuth")
        spark.conf.set(f"fs.azure.account.oauth.provider.type.{vars.storage_account}.dfs.core.windows.net", "org.apache.hadoop.fs.azurebfs.oauth2.ClientCredsTokenProvider")
        spark.conf.set(f"fs.azure.account.oauth2.client.id.{vars.storage_account}.dfs.core.windows.net", vars.device_id)
        spark.conf.set(f"fs.azure.account.oauth2.client.secret.{vars.storage_account}.dfs.core.windows.net", vars.device_secret)
        spark.conf.set(f"fs.azure.account.oauth2.client.endpoint.{vars.storage_account}.dfs.core.windows.net", f"https://login.microsoftonline.com/{vars.tenant_id}/oauth2/token")

    def get_iot_sensor_vars(self, env: str) -> IOTSecVars:
        """Retrieves IoT sensor security credentials."""
        secret_scope = "iot-sensor-kv-databricks"
        device_id = dbutils.secrets.get(scope=secret_scope, key="iot-sensor-spn-clientid")
        device_secret = dbutils.secrets.get(scope=secret_scope, key="iot-sensor-spn-clientsecret")
        tenant_id = dbutils.secrets.get(scope=secret_scope, key="tenant-id")
        storage_account = f"iotsensor{env}datalake"
        container = "sensor-data"
        return IOTSecVars(device_id, device_secret, tenant_id, storage_account, container)
    
    def get_iot_public_vars(self, env: str) -> IOTSecVars:
        """Retrieves public IoT sensor security credentials."""
        secret_scope = "iot-sensor-kv-databricks"
        device_id = dbutils.secrets.get(scope=secret_scope, key="iot-public-spn-client-id")
        device_secret = dbutils.secrets.get(scope=secret_scope, key="iot-public-spn-client-secret")
        tenant_id = dbutils.secrets.get(scope=secret_scope, key="tenant-id")
        storage_account = f"iot{env}datalakesta"
        container = "public-sensor-data"
        return IOTSecVars(device_id, device_secret, tenant_id, storage_account, container)