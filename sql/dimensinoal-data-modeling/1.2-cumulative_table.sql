--TASK 2: Cumulative Table Generation Query
WITH yesterday AS (
    SELECT 
        actors.* 
    FROM 
        actors 
    WHERE 
        current_year = 1991 --should pass as parameter
),
today AS (
    SELECT 
        actor_films.* 
    FROM 
        actor_films 
    WHERE 
		year = 1992         --should pass as parameter
)
,merged_actors AS (
    SELECT 
        COALESCE(t.actorid, y.actorid) AS actorid,
        COALESCE(t.actor, y.actor) AS actor,
        CASE
            WHEN y.films IS NULL THEN ARRAY[ROW(t.year, t.film, t.votes, t.rating, t.filmid)::films]
            WHEN t.film IS NOT NULL THEN y.films || ROW(t.year, t.film, t.votes, t.rating, t.filmid)::films
            ELSE y.films
        END AS films,
        COALESCE(t.year, y.current_year + 1) AS current_year
    FROM 
        today t
    FULL OUTER JOIN 
        yesterday y 
    ON 
        t.actorid = y.actorid
),
expanded_films AS (
    SELECT 
        actor, 
        f.year, 
        f.rating 
    FROM 
        merged_actors, 
        UNNEST(films) AS f
),
average_ratings AS (
    SELECT 
        e.actor, 
        e.year, 
        AVG(e.rating) AS avg_rating 
    FROM 
        expanded_films e
    GROUP BY 
        e.actor, e.year
    HAVING 
        e.year = 1992       --should pass as parameter
),
final_result AS (
    SELECT 
        ma.actorid, 
        ma.actor, 
        ma.films, 
        ar.avg_rating,
        CASE 
            WHEN ar.avg_rating > 8 THEN 'star'
            WHEN ar.avg_rating > 7 THEN 'good'
            WHEN ar.avg_rating > 6 THEN 'average'
            ELSE 'bad' 
        END :: quality_class AS quality_class,
        ma.current_year,
        EXISTS (SELECT 1 FROM UNNEST(ma.films) AS f WHERE f.year = ma.current_year
        ) AS is_active
    FROM 
        merged_actors ma
    LEFT JOIN 
        average_ratings ar 
    ON 
        ma.actor = ar.actor
)
INSERT INTO actors
SELECT 
    actorid,
    actor,
    ARRAY_AGG(ROW(f.year, f.film, f.votes, f.rating, f.filmid)::films) AS films, 
    quality_class,
    is_active,
    current_year
FROM 
    final_result fr
CROSS JOIN 
    UNNEST(fr.films) AS f(year, film, votes, rating, filmid)
GROUP BY 
    actorid, actor, quality_class, is_active, current_year;