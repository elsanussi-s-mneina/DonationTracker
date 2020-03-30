-- An SQL script that undoes what the DatabaseSetup.sql did.

DROP TABLE donorDonations;
DROP DATABASE DonationTracking;
DROP USER 'donationTrackerUser'@'localhost';



-- Convenience statements for checking that it worked:
-- SELECT * FROM tableinfo;

-- SELECT User,Host FROM mysql.user;
-- SHOW GRANTS FOR 'donationTrackerUser'@'localhost';
