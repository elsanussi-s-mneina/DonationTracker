using Npgsql;

using System;
using System.Collections.Generic;

namespace DonationTracker.Integration
{
    public class DBConnect : IDBConnect
    {
        private readonly NpgsqlConnection connection;

        public DBConnect(string connectionString)
        {
            connection = new NpgsqlConnection(connectionString);
        }

        public decimal CalculateTotalDonationAmount()
        {
            decimal total = 0;
            if (OpenConnection())
            {
                NpgsqlCommand command = new NpgsqlCommand();

                command.Connection = connection;

                command.CommandType = System.Data.CommandType.Text;
                command.CommandText =
                    "SELECT COALESCE(SUM(donation_amount),0) FROM donation;";


                NpgsqlDataReader dataReader = command.ExecuteReader();

                dataReader.Read();
                total = dataReader.GetDecimal(0);

                CloseConnection();
            }

            return total;
        }

        public int? GetIDOfMatchingDonor(DonorQuery donorQuery)
        {
            int? id = null;
            if (OpenConnection())
            {
                NpgsqlCommand command = new NpgsqlCommand();

                command.Connection = connection;

                command.CommandType = System.Data.CommandType.Text;
                command.CommandText =
                    "SELECT id FROM donor WHERE first_name = @first_name AND last_name = @last_name;";


                var firstNameParam = new NpgsqlParameter("@first_name", donorQuery.FirstName);
                firstNameParam.DbType = System.Data.DbType.String;
                command.Parameters.Add(firstNameParam);

                var lastNameParam = new NpgsqlParameter("@last_name", donorQuery.LastName);
                lastNameParam.DbType = System.Data.DbType.String;
                command.Parameters.Add(lastNameParam);

                NpgsqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    id = dataReader.GetInt32(0);
                }

                CloseConnection();
            }

            return id;
        }

        public IList<DonorDonation> ReadAllDonors()
        {

            IList<DonorDonation> donorDonations = new List<DonorDonation>();

            if (OpenConnection())
            {
                NpgsqlCommand command = new NpgsqlCommand();

                command.Connection = connection;

                command.CommandType = System.Data.CommandType.Text;
                command.CommandText =
                    "SELECT donor.id, donor.first_name, donor.last_name, donation.donation_amount FROM donation INNER JOIN donor ON donation.donor_id = donor.id;";


                NpgsqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    int id = dataReader.GetInt32(0);
                    string firstName = dataReader.GetString(1);
                    string lastName = dataReader.GetString(2);
                    decimal donationAmount = dataReader.GetDecimal(3);

                    var donorDonation = new DonorDonation
                    (
                        firstName: firstName,
                        lastName: lastName,
                        donationAmount: donationAmount
                    );

                    donorDonations.Add(donorDonation);
                }

                CloseConnection();
            }

            return donorDonations;

        }

        public IList<DonorDonation> ReadAllDonorsPagination(int offset, int limit)
        {
            IList<DonorDonation> donorDonations = new List<DonorDonation>();

            if (OpenConnection())
            {
                NpgsqlCommand command = new NpgsqlCommand();

                command.Connection = connection;

                command.CommandType = System.Data.CommandType.Text;
                command.CommandText =
                    "SELECT donor.id, donor.first_name, donor.last_name, donation.donation_amount FROM donation INNER JOIN donor ON donation.donor_id = donor.id LIMIT @limit OFFSET @offset;";


                var offsetParameter = new NpgsqlParameter("@offset", offset);
                offsetParameter.DbType = System.Data.DbType.Int32;
                command.Parameters.Add(offsetParameter);

                var limitParameter = new NpgsqlParameter("@limit", limit);
                limitParameter.DbType = System.Data.DbType.Int32;
                command.Parameters.Add(limitParameter);



                NpgsqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    int id = dataReader.GetInt32(0);
                    string firstName = dataReader.GetString(1);
                    string lastName = dataReader.GetString(2);
                    decimal donationAmount = dataReader.GetDecimal(3);

                    var donorDonation = new DonorDonation
                    (
                        firstName: firstName,
                        lastName: lastName,
                        donationAmount: donationAmount
                    );

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
                    "SELECT donor.id, first_name, last_name, SUM(donation_amount) FROM donation INNER JOIN donor ON donation.donor_id = donor.id GROUP BY donor.id;";


                NpgsqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    int id = dataReader.GetInt32(0);
                    string firstName = dataReader.GetString(1);
                    string lastName = dataReader.GetString(2);
                    decimal totalDonationAmount = dataReader.GetDecimal(3);
                    var donorDonation = new DonorDonationTotalByDonor
                    (
                        firstName: firstName,
                        lastName: lastName,
                        totalDonationAmount: totalDonationAmount
                    );

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
            int? id = GetIDOfMatchingDonor(
                     new DonorQuery(donation.FirstName, donation.LastName));


            if (id == null && OpenConnection())
            {
                NpgsqlCommand insertCommand = new NpgsqlCommand();

                insertCommand.Connection = connection;

                insertCommand.CommandType = System.Data.CommandType.Text;
                insertCommand.CommandText =
                    "INSERT INTO donor (first_name, last_name) VALUES(@first_name, @last_name) RETURNING id";

                var firstNameParam = new NpgsqlParameter("@first_name", donation.FirstName.Trim());
                firstNameParam.DbType = System.Data.DbType.String;
                insertCommand.Parameters.Add(firstNameParam);

                var lastNameParam = new NpgsqlParameter("@last_name", donation.LastName.Trim());
                lastNameParam.DbType = System.Data.DbType.String;
                insertCommand.Parameters.Add(lastNameParam);

                Object result = insertCommand.ExecuteScalar();
                id = (int)result;

                CloseConnection();
            }

            if (id != null && OpenConnection())
            {
                NpgsqlCommand insertCommand2 = new NpgsqlCommand();

                insertCommand2.Connection = connection;

                insertCommand2.CommandType = System.Data.CommandType.Text;
                insertCommand2.CommandText =
                    "INSERT INTO donation (donor_id, donation_amount) VALUES(@donor_id, @donation_amount)";


                var donorIDParam = new NpgsqlParameter("@donor_id", id);
                donorIDParam.DbType = System.Data.DbType.Int32;
                insertCommand2.Parameters.Add(donorIDParam);

                var donationAmountParam = new NpgsqlParameter("@donation_amount", donation.DonationAmount);
                donationAmountParam.DbType = System.Data.DbType.Decimal;
                insertCommand2.Parameters.Add(donationAmountParam);

                insertCommand2.ExecuteNonQuery();

                CloseConnection();
            }
        }


    }
}