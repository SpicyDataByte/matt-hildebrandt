import os
import pyodbc
import pandas as pd
from tabulate import tabulate
from time import time, ctime

SERVER = ''
DATABASE = ''
AUTHENTICATION_TYPE = 'ActiveDirectoryInteractive'
DRIVER = '{ODBC Driver 17 for SQL Server}'
CONNECTION_STRING = f'DRIVER={DRIVER};SERVER={SERVER};DATABASE={DATABASE};Authentication={AUTHENTICATION_TYPE};'

def main():
    conn = connect_to_db()
    if not conn:
        return

    generate_sample_data(conn)

    results = run_data_quality_checks(conn, tests)

    df = pd.DataFrame(results, columns=["Test Name", "Table", "Column", "Test Passed"])
    print(tabulate(df, headers="keys", tablefmt="psql"))

    close_connection(conn)

if __name__ == "__main__":
    main()
