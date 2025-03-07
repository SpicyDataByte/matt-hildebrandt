with yesterday as (
    select * from host_activity_datelist
    where date = date('2022-12-31')
)

,today as (
    SELECT
        CAST(host AS TEXT) AS host
        ,DATE(CAST(event_time AS TIMESTAMP)) as host_activity_datelist
    from events
    WHERE 
        DATE(CAST(event_time AS TIMESTAMP)) = DATE('2023-01-01')
        and host is not null
    GROUP BY
        host, DATE(CAST(event_time AS TIMESTAMP))
)

INSERT INTO host_activity_datelist
SELECT 
    COALESCE(t.host, y.host) as host
    ,CASE 
        WHEN y.host_activity_datelist IS NULL
            THEN ARRAY [t.host_activity_datelist]
        WHEN t.host_activity_datelist IS NULL 
            THEN y.host_activity_datelist
        ELSE ARRAY [t.host_activity_datelist] || y.host_activity_datelist 
    END as host_activity_datelist
    ,COALESCE(t.host_activity_datelist, y.date + INTERVAL '1 day') as date
from today t 
full outer join yesterday y 
on t.host = y.host
