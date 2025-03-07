CREATE TABLE host_activity_reduced(
    host text,
    month_start DATE,
    metric_name TEXT
    ,hit_array REAL[]
    ,unique_vistors_array REAL[]
    ,PRIMARY KEY (host, month_start, metric_name)
)