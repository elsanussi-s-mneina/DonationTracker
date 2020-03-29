using System;
namespace DonationTracker
{
    public partial class AddDonor : Gtk.Window
    {
        public AddDonor() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
        }
    }
}
