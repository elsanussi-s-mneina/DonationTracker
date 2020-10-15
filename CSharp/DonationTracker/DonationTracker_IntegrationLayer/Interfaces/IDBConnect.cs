using System.Collections.Generic;

namespace DonationTracker.Integration
{
	public interface IDBConnect
	{
		IList<DonorDonationTotalByDonor> CalculatePerDonorTotalDonationAmount();
		decimal CalculateTotalDonationAmount();
		int? GetIDOfMatchingDonor(DonorQuery donorQuery);
		void Insert(DonorDonation donation);
		IList<DonorDonation> ReadAllDonors();
		IList<DonorDonation> ReadAllDonorsPagination(int offset, int limit);
	}
}