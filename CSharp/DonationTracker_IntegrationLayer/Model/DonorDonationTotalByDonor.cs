namespace DonationTracker.Integration
{
    public class DonorDonation
    {
        public string FirstName { get; }

        public string LastName { get; }

        public decimal DonationAmount { get; }

        public DonorDonation(
            string firstName,
            string lastName,
            decimal donationAmount)
        {
            FirstName = firstName;
            LastName = lastName;
            DonationAmount = donationAmount;
        }
    }
}
