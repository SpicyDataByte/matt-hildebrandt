def check_for_nulls(conn, table, column):
    SQL = f'SELECT COUNT(*) FROM {table} WHERE {column} IS NULL'
    return bool(execute_sql(conn, SQL)[0][0])

def check_for_min_max(conn, table, column, minimum, maximum):
    SQL = f'SELECT COUNT(*) FROM {table} WHERE {column} < ? OR {column} > ?'
    return not bool(execute_sql(conn, SQL, (minimum, maximum))[0][0])

def check_for_valid_values(conn, table, column, valid_values):
    SQL = f'SELECT DISTINCT {column} FROM {table}'
    actual_values = {row[0] for row in execute_sql(conn, SQL)}
    return all(value in valid_values for value in actual_values)

def check_for_duplicates(conn, table, column):
    SQL = f'SELECT COUNT({column}) FROM {table} GROUP BY {column} HAVING COUNT({column}) > 1'
    return not bool(execute_sql(conn, SQL))

def check_for_outliers(conn, table, column, threshold):
    SQL = f'SELECT {column} FROM {table}'
    values = [row[0] for row in execute_sql(conn, SQL)]
    mean_value = sum(values) / len(values)
    std_dev = (sum((x - mean_value) ** 2 for x in values) / len(values)) ** 0.5
    z_scores = [(x - mean_value) / std_dev for x in values]
    return not any(abs(z) > threshold for z in z_scores)

def run_data_quality_checks(conn, tests):
    results = []
    for test in tests:
        print(f"Running Test: {test['testname']}...")
        status = test["function"](conn, **test["params"])
        results.append((test["testname"], test["params"].get("table"), test["params"].get("column"), status))
    return results