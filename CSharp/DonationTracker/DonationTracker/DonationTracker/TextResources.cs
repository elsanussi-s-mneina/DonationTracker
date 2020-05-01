namespace DonationTracker.Desktop
{
  public class TextResources : ITextResources
  {
    public TextResources()
    {
    }

    public string FirstNameLabel { get; } = "First Name:";

    public string LastNameLabel { get; } = "Last Name:";

    public string DonationAmountLabel { get; } = "Donation Amount:";

    public string AddInformationButton { get; } = "Add";

    public string DonorAdditionWindowTitle { get; } = "Donation Entry Form";

    public string FirstNameIsMissing { get; } = "A first name is missing! You must specify the first name.\n";

    public string LastNameIsMissing { get; } = "The last name is missing! You must specify the last name.\n";

    public string AmountIsMissing { get; } = "An amount is missing! You must specify the amount.\n";

    public string SavingDonorInformationSucceeded { get; } = "Saving the donor information succeeded!";

    public string MostRecentlySavedRecord { get; } = "Most Recently Saved Record:\n";

    public string SavingDonorInformationFailed { get; } = "Sorry, something unusual happened; saving the donor information failed!\n";

    public string AmountMustBeANumber { get; } = "The amount must be a number!";


  }
}
