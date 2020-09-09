using System.Collections.Generic;

namespace DonationTracker.Desktop
{
  public class TextResources : ITextResources
  {
    public TextResources(string[] lines)
    {
      int i = 0;
      FirstNameLabel = lines[i++];
      LastNameLabel = lines[i++];
      DonationAmountLabel = lines[i++];
      AddInformationButton = lines[i++];
      DonorAdditionWindowTitle = lines[i++];
      FirstNameIsMissing = lines[i++];
      LastNameIsMissing = lines[i++];
      AmountIsMissing = lines[i++];
      SavingDonorInformationSucceeded = lines[i++];
      MostRecentlySavedRecord = lines[i++];
      SavingDonorInformationFailed = lines[i++];
      AmountMustBeANumber = lines[i++];
      DonationTrackerFormTitle = lines[i++];
      PreviousPageButton = lines[i++];
      NextPageButton = lines[i++];
      ShowAllDonationsButton = lines[i++];
      ShowDonationsPagedButton = lines[i++];
      ShowPerDonorTotalDonationsButton = lines[i++];
      PreferencesButtonMenuItem = lines[i++];
      QuitButtonMenuItem = lines[i++];
      AboutButtonMenuItem = lines[i++];
      AddDonorsButtonToolItem = lines[i++];
      CalculateTotalDonationAmountButtonToolItem = lines[i++];
      DonationsPagePrefix = lines[i++];
      DonationsPageSuffix = lines[i++];
      AllDonationsTitle = lines[i++];
      FirstNameHeader = lines[i++];
      LastNameHeader = lines[i++];
      AmountHeader = lines[i++];
      TotalPrefix = lines[i++];
      TotalAmountHeader = lines[i++];
      TotalAmountPerDonorTitle = lines[i++]; 
    }

    public string FirstNameLabel { get; } = "First Name:";

    public string LastNameLabel { get; } = "Last Name:";

    public string DonationAmountLabel { get; } = "Donation Amount:";

    public string AddInformationButton { get; } = "Add";

    public string DonorAdditionWindowTitle { get; } = "Donation Entry Form";

    public string FirstNameIsMissing { get; } = "A first name is missing! You must specify the first name.";

    public string LastNameIsMissing { get; } = "The last name is missing! You must specify the last name.";

    public string AmountIsMissing { get; } = "An amount is missing! You must specify the amount.";

    public string SavingDonorInformationSucceeded { get; } = "Saving the donor information succeeded!";

    public string MostRecentlySavedRecord { get; } = "Most Recently Saved Record:";

    public string SavingDonorInformationFailed { get; } = "Sorry, something unusual happened; saving the donor information failed!";

    public string AmountMustBeANumber { get; } = "The amount must be a number!";

    public string DonationTrackerFormTitle { get; } = "Donation Tracker";
    public string PreviousPageButton { get; } = "← Previous Page";

    public string NextPageButton { get; } = "Next Page →";
    public string ShowAllDonationsButton { get; } = "Show All Donations";
    public string ShowDonationsPagedButton { get; } = "Show Donations (One page at a time)";
    public string ShowPerDonorTotalDonationsButton { get; } = "Show Per Donor Total Donations";

    public string PreferencesButtonMenuItem { get; } = "Preferences..";
    public string QuitButtonMenuItem { get; } = "Quit";
    public string AboutButtonMenuItem { get; } = "About...";
    public string AddDonorsButtonToolItem { get; } = "✎ Add Donors…";
    public string CalculateTotalDonationAmountButtonToolItem { get; } = "∑ Calculate Total Donation Amount";

    public string DonationsPagePrefix { get; } = "Donations (Page ";
    public string DonationsPageSuffix { get; } = " ) ";
    public string AllDonationsTitle { get; } = "All Donations";
    public string FirstNameHeader { get; } = "First Name";
    public string LastNameHeader { get; } = "Last Name";
    public string AmountHeader { get; } = "Amount";
    public string TotalPrefix { get; } = "Total: ";
    public string TotalAmountHeader { get; } = "Total Amount";
    public string TotalAmountPerDonorTitle { get; } = "Donation Total Amount Per Donor";

    public IEnumerable<string> AsLines
    {
      get
      {
        return new List<string>
        {
       FirstNameLabel
 ,     LastNameLabel
 ,     DonationAmountLabel
 ,     AddInformationButton
 ,     DonorAdditionWindowTitle
 ,     FirstNameIsMissing
 ,     LastNameIsMissing
 ,     AmountIsMissing
 ,     SavingDonorInformationSucceeded
 ,     MostRecentlySavedRecord
 ,     SavingDonorInformationFailed
 ,     AmountMustBeANumber
 ,     DonationTrackerFormTitle
 ,     PreviousPageButton
 ,     NextPageButton 
 ,     ShowAllDonationsButton
 ,     ShowDonationsPagedButton
 ,     ShowPerDonorTotalDonationsButton 
 ,     PreferencesButtonMenuItem
 ,     QuitButtonMenuItem
 ,     AboutButtonMenuItem 
 ,     AddDonorsButtonToolItem 
 ,     CalculateTotalDonationAmountButtonToolItem
 ,     DonationsPagePrefix
 ,     DonationsPageSuffix
 ,     AllDonationsTitle
 ,     FirstNameHeader
 ,     LastNameHeader
 ,     AmountHeader
 ,     TotalPrefix
 ,     TotalAmountHeader
 ,     TotalAmountPerDonorTitle
        };
      }
    }
  }
}
