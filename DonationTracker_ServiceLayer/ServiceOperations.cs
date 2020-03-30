using System;
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
    }
}
