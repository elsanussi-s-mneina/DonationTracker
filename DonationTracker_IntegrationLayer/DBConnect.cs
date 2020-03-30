using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace DonationTracker.Integration
{
    public class DBConnect
    {
        // The following article is a useful tutorial to help understand
        // this code:
        // https://www.codeproject.com/Articles/43438/Connect-C-to-MySQL
        // Some of the code here is patterned after the code in the tutorial.

        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        public DBConnect()
        {
            Initialize();
        }

        public void Initialize()
        {
            server = "localhost";
            database = "DonationTracking";
            uid = "donationTrackerUser";
            password = "secret1secret";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
                database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);

        }

        internal decimal CalculateTotalDonationAmount()
        {
            decimal total = 0;
            if (OpenConnection())
            {
                MySqlCommand command = new MySqlCommand();

                command.Connection = connection;

                command.CommandType = System.Data.CommandType.Text;
                command.CommandText =
                    "SELECT SUM(donationAmount) FROM donorDonations;";


                MySqlDataReader dataReader = command.ExecuteReader();

                dataReader.Read();
                total = dataReader.GetDecimal(0);

                CloseConnection();
            }

            return total;
        }

        internal IList<DonorDonation> ReadAllDonors()
        {

            IList<DonorDonation> donorDonations = new List<DonorDonation>();

            if (OpenConnection())
            {
                MySqlCommand command = new MySqlCommand();

                command.Connection = connection;

                command.CommandType = System.Data.CommandType.Text;
                command.CommandText =
                    "SELECT id, firstName, lastName, donationAmount FROM donorDonations;";


                MySqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    var donorDonation = new DonorDonation();
                    int id = dataReader.GetInt32(0);
                    donorDonation.FirstName = dataReader.GetString(1);
                    donorDonation.LastName = dataReader.GetString(2);
                    donorDonation.DonationAmount = dataReader.GetDecimal(3);

                    donorDonations.Add(donorDonation);
                }

                CloseConnection();
            }

            return donorDonations;

        }


        public IList<DonorDonationTotalByDonor> CalculatePerDonorTotalDonationAmount()
        {
            IList<DonorDonationTotalByDonor> donorDonations = new List<DonorDonationTotalByDonor>();

            if (OpenConnection())
            {
                MySqlCommand command = new MySqlCommand();

                command.Connection = connection;

                command.CommandType = System.Data.CommandType.Text;
                command.CommandText =
                    "SELECT id, firstName, lastName, SUM(donationAmount) FROM donorDonations GROUP BY id;";


                MySqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    var donorDonation = new DonorDonationTotalByDonor();
                    int id = dataReader.GetInt32(0);
                    donorDonation.FirstName = dataReader.GetString(1);
                    donorDonation.LastName = dataReader.GetString(2);
                    donorDonation.TotalDonationAmount = dataReader.GetDecimal(3);

                    donorDonations.Add(donorDonation);
                }

                CloseConnection();
            }

            return donorDonations;

        }



        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                // See the following documentation for understanding of
                // MySQL server error codes.
                // https://dev.mysql.com/doc/refman/8.0/en/global-error-reference.html

                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        throw new IntegrationLayerException(ex);

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        throw new IntegrationLayerException(ex);
                }
                return false;
            }

        }

        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public void Insert(DonorDonation donation)
        {
            if (OpenConnection())
            {
                MySqlCommand insertCommand = new MySqlCommand();

                insertCommand.Connection = connection;

                insertCommand.CommandType = System.Data.CommandType.Text;
                insertCommand.CommandText =
                    "INSERT INTO donorDonations (firstName, lastName, donationAmount) VALUES(@firstName, @lastName, @donationAmount)";

                var firstNameParam = new MySqlParameter("@firstName", donation.FirstName);
                firstNameParam.DbType = System.Data.DbType.String;
                insertCommand.Parameters.Add(firstNameParam);

                var lastNameParam = new MySqlParameter("@lastName", donation.LastName);
                lastNameParam.DbType = System.Data.DbType.String;
                insertCommand.Parameters.Add(lastNameParam);

                var donationAmountParam = new MySqlParameter("@donationAmount", donation.DonationAmount);
                donationAmountParam.DbType = System.Data.DbType.Decimal;
                insertCommand.Parameters.Add(donationAmountParam);

                insertCommand.ExecuteNonQuery();

                CloseConnection();
            }
        }


    }
}