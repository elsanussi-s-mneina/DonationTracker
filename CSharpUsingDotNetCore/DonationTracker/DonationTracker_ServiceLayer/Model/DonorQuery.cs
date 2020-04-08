﻿namespace DonationTracker.Service
{
    public class DonorQuery
    {
        public string FirstName { get; }

        public string LastName { get; }

        public DonorQuery(
            string firstName,
            string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
