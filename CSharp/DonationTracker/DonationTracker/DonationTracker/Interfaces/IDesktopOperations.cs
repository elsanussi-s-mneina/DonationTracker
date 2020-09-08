using System.Collections.Generic;

namespace DonationTracker.Desktop
{
    public interface IDesktopOperations
    {
        void AddDonor(Model.DonorDonation donation);
        IList<Model.DonorDonationTotalByDonor> CalculatePerDonorTotalDonationAmount();
        decimal CalculateTotalDonationAmount();
        int? GetIDOfMatchingDonor(Service.DonorQuery donorQuery);
        IList<Model.DonorDonation> ReadAllDonors();
        IList<Model.DonorDonation> ReadSubsetOfDonors(int offset, int limit);
    }
}