BEGIN;


CREATE TABLE public."Employees"
(
    commision_pct numeric(2, 2),
    email character varying(100) NOT NULL,
    employee_id integer NOT NULL,
    first_name character varying(20),
    hire_date date NOT NULL,
    job_id character varying(10) NOT NULL,
    last_name character varying(25) NOT NULL,
    phone_number character varying(20),
    salary numeric(8, 2) NOT NULL,
    manager_id integer,
    department_id integer,
    PRIMARY KEY (employee_id)
);

CREATE TABLE public."Jobs"
(
    job_id character varying(10) NOT NULL,
    job_title character varying(35) NOT NULL,
    min_salary numeric(8, 2),
    max_salary numeric(8, 2),
    PRIMARY KEY (job_id)
);

CREATE TABLE public."Departments"
(
    department_id integer NOT NULL,
    department_name character varying(30) NOT NULL,
    manager_id integer,
    location_id integer,
    PRIMARY KEY (department_id)
);

CREATE TABLE public."Locations"
(
    location_id integer NOT NULL,
    street_address character varying(40),
    postal_code character varying(12),
    city character varying(30) NOT NULL,
    state_province character varying(25),
    country_id character(2) NOT NULL,
    PRIMARY KEY (location_id)
);

ALTER TABLE public."Employees"
    ADD FOREIGN KEY (department_id)
    REFERENCES public."Departments" (department_id)
    NOT VALID;


ALTER TABLE public."Employees"
    ADD FOREIGN KEY (job_id)
    REFERENCES public."Jobs" (job_id)
    NOT VALID;


ALTER TABLE public."Departments"
    ADD FOREIGN KEY (location_id)
    REFERENCES public."Locations" (location_id)
    NOT VALID;


ALTER TABLE public."Departments"
    ADD FOREIGN KEY (manager_id)
    REFERENCES public."Employees" (employee_id)
    NOT VALID;

END;