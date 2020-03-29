using System;
using DonationTracker.Desktop.Model;
using Gtk;

namespace DonationTracker.Desktop
{
    public partial class DonorAdditionWindow : Gtk.Window
    {
        private DesktopOperations operations;

        public DonorAdditionWindow(DesktopOperations operations) :
                base(Gtk.WindowType.Toplevel)
        {
            this.operations = operations;
            this.Build();
        }

        protected void AddDonor(object sender, EventArgs e)
        {
            var donorDonation = new DonorDonation();

            decimal conversionResult;

            donorDonation.FirstName = FirstNameTextBox.Text;
            donorDonation.LastName = LastNameTextBox.Text;

            if (decimal.TryParse(AmountTextBox.Text, out conversionResult))
            {
                donorDonation.DonationAmount = conversionResult;
                operations.AddDonor(donorDonation);

                FirstNameTextBox.Text = string.Empty;
                LastNameTextBox.Text = string.Empty;
                AmountTextBox.Text = string.Empty;
            }
            else
            {
                MessageDialog md = new MessageDialog(this,
                    DialogFlags.DestroyWithParent, MessageType.Error,
                    ButtonsType.Close, "Please double check the amount and try again.");
                md.Run();
                md.Destroy();
            }

        }
    }
}
