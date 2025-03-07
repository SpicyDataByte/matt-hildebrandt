CREATE TABLE host_activity_datelist(
    host TEXT
    ,host_activity_datelist date[]
    ,date date
    ,PRIMARY key(host, date)
)