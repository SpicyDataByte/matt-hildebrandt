CREATE TABLE user_devices_cumulated(

    user_id TEXT
    ,device_activity_datelist date[]
    ,date date
    ,browser_type TEXT
    ,PRIMARY key(user_id, date, browser_type)
)