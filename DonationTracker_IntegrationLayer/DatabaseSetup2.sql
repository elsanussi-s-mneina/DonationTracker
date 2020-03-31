-- Now log into the donation_tracking database using the following command:
-- (must be all lowercase)
-- psql donation_tracking
-- and run the following
-- OR just
-- run the following command
-- psql -f DatabaseSetup2.sql donation_tracking

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


