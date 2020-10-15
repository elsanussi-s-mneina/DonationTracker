using System;
using DonationTracker.Desktop;
using Eto.Forms;

namespace DonationTracker.Mac
{
	class MainClass
	{
		[STAThread]
		public static void Main(string[] args)
		{
			new Application(Eto.Platforms.Mac64).Run(
				new MainHelper().ConstructUsualMainForm()
				);
		}
	}
}
