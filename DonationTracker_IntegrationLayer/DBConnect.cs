using System;
using System.Collections.Generic;
using Npgsql;

namespace DonationTracker.Integration
{
    public class DBConnect
    {
        // The following article is a useful tutorial to help understand
        // this code:
        // https://www.codeproject.com/Articles/43438/Connect-C-to-MySQL
        // Some of the code here is patterned after the code in the tutorial.

        private NpgsqlConnection connection;
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
            database = "donation_tracking";
            uid = "donation_tracker_user";
            password = "secret1secret";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
                database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new NpgsqlConnection(connectionString);

        }

        internal decimal CalculateTotalDonationAmount()
        {
            decimal total = 0;
            if (OpenConnection())
            {
                NpgsqlCommand command = new NpgsqlCommand();

                command.Connection = connection;

                command.CommandType = System.Data.CommandType.Text;
                command.CommandText =
                    "SELECT COALESCE(SUM(donation_amount),0) FROM donor_donations;";


                NpgsqlDataReader dataReader = command.ExecuteReader();

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
                NpgsqlCommand command = new NpgsqlCommand();

                command.Connection = connection;

                command.CommandType = System.Data.CommandType.Text;
                command.CommandText =
                    "SELECT id, first_name, last_name, donation_amount FROM donor_donations;";


                NpgsqlDataReader dataReader = command.ExecuteReader();

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
                NpgsqlCommand command = new NpgsqlCommand();

                command.Connection = connection;

                command.CommandType = System.Data.CommandType.Text;
                command.CommandText =
                    "SELECT id, first_name, last_name, SUM(donation_amount) FROM donor_donations GROUP BY id;";


                NpgsqlDataReader dataReader = command.ExecuteReader();

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
            catch (NpgsqlException ex)
            {
                throw new IntegrationLayerException(ex);
            }

        }

        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public void Insert(DonorDonation donation)
        {
            if (OpenConnection())
            {
                NpgsqlCommand insertCommand = new NpgsqlCommand();

                insertCommand.Connection = connection;

                insertCommand.CommandType = System.Data.CommandType.Text;
                insertCommand.CommandText =
                    "INSERT INTO donor_donations (first_name, last_name, donation_amount) VALUES(@first_name, @last_name, @donation_amount)";

                var firstNameParam = new NpgsqlParameter("@first_name", donation.FirstName);
                firstNameParam.DbType = System.Data.DbType.String;
                insertCommand.Parameters.Add(firstNameParam);

                var lastNameParam = new NpgsqlParameter("@last_name", donation.LastName);
                lastNameParam.DbType = System.Data.DbType.String;
                insertCommand.Parameters.Add(lastNameParam);

                var donationAmountParam = new NpgsqlParameter("@donation_amount", donation.DonationAmount);
                donationAmountParam.DbType = System.Data.DbType.Decimal;
                insertCommand.Parameters.Add(donationAmountParam);

                insertCommand.ExecuteNonQuery();

                CloseConnection();
            }
        }


    }
}