using System.Collections.Generic;

namespace DonationTracker.Integration
{
    public interface IIntegrationOperations
    {
        void AddDonor(DonorDonation donation);
        IList<DonorDonationTotalByDonor> CalculatePerDonorTotalDonationAmount();
        decimal CalculateTotalDonationAmount();
        int? GetIDOfMatchingDonor(DonorQuery donorQuery2);
        IList<DonorDonation> ReadAllDonors();
        IList<DonorDonation> ReadSubsetOfDonors(int offset, int limit);
    }
}