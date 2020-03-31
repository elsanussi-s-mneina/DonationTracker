-- A PostgreSQL script for creating the database, the table,
-- and the user.


-- From postgres database, run the following two statements.
CREATE USER donation_tracker_user WITH PASSWORD 'secret1secret';


CREATE DATABASE donation_tracking WITH OWNER donation_tracker_user ENCODING='UTF-8' LC_COLLATE='en_US.UTF-8' LC_CTYPE='en_US.UTF-8';

GRANT ALL PRIVILEGES ON DATABASE donation_tracking TO donation_tracker_user;


-- quit the psql shell, by entering
-- \q




---------------- Run the following in the database we just created ------------

-- Now log into the donation_tracking database using the following command:
-- (must be all lowercase)
-- psql donation_tracking

create table donor_donations
(
  id SERIAL,
  first_name VARCHAR(30),
  last_name  VARCHAR(30),
  donation_amount DECIMAL NOT NULL,
  PRIMARY KEY(id)
);


GRANT ALL PRIVILEGES ON TABLE donor_donations TO donation_tracker_user;

GRANT USAGE, SELECT ON ALL SEQUENCES IN SCHEMA public TO donation_tracker_user;


