def connect_to_db():
    try:
        conn = pyodbc.connect(CONNECTION_STRING)
        print("Connected to SQL Server")
        return conn
    except Exception as e:
        print(f"Error: {str(e)}")
        return None

def close_connection(conn):
    if conn:
        conn.close()
        print("Disconnected from SQL Server")

def execute_sql(conn, sql, params=None):
    with conn.cursor() as cursor:
        cursor.execute(sql, params or [])
        if cursor.description:  
            return cursor.fetchall()
    return None