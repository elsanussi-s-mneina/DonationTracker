using System.Collections.Generic;
using AutoMapper;
using DonationTracker.Service;

namespace DonationTracker.Desktop
{
    public class DesktopOperations
    {
        private readonly ServiceOperations donationService;
        private readonly IMapper mapper;

        public DesktopOperations(
            ServiceOperations donationService,
            IMapper mapper)
        {
            this.donationService = donationService;
            this.mapper = mapper;
        }

        public void AddDonor(Desktop.Model.DonorDonation donation)
        {
            Service.DonorDonation sDonation
               = mapper.Map<Desktop.Model.DonorDonation
                           ,Service.DonorDonation>(donation);
            donationService.AddDonor(sDonation);
        }


        private IList<Desktop.Model.DonorDonation> ConvertDonorDonationsFrom(IList<Service.DonorDonation> donorDonationsIn)
        {

            IList<Desktop.Model.DonorDonation> donorDonationsOut =
              mapper.Map<IList<Service.DonorDonation>
                        , IList<Desktop.Model.DonorDonation>>(donorDonationsIn);
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
            donorDonations2 = mapper.Map<
                 IList<DonorDonationTotalByDonor>
               , IList<Desktop.Model.DonorDonationTotalByDonor>>(donorDonations1);
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