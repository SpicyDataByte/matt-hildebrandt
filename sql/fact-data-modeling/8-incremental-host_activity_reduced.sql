WITH daily_aggregates AS (
    SELECT
        host,
        DATE(event_time) AS DATE,
        COUNT(1) AS num_site_hits,
        COUNT(DISTINCT user_id) as distinct_visitors
    FROM 
        events
    WHERE
        DATE(event_time) = DATE('2023-01-02')
        AND user_id IS NOT NULL
    GROUP BY
        host,
        DATE(event_time)
),
yesterday_array AS (
    SELECT * 
    FROM host_activity_reduced
    WHERE month_start = DATE('2023-01-01')
)

INSERT INTO host_activity_reduced
SELECT 
    COALESCE(da.host, ya.host) AS host,
    COALESCE(ya.month_start, DATE_TRUNC('month', da.date)) AS month_start,
    'site_hits' AS metric_name,
    CASE 
        WHEN ya.hit_array IS NOT NULL 
            THEN ya.hit_array || ARRAY[COALESCE(da.num_site_hits, 0)]
        WHEN ya.hit_array IS NULL
            THEN ARRAY_FILL(0, ARRAY[COALESCE(DATE - DATE(DATE_TRUNC('month', date)), 0)]) || ARRAY[COALESCE(da.num_site_hits, 0)]
    END AS hit_array
   ,CASE 
    WHEN ya.unique_vistors_array IS NOT NULL 
        THEN ya.unique_vistors_array || ARRAY[COALESCE(da.distinct_visitors, 0)]
    WHEN ya.unique_vistors_array IS NULL
        THEN ARRAY_FILL(0, ARRAY[COALESCE(DATE - DATE(DATE_TRUNC('month', date)), 0)]) || ARRAY[COALESCE(da.distinct_visitors, 0)]
    END AS unique_vistors_array
FROM daily_aggregates da
FULL OUTER JOIN yesterday_array ya
    ON da.host = ya.host

    
ON CONFLICT (host, month_start, metric_name)
DO UPDATE 
SET 
    hit_array = EXCLUDED.hit_array
    ,unique_vistors_array = EXCLUDED.unique_vistors_array;