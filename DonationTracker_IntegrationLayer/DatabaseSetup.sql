-- A MySQL script for creating the database, the table,
-- and the user.

create database DonationTracking;
use DonationTracking;

create table donorDonations
(
  id INT NOT NULL auto_increment,
  firstName VARCHAR(30),
  lastName  VARCHAR(30),
  donationAmount DECIMAL,
  PRIMARY KEY(id)
);


CREATE USER 'donationTrackerUser'@'localhost' IDENTIFIED BY 'secret1secret';
GRANT ALL PRIVILEGES ON DonationTracking.* TO 'donationTrackerUser'@'localhost';


-- Convenience statements for checking that it worked:

-- SELECT * FROM donorDonations;

-- SELECT User,Host FROM mysql.user;
-- SHOW GRANTS FOR 'donationTrackerUser'@'localhost';



