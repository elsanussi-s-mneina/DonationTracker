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
    }
}
