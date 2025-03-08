-- This calculates user activity flags (daily, weekly, monthly) by encoding activity dates as a 32-bit integer using bitwise operations.
-- Bitwise encoding reduces storage from 124 bytes to 4 bytes per user per month by representing activity as a 32-bit integer, saving over 95% the storage space.
with users as (
    select * from user_devices_cumulated
    where date = date('2023-01-31')
)

,series as (
    select * from generate_series('2023-01-01', '2023-01-31', INTERVAL '1 day') as series_date
)
,placeholder_ints as (
select 
    CASE 
    WHEN device_activity_datelist @> ARRAY[DATE(series_date)]
    THEN CAST(POW(2, 31 - (date - date(series_date))) AS BIGINT)
    ELSE 0
END AS INT_VALUE
,* 
from users cross join series
)


SELECT 
    USER_ID
	,browser_type
    ,CAST(CAST(SUM(INT_VALUE) AS BIGINT) AS BIT(32)) as datelist_int
    ,BIT_COUNT(CAST(CAST(SUM(INT_VALUE) AS BIGINT) AS BIT(32))) > 0 as dim_is_monthly_active
    ,BIT_COUNT(CAST('11111110000000000000000000000000' AS BIT(32)) &
        CAST(CAST(SUM(INT_VALUE) AS BIGINT) AS BIT(32))) > 0 AS dim_is_weekly_active
    ,BIT_COUNT(CAST('10000000000000000000000000000000' AS BIT(32)) &
        CAST(CAST(SUM(INT_VALUE) AS BIGINT) AS BIT(32))) > 0 AS dim_is_daily_active
FROM placeholder_ints
GROUP BY
    USER_ID,
	browser_type
	