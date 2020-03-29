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



}
