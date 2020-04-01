using Gtk;

namespace DonationTracker
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Application.Init();
            Gtk.Settings.Default.SetLongProperty("gtk-button-images", 1, "");
            // The previous line allows the icons to appear.

            MainWindow win = new MainWindow();
            win.Show();
            Application.Run();
        }
    }
}
