-- An SQL script that undoes what the DatabaseSetup.sql did.


-- Run the following statement within donation_tracking database terminal:

DROP TABLE donor_donations;



-- Switch to the postgre database and run:
DROP DATABASE donation_tracking;
DROP USER donation_tracker_user;

