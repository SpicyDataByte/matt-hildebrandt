--Task 5: Incremental Query for actors_history_scd
CREATE TYPE scd_type_actors AS (
    quality_class quality_class,
    is_active BOOLEAN,
    start_date INTEGER,
    end_date INTEGER
);

WITH last_year_scd AS (
    SELECT * FROM actors_history_scd
    WHERE current_year = 1994
    AND end_date = 1994
),
historical_scd AS (
    SELECT
        actorid,
        quality_class,
        is_active,
        start_date,
        end_date
    FROM actors_history_scd
    WHERE current_year = 1994
    AND end_date < 1994
),
this_year_data AS (
    SELECT * FROM actors
    WHERE current_year = 1995
)
,unchanged_records AS (
    SELECT
        ty.actorid,
        ty.quality_class,
        ty.is_active,
        ly.start_date,
        ty.current_year AS end_date
    FROM this_year_data ty
    JOIN last_year_scd ly
    ON ly.actorid = ty.actorid 
    WHERE ty.quality_class = ly.quality_class
    AND ty.is_active = ly.is_active
)
,changed_records AS (
    SELECT
        ty.actorid,
        UNNEST(ARRAY[
            ROW(
                ly.quality_class,
                ly.is_active,
                ly.start_date,
                ly.end_date
            )::scd_type_actors,
            ROW(
                ty.quality_class,
                ty.is_active,
                ty.current_year,
                ty.current_year
            )::scd_type_actors
        ]) AS records
    FROM this_year_data ty
    LEFT JOIN last_year_scd ly
    ON ly.actorid = ty.actorid
    WHERE (ty.quality_class <> ly.quality_class
       OR ty.is_active <> ly.is_active)
)
,unnested_changed_records AS (
    SELECT 
        actorid,
        (records::scd_type_actors).quality_class,
        (records::scd_type_actors).is_active,
        (records::scd_type_actors).start_date,
        (records::scd_type_actors).end_date
    FROM changed_records
),
new_records AS (
    SELECT
        ty.actorid,
        ty.quality_class,
        ty.is_active,
        ty.current_year AS start_date,
        ty.current_year AS end_date
    FROM this_year_data ty
    LEFT JOIN last_year_scd ly
    ON ty.actorid = ly.actorid
    WHERE ly.actorid IS NULL
)
SELECT *, 1995 AS current_year FROM (
    SELECT * FROM historical_scd
    UNION ALL
    SELECT * FROM unchanged_records
    UNION ALL
    SELECT * FROM unnested_changed_records
    UNION ALL
    SELECT * FROM new_records
) a;