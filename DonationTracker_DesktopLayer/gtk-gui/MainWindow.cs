
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.Fixed fixed1;

	private global::Gtk.Button ShowTableButton;

	private global::Gtk.Table DonorsTableView;

	private global::Gtk.Label label1;

	private global::Gtk.Button button2;

	private global::Gtk.Button TotalAmountCalculationButton;

	private global::Gtk.Label TotalDonationAmountLabel;

	protected virtual void Build()
	{
		global::Stetic.Gui.Initialize(this);
		// Widget MainWindow
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString("Donor Tracker");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.fixed1 = new global::Gtk.Fixed();
		this.fixed1.Name = "fixed1";
		this.fixed1.HasWindow = false;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.ShowTableButton = new global::Gtk.Button();
		this.ShowTableButton.CanFocus = true;
		this.ShowTableButton.Name = "ShowTableButton";
		this.ShowTableButton.UseUnderline = true;
		this.ShowTableButton.Label = global::Mono.Unix.Catalog.GetString("Show Donations");
		this.fixed1.Add(this.ShowTableButton);
		global::Gtk.Fixed.FixedChild w1 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.ShowTableButton]));
		w1.X = 389;
		w1.Y = 179;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.DonorsTableView = new global::Gtk.Table(((uint)(4)), ((uint)(3)), false);
		this.DonorsTableView.Name = "DonorsTableView";
		this.DonorsTableView.RowSpacing = ((uint)(6));
		this.DonorsTableView.ColumnSpacing = ((uint)(6));
		this.DonorsTableView.BorderWidth = ((uint)(3));
		this.fixed1.Add(this.DonorsTableView);
		global::Gtk.Fixed.FixedChild w2 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.DonorsTableView]));
		w2.X = 53;
		w2.Y = 148;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.label1 = new global::Gtk.Label();
		this.label1.Name = "label1";
		this.label1.LabelProp = global::Mono.Unix.Catalog.GetString("The purpose of this program is to keep track of monetary donations, and who gave " +
				"them. The target use case is for non-profit organizations.");
		this.label1.Wrap = true;
		this.fixed1.Add(this.label1);
		global::Gtk.Fixed.FixedChild w3 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.label1]));
		w3.X = 130;
		w3.Y = 30;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.button2 = new global::Gtk.Button();
		this.button2.CanFocus = true;
		this.button2.Name = "button2";
		this.button2.UseUnderline = true;
		this.button2.Label = global::Mono.Unix.Catalog.GetString("Add Donations");
		this.fixed1.Add(this.button2);
		global::Gtk.Fixed.FixedChild w4 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.button2]));
		w4.X = 397;
		w4.Y = 141;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.TotalAmountCalculationButton = new global::Gtk.Button();
		this.TotalAmountCalculationButton.CanFocus = true;
		this.TotalAmountCalculationButton.Name = "TotalAmountCalculationButton";
		this.TotalAmountCalculationButton.UseUnderline = true;
		this.TotalAmountCalculationButton.Label = global::Mono.Unix.Catalog.GetString("Calculate Total Donation Amount");
		this.fixed1.Add(this.TotalAmountCalculationButton);
		global::Gtk.Fixed.FixedChild w5 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.TotalAmountCalculationButton]));
		w5.X = 396;
		w5.Y = 265;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.TotalDonationAmountLabel = new global::Gtk.Label();
		this.TotalDonationAmountLabel.Name = "TotalDonationAmountLabel";
		this.fixed1.Add(this.TotalDonationAmountLabel);
		global::Gtk.Fixed.FixedChild w6 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.TotalDonationAmountLabel]));
		w6.X = 434;
		w6.Y = 313;
		this.Add(this.fixed1);
		if ((this.Child != null))
		{
			this.Child.ShowAll();
		}
		this.DefaultWidth = 874;
		this.DefaultHeight = 374;
		this.Show();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler(this.OnDeleteEvent);
		this.ShowTableButton.Clicked += new global::System.EventHandler(this.OnShowTableButtonClicked);
		this.button2.Clicked += new global::System.EventHandler(this.ShowDonorAdditionWindow);
		this.TotalAmountCalculationButton.Clicked += new global::System.EventHandler(this.CalculateTotalDonationAmount);
	}
}
