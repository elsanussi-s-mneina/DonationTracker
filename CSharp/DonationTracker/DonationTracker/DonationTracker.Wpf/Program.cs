using System;
using DonationTracker.Desktop;
using Eto.Forms;

namespace DonationTracker.Wpf
{
    class MainClass
    {
        [STAThread]
        public static void Main(string[] args)
        {
            new Application(Eto.Platforms.Wpf).Run(
                new MainHelper().ConstructUsualMainForm());
        }
    }
}
