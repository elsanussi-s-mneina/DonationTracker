namespace DonationTracker.Desktop
{
  public interface ITextResources
  {
    string FirstNameLabel { get; }
    string LastNameLabel { get; }
    string DonationAmountLabel { get; }
    string AddInformationButton { get; }
    string DonorAdditionWindowTitle { get; }
    string FirstNameIsMissing { get; }
    string LastNameIsMissing { get; }
    string AmountIsMissing { get; }
    string SavingDonorInformationSucceeded { get; }
    string MostRecentlySavedRecord { get; }
    string SavingDonorInformationFailed { get; }
    string AmountMustBeANumber { get; }
  }
}