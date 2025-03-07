--TASK 3: DDL for actors_history_scd
CREATE TABLE actors_history_scd (
		actor TEXT
		,start_date INTEGER
		,end_date 	INTEGER
		,quality_class quality_class
		,current_year INTEGER
		,is_active BOOLEAN
);