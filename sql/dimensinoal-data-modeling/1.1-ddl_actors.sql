--TASK 1: DDL for actors table
CREATE TYPE films as (
	year int,
	film text, 
	votes integer, 
	rating real,
	filmid text
);

CREATE TYPE quality_class as enum ('star', 'good', 'average', 'bad');

CREATE TABLE actors (
	actorid text,
	actor text, 
	films films[],
	quality_class quality_class,
	is_active boolean,
	current_year int, 
	primary key(actor, current_year)
);