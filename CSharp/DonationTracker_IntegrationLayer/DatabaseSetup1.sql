-- A PostgreSQL script for creating the database, the table,
-- and the user.



-- From postgres database, run the following two statements.
-- OR just
-- run the following command
-- psql -f DatabaseSetup1.sql postgres


CREATE USER donation_tracker_user WITH PASSWORD 'secret1secret';


CREATE DATABASE donation_tracking WITH OWNER donation_tracker_user ENCODING='UTF-8' LC_COLLATE='en_US.UTF-8' LC_CTYPE='en_US.UTF-8';

GRANT ALL PRIVILEGES ON DATABASE donation_tracking TO donation_tracker_user;
