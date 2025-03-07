--TASK 4: Backfill actors_history_scd
INSERT INTO actors_history_scd
WITH streak_started AS (
	SELECT
		actorid,
		current_year,
		quality_class,
		LAG(quality_class, 1) OVER (PARTITION BY actorid ORDER BY current_year) <> quality_class
			OR LAG(is_active, 1) OVER (PARTITION BY actorid ORDER BY current_year) <> is_active
			OR LAG(quality_class, 1) OVER (PARTITION BY actorid ORDER BY current_year) IS NULL
		AS did_change,
		is_active
	FROM actors
	WHERE current_year <= 1994
),
streak_identified AS (
	SELECT
		actorid,
		quality_class,
		current_year,
		SUM(CASE WHEN did_change THEN 1 ELSE 0 END)
			OVER (PARTITION BY actorid ORDER BY current_year) AS streak_identifier,
		is_active
	FROM streak_started
),
aggregated AS (
	SELECT
		actorid,
		quality_class,
		streak_identifier,
		is_active,
		MAX(current_year) AS end_date,
		MIN(current_year) AS start_date
	FROM streak_identified
	GROUP BY actorid, quality_class, streak_identifier, is_active
)
SELECT
	actorid,
	start_date,
	end_date,
	quality_class,
	1994 AS current_year,
	is_active
FROM aggregated
