using System;
using Gtk;
using DonationTracker;

public partial class MainWindow : Gtk.Window
{
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    protected void AddDonorWindow(object sender, EventArgs e)
    {
        var window = new AddDonor();
        window.Show();
    }
}
