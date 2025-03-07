class AzureAuthenticator:
    def __init__(
        self,
        spark: SparkSession,
        secret_scope_name: str,
        key_name_for_spn_secret: str,
        key_name_for_spn_clientId: str,
        key_name_for_spn_tenantId: str,
    ):
        """
        Initializes AzureAuthenticator to facilitate OAuth token-based authentication for querying Azure SQL.

        Parameters:
            spark (SparkSession): Active Databricks Spark session.
            secret_scope_name (str): Databricks secret scope name.
            key_name_for_spn_secret (str): Key for the Azure Service Principal secret.
            key_name_for_spn_clientId (str): Key for the Azure Service Principal Client ID.
            key_name_for_spn_tenantId (str): Key for the Azure Service Principal Tenant ID.
        """
        self.spark = spark
        self.client_secret = str(dbutils.secrets.get(scope=secret_scope_name, key=key_name_for_spn_secret))
        self.client_id = str(dbutils.secrets.get(scope=secret_scope_name, key=key_name_for_spn_clientId))
        self.directory_id = str(dbutils.secrets.get(scope=secret_scope_name, key=key_name_for_spn_tenantId))
        self.authority = f"https://login.microsoftonline.com/{self.directory_id}"

        # Initialize the MSAL ConfidentialClientApplication for OAuth token acquisition.
        self.app = msal.ConfidentialClientApplication(
            self.client_id,
            authority=self.authority,
            client_credential=self.client_secret
        )

    def get_access_token(self) -> str:
        """
        Retrieves an Azure Active Directory access token using the client credentials flow.

        Returns:
            str: Access token if successful; otherwise, None.
        """
        resource_app_id_url = "https://database.windows.net/"
        result = self.app.acquire_token_for_client(scopes=[f"{resource_app_id_url}/.default"])

        if "access_token" in result:
            print("Authentication to Azure SQL successful!")
            return result["access_token"]
        else:
            print("Authentication failed!")
            print("Error:", result.get("error"))
            print("Description:", result.get("error_description"))
            print("Correlation ID:", result.get("correlation_id"))  # Useful for troubleshooting
            return None

    def extract(self, query: str, database: str, server: str) -> "pyspark.sql.DataFrame":
        """
        Executes a SQL query on an Azure SQL Database using OAuth authentication.

        Parameters:
            query (str): SQL query to execute.
            database (str): Name of the Azure SQL Database.
            server (str): Fully qualified server name (e.g., "yourserver.database.windows.net").

        Returns:
            pyspark.sql.DataFrame: A Spark DataFrame containing the query results.
        """
        access_token = self.get_access_token()
        if not access_token:
            raise Exception("Failed to retrieve access token. Check authentication.")

        jdbc_url = (
            f"jdbc:sqlserver://{server};database={database};"
            "encrypt=true;hostNameInCertificate=*.database.windows.net"
        )

        # Read data from Azure SQL using the Spark JDBC connector with OAuth token authentication.
        df_spark = (
            self.spark.read.format("com.microsoft.sqlserver.jdbc.spark")
            .option("url", jdbc_url)
            .option("databaseName", database)
            .option("accessToken", access_token)
            .option("query", query)
            .option("encrypt", "true")
            .option("hostNameInCertificate", "*.database.windows.net")
            .load()
        )

        return df_spark
