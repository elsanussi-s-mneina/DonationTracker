using System;
using DonationTracker.Service;
using Eto.Forms;
using Eto.Serialization.Xaml;

namespace DonationTracker.Desktop
{
  public class DonorAdditionWindow : Form
  {
    private readonly DesktopOperations operations;
    private readonly ITextResources textResources;

    TextBox FirstNameTextBox = null;
    TextBox LastNameTextBox = null;
    TextBox AmountTextBox = null;
    Label FirstNameLabel = null;
    Label LastNameLabel = null;
    Label DonationAmountLabel = null;
    Button AddInformationButton = null;
    Label ValidationMessage = null;
    Label MostRecentlySavedLabel = null;

    public DonorAdditionWindow(
      DesktopOperations operations,
      ITextResources textResources)
    {
      this.operations = operations;
      this.textResources = textResources;
      XamlReader.Load(this);
      Title = textResources.DonorAdditionWindowTitle;
      FirstNameLabel.Text = textResources.FirstNameLabel;
      LastNameLabel.Text = textResources.LastNameLabel;
      DonationAmountLabel.Text = textResources.DonationAmountLabel;
      AddInformationButton.Text = textResources.AddInformationButton;

    }

    private void ClearValidationMessage()
    {
      ValidationMessage.Text = string.Empty;
    }

    protected void FirstNameGotFocus(object sender, EventArgs e)
    {
      ClearValidationMessage();
    }
    protected void TryAddDonor(object sender, EventArgs e)
    {
      ClearValidationMessage();

      if (string.IsNullOrWhiteSpace(FirstNameTextBox.Text))
      {
        ValidationMessage.Text += textResources.FirstNameIsMissing;
      }

      if (string.IsNullOrWhiteSpace(LastNameTextBox.Text))
      {
        ValidationMessage.Text += textResources.LastNameIsMissing;
      }

      if (string.IsNullOrWhiteSpace(AmountTextBox.Text))
      {
        ValidationMessage.Text += textResources.AmountIsMissing;
      }
      else
      {
        decimal amount;
        if (decimal.TryParse(AmountTextBox.Text, out amount))
        {
          try
          {
            operations.AddDonor(new Model.DonorDonation(
              FirstNameTextBox.Text,
              LastNameTextBox.Text,
              amount
              ));
            ValidationMessage.Text = textResources.SavingDonorInformationSucceeded;
            MostRecentlySavedLabel.Text = textResources.MostRecentlySavedRecord
              + "\n" + textResources.FirstNameLabel +
               FirstNameTextBox.Text + "\n"
               + textResources.LastNameLabel + LastNameTextBox.Text + "\n" +
               textResources.DonationAmountLabel
               + amount.ToString();
            FirstNameTextBox.Text = "";
            LastNameTextBox.Text = "";
            AmountTextBox.Text = "";
          }
          catch (ServiceLayerException)
          {
            ValidationMessage.Text = textResources.SavingDonorInformationFailed;
          }
        }
        else
        {
          ValidationMessage.Text += textResources.AmountMustBeANumber;
        }
      }
    }
  }
}
