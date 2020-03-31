-- Now log into the donation_tracking database using the following command:
-- (must be all lowercase)
-- psql donation_tracking
-- and run the following
-- OR just
-- run the following command
-- psql -f DatabaseSetup2.sql donation_tracking


create table donor
(
  id SERIAL,
  first_name VARCHAR(30),
  last_name  VARCHAR(30),
  PRIMARY KEY(id)
);


create table donation
(
  id SERIAL,
  donor_id SERIAL,
  donation_amount DECIMAL NOT NULL,
  PRIMARY KEY (donor_id, id),
  FOREIGN KEY(donor_id) REFERENCES donor (id)
);


GRANT ALL PRIVILEGES ON TABLE donor TO donation_tracker_user;
GRANT ALL PRIVILEGES ON TABLE donation TO donation_tracker_user;

GRANT USAGE, SELECT ON ALL SEQUENCES IN SCHEMA public TO donation_tracker_user;


