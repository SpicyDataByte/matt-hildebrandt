tests = [
        {
            "testname": "Check for Nulls in Faculty_Code",
            "function": check_for_nulls,
            "params": {"table": "edw.Dim_Academic_Org", "column": "Faculty_Code"},
        },
        {
            "testname": "Check for Min and Max in Month",
            "function": check_for_min_max,
            "params": {"table": "DimMonth", "column": "month", "minimum": 1, "maximum": 12},
        },
        {
            "testname": "Check for Valid Values in Category",
            "function": check_for_valid_values,
            "params": {
                "table": "DimCustomer",
                "column": "category",
                "valid_values": {"Individual", "Company"},
            },
        },
        {
            "testname": "Check for Duplicates in MonthID",
            "function": check_for_duplicates,
            "params": {"table": "DimMonth", "column": "monthid"},
        },
        {
            "testname": "Check for Outliers in ActualFullTimeEquivalent",
            "function": check_for_outliers,
            "params": {"table": "edw.Fact_WorkforceLevels", "column": "ActualFullTimeEquivalent", "threshold": 3},
        },
]