using System.Collections.Generic;
using AutoMapper;

namespace DonationTracker.Service
{
    public interface IServiceOperations
    {
        void AddDonor(DonorDonation donation);
        IList<DonorDonationTotalByDonor> CalculatePerDonorTotalDonationAmount();
        decimal CalculateTotalDonationAmount();
        int? GetIDOfMatchingDonor(DonorQuery donorQuery);
        IList<DonorDonation> ReadAllDonors();
        IList<DonorDonation> ReadSubsetOfDonors(int offset, int limit);
        IMapper SetupObjectToObjectMappings();
    }
}