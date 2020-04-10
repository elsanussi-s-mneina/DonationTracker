﻿using System.Collections.Generic;
using DonationTracker.Service;

namespace DonationTracker.Desktop
{
    public class DesktopOperations
    {
        private readonly ServiceOperations donationService;

        public DesktopOperations()
        {
            donationService = new ServiceOperations();
        }

        public void AddDonor(Desktop.Model.DonorDonation donation)
        {
            var sDonation = new Service.DonorDonation
            (
                firstName: donation.FirstName,
                lastName: donation.LastName,
                donationAmount: donation.DonationAmount
            );

            donationService.AddDonor(sDonation);
        }


        private IList<Desktop.Model.DonorDonation> ConvertDonorDonationsFrom(IList<Service.DonorDonation> donorDonationsIn)
        {

            IList<Desktop.Model.DonorDonation> donorDonationsOut =
                new List<Desktop.Model.DonorDonation>();

            foreach (DonorDonation d in donorDonationsIn)
            {
                Desktop.Model.DonorDonation d2 = new Model.DonorDonation
                (
                    firstName: d.FirstName,
                    lastName: d.LastName,
                    donationAmount: d.DonationAmount
                );

                donorDonationsOut.Add(d2);
            }

            return donorDonationsOut;
        }


        public IList<Desktop.Model.DonorDonation> ReadAllDonors()
        {
            var donorDonations = donationService.ReadAllDonors();

            return ConvertDonorDonationsFrom(donorDonations);
        }


        public IList<Desktop.Model.DonorDonation> ReadSubsetOfDonors(int offset, int limit)
        {
            var donorDonations = donationService.ReadSubsetOfDonors(offset, limit);

            return ConvertDonorDonationsFrom(donorDonations);
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
                (
                    firstName: d.FirstName,
                    lastName: d.LastName,
                    totalDonationAmount: d.TotalDonationAmount
                );

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