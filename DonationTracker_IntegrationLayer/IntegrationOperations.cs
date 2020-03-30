using System;
namespace DonationTracker.Integration
{
    public class IntegrationOperations
    {
        DBConnect databaseBridge;

        public IntegrationOperations()
        {
            databaseBridge = new DBConnect();
        }

        public void AddDonor(DonorDonation donation)
        {
            Console.WriteLine("Donation received in Integration Module.");

            Console.WriteLine("First Name: " + donation.FirstName);
            Console.WriteLine("Last Name: " + donation.LastName);
            Console.WriteLine("Amount: " + donation.DonationAmount);

            Console.WriteLine("Persistance of data has not been implemented yet!");

            databaseBridge.Insert();

        }
    }
}
