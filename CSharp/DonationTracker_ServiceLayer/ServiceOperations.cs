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

        private IList<DonorDonation> ConvertDonorDonationsFrom(IList<Integration.DonorDonation> donorDonationsIn)
        {
            IList<DonorDonation> donorDonationsOut = new List<DonorDonation>();

            foreach (var donorDonation in donorDonationsIn)
            {
                var current = new DonorDonation();
                current.FirstName = donorDonation.FirstName;
                current.LastName = donorDonation.LastName;
                current.DonationAmount = donorDonation.DonationAmount;

                donorDonationsOut.Add(current);
            }

            return donorDonationsOut;
        }

        public IList<DonorDonation> ReadAllDonors()
        {

            IList<Integration.DonorDonation> donorDonations =
                operations.ReadAllDonors();

            return ConvertDonorDonationsFrom(donorDonations);
        }


        public IList<DonorDonation> ReadSubsetOfDonors(int offset, int limit)
        {
            IList<Integration.DonorDonation> donorDonations = operations.ReadSubsetOfDonors(offset, limit);
            return ConvertDonorDonationsFrom(donorDonations);
        }



        public IList<DonorDonationTotalByDonor> CalculatePerDonorTotalDonationAmount()
        {
            IList<DonorDonationTotalByDonor> donorDonations = new List<DonorDonationTotalByDonor>();

            IList<Integration.DonorDonationTotalByDonor> donorDonations2 =
                operations.CalculatePerDonorTotalDonationAmount();

            foreach (var donorDonation in donorDonations2)
            {
                var current = new DonorDonationTotalByDonor();
                current.FirstName = donorDonation.FirstName;
                current.LastName = donorDonation.LastName;
                current.TotalDonationAmount = donorDonation.TotalDonationAmount;

                donorDonations.Add(current);
            }

            return donorDonations;
        }

        public int? GetIDOfMatchingDonor(DonorQuery donorQuery)
        {

            var donorQuery2 = new Integration.DonorQuery();
            donorQuery2.FirstName = donorQuery.FirstName;
            donorQuery2.LastName = donorQuery.LastName;


            return operations.GetIDOfMatchingDonor(donorQuery2);
        }

        public decimal CalculateTotalDonationAmount()
        {
            decimal total = operations.CalculateTotalDonationAmount();

            return total;
        }
    }
}
