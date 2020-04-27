using System;
using DonationTracker.Service;
using Eto.Forms;
using Eto.Serialization.Xaml;

namespace DonationTracker.Desktop
{
  public class DonorAdditionWindow : Form
  {
    private readonly DesktopOperations operations;


    TextBox FirstNameTextBox = null;
    TextBox LastNameTextBox = null;
    TextBox AmountTextBox = null;

    Label ValidationMessage = null;
    Label MostRecentlySavedLabel = null;

    public DonorAdditionWindow(DesktopOperations operations)
    {
      this.operations = operations;
      XamlReader.Load(this);
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
        ValidationMessage.Text += "A first name is missing! You must specify the first name.\n";
      }

      if (string.IsNullOrWhiteSpace(LastNameTextBox.Text))
      {
        ValidationMessage.Text += "The last name is missing! You must specify the last name.\n";
      }

      if (string.IsNullOrWhiteSpace(AmountTextBox.Text))
      {
        ValidationMessage.Text += "An amount is missing! You must specify the amount.\n";
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
            ValidationMessage.Text = "Saving the donor information succeeded!";
            MostRecentlySavedLabel.Text = "Most Recently Saved Record:\nFirst Name:" +
               FirstNameTextBox.Text + " \nLast Name: " + LastNameTextBox.Text + " \n Amount:"
               + amount.ToString();
            FirstNameTextBox.Text = "";
            LastNameTextBox.Text = "";
            AmountTextBox.Text = "";
          }
          catch (ServiceLayerException)
          {
            ValidationMessage.Text = "Sorry, something unusual happened; saving the donor information failed!\n";
          }
        }
        else
        {
          ValidationMessage.Text += "The amount must be a number!";
        }
      }
    }
  }
}
