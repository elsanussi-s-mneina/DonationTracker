using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace DonationTracker.Integration
{
    public class DBConnect
    {
        // Most of the code here is copied from the following
        // Article:
        // https://www.codeproject.com/Articles/43438/Connect-C-to-MySQL
        // I will change it, and make it work for our case.
        // So far it does successfully connect to the database and insert
        // rows into the table.
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

            // Server = myServerAddress; Port = 1234; Database = myDataBase; Uid = myUsername; Pwd = myPassword;


            connection = new MySqlConnection(connectionString);

        }

        internal decimal CalculateTotalDonationAmount()
        {
            decimal total = 0;
            if (this.OpenConnection() == true)
            {
                MySqlCommand command = new MySqlCommand();

                // Fill SQL command parameters.
                command.Connection = connection;

                command.CommandType = System.Data.CommandType.Text;
                command.CommandText =
                    "SELECT SUM(donationAmount) FROM donorDonations;";


                MySqlDataReader dataReader = command.ExecuteReader();
                // Read data and show to the console

                dataReader.Read();
                total = dataReader.GetDecimal(0);

                //close connection
                this.CloseConnection();
            }

            return total;
        }

        internal IList<DonorDonation> ReadAllDonors()
        {

            IList<DonorDonation> donorDonations = new List<DonorDonation>();

            //open connection
            if (this.OpenConnection() == true)
            {
                MySqlCommand command = new MySqlCommand();

                // Fill SQL command parameters.
                command.Connection = connection;

                command.CommandType = System.Data.CommandType.Text;
                command.CommandText =
                    "SELECT id, firstName, lastName, donationAmount FROM donorDonations;";


                MySqlDataReader dataReader = command.ExecuteReader();
                // Read data and show to the console.

                // Read data and show to the console


                while (dataReader.Read())
                {
                    var donorDonation = new DonorDonation();
                    int id = dataReader.GetInt32(0);
                    donorDonation.FirstName = dataReader.GetString(1);
                    donorDonation.LastName = dataReader.GetString(2);
                    donorDonation.DonationAmount = dataReader.GetDecimal(3);

                    donorDonations.Add(donorDonation);
                }

                //close connection
                this.CloseConnection();
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
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
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

        //Close connection
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

        //Insert statement
        public void Insert(DonorDonation donation)
        {
            //open connection
            if (this.OpenConnection() == true)
            {
                MySqlCommand insertCommand = new MySqlCommand();

                // Fill SQL command parameters.
                insertCommand.Connection = connection;

                insertCommand.CommandType = System.Data.CommandType.Text;
                insertCommand.CommandText = "INSERT INTO donorDonations (firstName, lastName, donationAmount) VALUES(@firstName, @lastName, @donationAmount)";

                var firstNameParam = new MySqlParameter("@firstName", donation.FirstName);
                firstNameParam.DbType = System.Data.DbType.String;
                insertCommand.Parameters.Add(firstNameParam);

                var lastNameParam = new MySqlParameter("@lastName", donation.LastName);
                lastNameParam.DbType = System.Data.DbType.String;
                insertCommand.Parameters.Add(lastNameParam);

                var donationAmountParam = new MySqlParameter("@donationAmount", donation.DonationAmount);
                donationAmountParam.DbType = System.Data.DbType.Decimal;
                insertCommand.Parameters.Add(donationAmountParam);

                //Execute command
                insertCommand.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }


    }
}