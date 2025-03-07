import random

def create_tables(conn):
    create_table_queries = [
        # Create table for Dim_Academic_Org
        """
        CREATE TABLE IF NOT EXISTS dbo.Dim_Academic_Org (
            Faculty_Code NVARCHAR(50)
        )
        """,
        # Create table for DimMonth
        """
        CREATE TABLE IF NOT EXISTS dbo.DimMonth (
            month INT,
            monthid NVARCHAR(10)
        )
        """,
        # Create table for DimCustomer
        """
        CREATE TABLE IF NOT EXISTS dbo.DimCustomer (
            category NVARCHAR(50)
        )
        """,
        # Create table for Fact_WorkforceLevels
        """
        CREATE TABLE IF NOT EXISTS dbo.Fact_WorkforceLevels (
            ActualFullTimeEquivalent FLOAT
        )
        """
    ]
    for query in create_table_queries:
        execute_sql(conn, query)
    print("Tables created successfully.")

def generate_sample_data(conn):
    try:
        # Example data generation logic for each table
        data_generation_queries = []

        # Generate data for Dim_Academic_Org
        academic_org_values = [(None if i % 10 == 0 else f"Faculty_{i}") for i in range(1, 1001)]
        data_generation_queries.append(
            "INSERT INTO dbo.Dim_Academic_Org (Faculty_Code) VALUES " +
            ", ".join([f"({repr(value)})" for value in academic_org_values])
        )

        # Generate data for DimMonth
        dim_month_values = [(i % 12 + 1, f"Month_{i}") for i in range(1, 1001)]
        data_generation_queries.append(
            "INSERT INTO dbo.DimMonth (month, monthid) VALUES " +
            ", ".join([f"({month}, '{monthid}')" for month, monthid in dim_month_values])
        )

        # Generate data for DimCustomer
        dim_customer_values = [
            random.choice(['Individual', 'Company', 'InvalidCategory']) for _ in range(1000)
        ]
        data_generation_queries.append(
            "INSERT INTO dbo.DimCustomer (category) VALUES " +
            ", ".join([f"('{value}')" for value in dim_customer_values])
        )

        # Generate data for Fact_WorkforceLevels
        workforce_values = [random.uniform(5, 50) for _ in range(1000)]
        data_generation_queries.append(
            "INSERT INTO dbo.Fact_WorkforceLevels (ActualFullTimeEquivalent) VALUES " +
            ", ".join([f"({value:.2f})" for value in workforce_values])
        )

        # Execute all data generation queries
        for query in data_generation_queries:
            execute_sql(conn, query)

        print("Sample data generated successfully.")

    except Exception as e:
        print(f"Error generating sample data: {str(e)}")
