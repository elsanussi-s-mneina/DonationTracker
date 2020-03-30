﻿using System;
using System.Collections.Generic;

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

            Console.WriteLine("Writing record to database...");
            databaseBridge.Insert(donation);

        }

        public IList<DonorDonation> ReadAllDonors()
        {
            return databaseBridge.ReadAllDonors();
        }

        public decimal CalculateTotalDonationAmount()
        {
            return databaseBridge.CalculateTotalDonationAmount();
        }
    }
}