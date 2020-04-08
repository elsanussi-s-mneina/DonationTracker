using System;
using DonationTracker.Service;
using Gtk;

namespace DonationTracker.Desktop
{
    public partial class DonorAdditionWindow : Gtk.Window
    {
        private readonly DesktopOperations operations;

        public DonorAdditionWindow(DesktopOperations operations) :
                base(Gtk.WindowType.Toplevel)
        {
            this.operations = operations;
            this.Build();
        }

        protected bool ValidateFirstName(object sender, EventArgs e)
        {
            string firstNameText = FirstNameTextBox.Text;
            bool failedValidation = false;

            if (firstNameText.Equals(string.Empty))
            {
                WarnUser("The first name should not be empty. Enter a first name.");
                failedValidation = true;
            }
            else if (firstNameText.Trim().Equals(""))
            {
                WarnUser("The first name should not be only spaces. Enter a first name.");
                failedValidation = true;
            }

            if (firstNameText.Contains("="))
            {
                WarnUser("The first name must not contain an equal sign.");
                failedValidation = true;
            }

            return !failedValidation;
        }

        protected void AddDonor(object sender, EventArgs e)
        {
            if (!ValidateFirstName(null, null))
            {
                return;
            }


            decimal conversionResult;

            string firstName = FirstNameTextBox.Text;
            string lastName = LastNameTextBox.Text;

            if (decimal.TryParse(AmountTextBox.Text, out conversionResult))
            {
                decimal donationAmount = conversionResult;
                try
                {
                    var donorDonation = new Model.DonorDonation
                    (
                        firstName: firstName,
                        lastName: lastName,
                        donationAmount: donationAmount
                    );

                    operations.AddDonor(donorDonation);
                    FirstNameTextBox.Text = string.Empty;
                    LastNameTextBox.Text = string.Empty;
                    AmountTextBox.Text = string.Empty;
                }
                catch (ServiceLayerException exception)
                {
                    InformUserOfError("Sorry that did not work, something is wrong.");
                    Console.WriteLine(exception);
                }
                catch (Exception exception)
                {
                    InformUserOfError("Sorry that did not work, something is wrong. (2)");
                    Console.WriteLine(exception);
                }

            }
            else
            {
                WarnUser("Please double check the amount and try again.");
            }

        }

        private void WarnUser(string message)
        {
            MessageDialog md = new MessageDialog(this,
                DialogFlags.DestroyWithParent, MessageType.Warning,
                ButtonsType.Close, message);
            md.Run();
            md.Destroy();
        }

        private void InformUserOfError(string message)
        {
            MessageDialog md = new MessageDialog(this,
                DialogFlags.DestroyWithParent, MessageType.Error,
                ButtonsType.Close, message);
            md.Run();
            md.Destroy();
        }

        protected void Cancel(object sender, EventArgs e)
        {
            // close window
            Destroy();
        }
    }
}
