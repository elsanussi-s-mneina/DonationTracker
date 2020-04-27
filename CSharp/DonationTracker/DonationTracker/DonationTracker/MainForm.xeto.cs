using System;
using System.Collections.Generic;
using Eto.Forms;
using Eto.Serialization.Xaml;
using DonationTracker.Desktop.Model;

namespace DonationTracker.Desktop
{
    public partial class MainForm : Form
    {
        private readonly DesktopOperations operations = new DesktopOperations();
        Label TotalDonationAmountLabel = null;
        Label TableTitleLabel = null;
        GridView DonorsTableView = null;
        Button PreviousPageButton = null;
        Button NextPageButton = null;

        // For pagination:
        // That is for returning only a limited number of records
        int startIndex = 0;
        int pageLength = 5;
        const string CURRENCY_SYMBOL_BEFORE = "$";

        public MainForm()
        {
            XamlReader.Load(this);
            OnShowTableButtonClicked(this, new EventArgs());
        }

        protected void ShowDonorAdditionWindow(object sender, EventArgs e)
        {
            var window = new DonorAdditionWindow(operations);
            window.Show();
        }

        protected void OnShowTableDonationPaginated(object sender, EventArgs e)
        {
            OnShowTable(() => { return operations.ReadSubsetOfDonors(startIndex, pageLength); });
            PreviousPageButton.Enabled = true;
            NextPageButton.Enabled = true;
            PreviousPageButton.Visible = true;
            NextPageButton.Visible = true;
            TableTitleLabel.Text = "Donations (Page "
               + (1 + (startIndex / pageLength)) + " ) ";
        }

        protected void OnShowTableButtonClicked(object sender, EventArgs e)
        {
            OnShowTable(operations.ReadAllDonors);
            TableTitleLabel.Text = "All Donations";
            PreviousPageButton.Enabled = false;
            NextPageButton.Enabled = false;
            PreviousPageButton.Visible = false;
            NextPageButton.Visible = false;
        }

        private void OnShowTable(Func<IList<DonorDonation>> queryFunction)
        {
            var donorDonations = queryFunction();

            ClearTable();
            DonorsTableView.DataStore = donorDonations;

            DonorsTableView.Columns.Add(new GridColumn
            {
                DataCell = new TextBoxCell { Binding = Binding.Property<Model.DonorDonation, string>(r => r.FirstName) },
                HeaderText = "First Name"
            });

            DonorsTableView.Columns.Add(new GridColumn
            {
                DataCell = new TextBoxCell { Binding = Binding.Property<Model.DonorDonation, string>(r => r.LastName) },
                HeaderText = "Last Name"
            });

            DonorsTableView.Columns.Add(new GridColumn
            {
                DataCell = new TextBoxCell { Binding = Binding.Property<Model.DonorDonation, string>(r => r.DonationAmount.ToString()) },
                HeaderText = "Amount"
            });
        }

        private string AddCurrencySymbol(decimal monetaryAmount)
        {
            return CURRENCY_SYMBOL_BEFORE + monetaryAmount;
        }

        protected void CalculateTotalDonationAmount(object sender, EventArgs e)
        {
            decimal totalDonationAmount = operations.CalculateTotalDonationAmount();
            TotalDonationAmountLabel.Text = "Total: "
                  + AddCurrencySymbol(totalDonationAmount);
        }

        /// <summary>
        /// Clear the table so that text does not overlap, and
        /// become unreadable.
        /// </summary>
        public void ClearTable()
        {
            DonorsTableView.DataStore = new List<object>();
            DonorsTableView.Columns.Clear();
        }

        protected void CalculatePerDonorTotals(object sender, EventArgs e)
        {

            PreviousPageButton.Enabled = false;
            NextPageButton.Enabled = false;
            PreviousPageButton.Visible = false;
            NextPageButton.Visible = false;

            IList<Model.DonorDonationTotalByDonor> donorDonations = operations.CalculatePerDonorTotalDonationAmount();

            ClearTable();
            DonorsTableView.DataStore = donorDonations;

            DonorsTableView.Columns.Add(new GridColumn
            {
                DataCell = new TextBoxCell { Binding = Binding.Property<Model.DonorDonationTotalByDonor, string>(r => r.FirstName) },
                HeaderText = "First Name"
            });

            DonorsTableView.Columns.Add(new GridColumn
            {
                DataCell = new TextBoxCell { Binding = Binding.Property<Model.DonorDonationTotalByDonor, string>(r => r.LastName) },
                HeaderText = "Last Name"
            });

            DonorsTableView.Columns.Add(new GridColumn
            {
                DataCell = new TextBoxCell { Binding = Binding.Property<Model.DonorDonationTotalByDonor, string>(r => r.TotalDonationAmount.ToString()) },
                HeaderText = "Total Amount"
            });

            TableTitleLabel.Text = "Donation Total Amount Per Donor";
        }

        protected void NextPage(object sender, EventArgs e)
        {
            startIndex += pageLength;
            OnShowTableDonationPaginated(sender, e);
        }

        protected void PreviousPage(object sender, EventArgs e)
        {
            startIndex -= pageLength;
            if (startIndex < 0)
            {
                startIndex = 0;
            }

            OnShowTableDonationPaginated(sender, e);
        }

        protected void HandleAbout(object sender, EventArgs e)
        {
            new AboutDialog().ShowDialog(this);
        }

        protected void HandleQuit(object sender, EventArgs e)
        {
            Application.Instance.Quit();
        }
    }
}
