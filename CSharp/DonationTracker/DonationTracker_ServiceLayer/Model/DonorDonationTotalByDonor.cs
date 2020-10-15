namespace DonationTracker.Service
{
	public class DonorDonationTotalByDonor
	{
		public string FirstName { get; }

		public string LastName { get; }

		public decimal TotalDonationAmount { get; }

		public DonorDonationTotalByDonor(
			string firstName,
			string lastName,
			decimal totalDonationAmount)
		{
			FirstName = firstName;
			LastName = lastName;
			TotalDonationAmount = totalDonationAmount;
		}
	}
}
