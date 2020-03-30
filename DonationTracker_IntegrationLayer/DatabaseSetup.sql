-- A MySQL script for creating the database, the table,
-- and the user.

create database DonationTracking;
use DonationTracking;

create table tableInfo
(
  id INT NOT NULL auto_increment,
  name VARCHAR(30),
  age INT,
  PRIMARY KEY(id)
);


CREATE USER 'donationTrackerUser'@'localhost' IDENTIFIED BY 'secret1secret';
GRANT ALL PRIVILEGES ON DonationTracking.* TO 'donationTrackerUser'@'localhost';


-- Convenience statements for checking that it worked:

-- SELECT * FROM tableinfo;

-- SELECT User,Host FROM mysql.user;
-- SHOW GRANTS FOR 'donationTrackerUser'@'localhost';



