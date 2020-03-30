using System;
using Gtk;
using DonationTracker.Desktop;

public partial class MainWindow : Gtk.Window
{
    DesktopOperations operations = new DesktopOperations();

    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    protected void ShowDonorAdditionWindow(object sender, EventArgs e)
    {
        var window = new DonorAdditionWindow(operations);
        window.Show();
    }

    protected void OnShowTableButtonClicked(object sender, EventArgs e)
    {
        var donorDonations = operations.ReadAllDonors();

        ClearTable();
        Label firstNameLabel = new Label();
        firstNameLabel.UseMarkup = true;
        firstNameLabel.Markup = @"<span foreground='black' size='x-large'> <b>First Name</b></span>";
        Label lastNameLabel = new Label("Last Name");
        lastNameLabel.UseMarkup = true;
        lastNameLabel.Markup = @"<span foreground='black' size='x-large'> <b>Last Name</b></span>";

        Label amountLabel = new Label("Amount");
        amountLabel.UseMarkup = true;
        amountLabel.Markup = @"<span foreground='black' size='x-large'> <b>Amount</b></span>";

        uint i = 0;

        DonorsTableView.Attach(firstNameLabel, 0, 1, i, i + 1);
        DonorsTableView.Attach(lastNameLabel, 1, 2, i, i + 1);
        DonorsTableView.Attach(amountLabel, 2, 3, i, i + 1);

        i++;
        foreach (var d in donorDonations)
        {
            Label firstName1 = new Label(d.FirstName);
            Label lastName1 = new Label(d.LastName);
            Label amount1 = new Label(d.DonationAmount.ToString());


            DonorsTableView.Attach(firstName1, 0, 1, i, i + 1);
            DonorsTableView.Attach(lastName1, 1, 2, i, i + 1);
            DonorsTableView.Attach(amount1, 2, 3, i, i + 1);

            i++;
        }

        ShowAll();
    }

    protected void CalculateTotalDonationAmount(object sender, EventArgs e)
    {
        decimal totalDonationAmount = operations.CalculateTotalDonationAmount();

        TotalDonationAmountLabel.Text = "Total: " + totalDonationAmount.ToString();

        
    }

    /// <summary>
    /// Clear the table so that text does not overlap, and
    /// become unreadable.
    /// </summary>
    public void ClearTable()
    {
        foreach (var widget in DonorsTableView.Children)
        {
            DonorsTableView.Remove(widget);
        }
    }

    protected void CalculatePerDonorTotals(object sender, EventArgs e)
    {
        var donorDonations = operations.CalculatePerDonorTotalDonationAmount();

        ClearTable();
        Label firstNameLabel = new Label();
        firstNameLabel.UseMarkup = true;
        firstNameLabel.Markup = @"<span foreground='black' size='x-large'> <b>First Name</b></span>";
        Label lastNameLabel = new Label("Last Name");
        lastNameLabel.UseMarkup = true;
        lastNameLabel.Markup = @"<span foreground='black' size='x-large'> <b>Last Name</b></span>";

        Label amountLabel = new Label("Total Amount");
        amountLabel.UseMarkup = true;
        amountLabel.Markup = @"<span foreground='black' size='x-large'> <b>Amount</b></span>";

        uint i = 0;

        DonorsTableView.Attach(firstNameLabel, 0, 1, i, i + 1);
        DonorsTableView.Attach(lastNameLabel, 1, 2, i, i + 1);
        DonorsTableView.Attach(amountLabel, 2, 3, i, i + 1);

        i++;
        foreach (var d in donorDonations)
        {
            Label firstName1 = new Label(d.FirstName);
            Label lastName1 = new Label(d.LastName);
            Label amount1 = new Label(d.TotalDonationAmount.ToString());


            DonorsTableView.Attach(firstName1, 0, 1, i, i + 1);
            DonorsTableView.Attach(lastName1, 1, 2, i, i + 1);
            DonorsTableView.Attach(amount1, 2, 3, i, i + 1);

            i++;
        }

        ShowAll();
    }
}
