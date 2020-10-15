using System;
using DonationTracker.Desktop;
using Eto.Forms;

namespace DonationTracker.Gtk
{
	class MainClass
	{
		[STAThread]
		public static void Main(string[] args)
		{
			new Application(Eto.Platforms.Gtk).Run(
				 new MainHelper().ConstructUsualMainForm());
		}
	}
}
