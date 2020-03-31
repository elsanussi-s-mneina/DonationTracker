using System.Collections.Generic;
using DonationTracker.Service;

namespace DonationTracker.Desktop
{
    public class DesktopOperations
    {
        ServiceOperations donationService;

        public DesktopOperations()
        {
            donationService = new ServiceOperations();
        }

        public void AddDonor(Desktop.Model.DonorDonation donation)
        {
            var sDonation = new Service.DonorDonation
            {
                FirstName = donation.FirstName,
                LastName = donation.LastName,
                DonationAmount = donation.DonationAmount
            };

            donationService.AddDonor(sDonation);
        }

        public IList<Desktop.Model.DonorDonation> ReadAllDonors()
        {
            var donorDonations1 = donationService.ReadAllDonors();

            IList<Desktop.Model.DonorDonation> donorDonations2 =
                new List<Desktop.Model.DonorDonation>();

            foreach (DonorDonation d in donorDonations1)
            {
                Desktop.Model.DonorDonation d2 = new Model.DonorDonation
                {
                    FirstName = d.FirstName,
                    LastName = d.LastName,
                    DonationAmount = d.DonationAmount
                };

                donorDonations2.Add(d2);
            }

            return donorDonations2;
        }


        public IList<Desktop.Model.DonorDonationTotalByDonor>
            CalculatePerDonorTotalDonationAmount()
        {
            var donorDonations1 = donationService.CalculatePerDonorTotalDonationAmount();

            IList<Desktop.Model.DonorDonationTotalByDonor> donorDonations2 =
                new List<Desktop.Model.DonorDonationTotalByDonor>();

            foreach (DonorDonationTotalByDonor d in donorDonations1)
            {
                Desktop.Model.DonorDonationTotalByDonor d2 = new Model.DonorDonationTotalByDonor
                {
                    FirstName = d.FirstName,
                    LastName = d.LastName,
                    TotalDonationAmount = d.TotalDonationAmount
                };

                donorDonations2.Add(d2);
            }

            return donorDonations2;
        }

        public decimal CalculateTotalDonationAmount()
        {
            decimal total = donationService.CalculateTotalDonationAmount();

            return total;
        }

        public int? GetIDOfMatchingDonor(DonorQuery donorQuery)
        {
            return donationService.GetIDOfMatchingDonor(donorQuery);
        }

    }
}
