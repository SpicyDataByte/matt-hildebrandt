WITH dedup_devices AS (
    SELECT 
        ROW_NUMBER() OVER (PARTITION BY device_id) AS row_num,
        device_id,
        browser_type
    FROM devices
),

yesterday AS (
    SELECT 
        user_id,
        device_activity_datelist,
        date,
        browser_type
    FROM user_devices_cumulated
    WHERE date = DATE('2022-12-31')
),

event_devices AS (
    SELECT
        e.user_id AS user_id,
        e.device_id AS device_id,
        e.event_time AS event_time,
        d.browser_type AS browser_type
    FROM events e
    JOIN dedup_devices d 
        ON e.device_id = d.device_id
    WHERE row_num = 1
),

today AS (
    SELECT
        CAST(user_id AS TEXT) AS user_id,
        DATE(CAST(event_time AS TIMESTAMP)) AS device_activity_datelist,
        browser_type
    FROM event_devices
    WHERE 
        DATE(CAST(event_time AS TIMESTAMP)) = DATE('2023-01-01') 
        AND user_id IS NOT NULL
    GROUP BY
        user_id,
        DATE(CAST(event_time AS TIMESTAMP)),
        browser_type
)

INSERT INTO user_devices_cumulated
SELECT 
    COALESCE(t.user_id, y.user_id) AS user_id,
    CASE 
        WHEN y.device_activity_datelist IS NULL THEN ARRAY [t.device_activity_datelist]
        WHEN t.device_activity_datelist IS NULL THEN y.device_activity_datelist
        ELSE ARRAY [t.device_activity_datelist] || y.device_activity_datelist
    END AS device_activity_datelist,
    COALESCE(t.device_activity_datelist, y.date + INTERVAL '1 day') AS date,
    COALESCE(t.browser_type, y.browser_type) AS browser_type
FROM today t
FULL OUTER JOIN yesterday y 
    ON t.user_id = y.user_id 
    AND t.browser_type = y.browser_type