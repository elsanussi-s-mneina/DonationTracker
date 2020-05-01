using System.Collections.Generic;

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
    string DonationTrackerFormTitle { get; }
    string PreviousPageButton { get; }
    string NextPageButton { get; }
    string ShowAllDonationsButton { get; }
    string ShowDonationsPagedButton { get; }
    string ShowPerDonorTotalDonationsButton { get; }
    string PreferencesButtonMenuItem { get; }
    string QuitButtonMenuItem { get; }
    string AboutButtonMenuItem { get; }
    string AddDonorsButtonToolItem { get; }
    string CalculateTotalDonationAmountButtonToolItem { get; }
    string DonationsPagePrefix { get; }
    string DonationsPageSuffix { get; }
    string AllDonationsTitle { get; }
    string FirstNameHeader { get; }
    string LastNameHeader { get; }
    string AmountHeader { get; }
    string TotalPrefix { get; }
    string TotalAmountHeader { get; }
    string TotalAmountPerDonorTitle { get; }
    IEnumerable<string> AsLines { get; }
  }
}