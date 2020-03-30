using System;
using System.Collections.Generic;
using DonationTracker.Integration;
namespace DonationTracker.Service
{
    public class ServiceOperations
    {
        IntegrationOperations operations;

        public ServiceOperations()
        {
            operations = new IntegrationOperations();
        }

        public void AddDonor(DonorDonation donation)
        {
            try
            {
                var donation2 = new Integration.DonorDonation();
                donation2.FirstName = donation.FirstName;
                donation2.LastName = donation.LastName;
                donation2.DonationAmount = donation.DonationAmount;

                operations.AddDonor(donation2);
            }
            catch (IntegrationLayerException exception)
            {
                throw new ServiceLayerException(exception);
            }
            catch (Exception exception)
            {
                throw new ServiceLayerException("Something went wrong at the service layer", exception);
            }
        }

        public IList<DonorDonation> ReadAllDonors()
        {
            IList<DonorDonation> donorDonations = new List<DonorDonation>();

            IList<Integration.DonorDonation> donorDonations2 =
                operations.ReadAllDonors();

            foreach (var donorDonation in donorDonations2)
            {
                var current = new DonorDonation();
                current.FirstName = donorDonation.FirstName;
                current.LastName = donorDonation.LastName;
                current.DonationAmount = donorDonation.DonationAmount;

                donorDonations.Add(current);
            }

            return donorDonations;
        }
    }
}
