
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.UIManager UIManager;

	private global::Gtk.Action dfdAction;

	private global::Gtk.Action dfdgdfsAction;

	private global::Gtk.Action dsfsdfAction;

	private global::Gtk.Action dfdAction1;

	private global::Gtk.Action abdcAction;

	private global::Gtk.Fixed fixed1;

	private global::Gtk.Button button2;

	protected virtual void Build()
	{
		global::Stetic.Gui.Initialize(this);
		// Widget MainWindow
		this.UIManager = new global::Gtk.UIManager();
		global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup("Default");
		this.dfdAction = new global::Gtk.Action("dfdAction", global::Mono.Unix.Catalog.GetString("dfd"), null, null);
		this.dfdAction.ShortLabel = global::Mono.Unix.Catalog.GetString("dfd");
		w1.Add(this.dfdAction, null);
		this.dfdgdfsAction = new global::Gtk.Action("dfdgdfsAction", global::Mono.Unix.Catalog.GetString("dfdgdfs"), null, null);
		this.dfdgdfsAction.ShortLabel = global::Mono.Unix.Catalog.GetString("dfdgdfs");
		w1.Add(this.dfdgdfsAction, null);
		this.dsfsdfAction = new global::Gtk.Action("dsfsdfAction", global::Mono.Unix.Catalog.GetString("dsfsdf"), null, null);
		this.dsfsdfAction.ShortLabel = global::Mono.Unix.Catalog.GetString("dsfsdf");
		w1.Add(this.dsfsdfAction, null);
		this.dfdAction1 = new global::Gtk.Action("dfdAction1", global::Mono.Unix.Catalog.GetString("dfd"), null, null);
		this.dfdAction1.ShortLabel = global::Mono.Unix.Catalog.GetString("dfd");
		w1.Add(this.dfdAction1, null);
		this.abdcAction = new global::Gtk.Action("abdcAction", global::Mono.Unix.Catalog.GetString("abdc"), null, null);
		this.abdcAction.ShortLabel = global::Mono.Unix.Catalog.GetString("abdc");
		w1.Add(this.abdcAction, null);
		this.UIManager.InsertActionGroup(w1, 0);
		this.AddAccelGroup(this.UIManager.AccelGroup);
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString("MainWindow");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.fixed1 = new global::Gtk.Fixed();
		this.fixed1.Name = "fixed1";
		this.fixed1.HasWindow = false;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.button2 = new global::Gtk.Button();
		this.button2.CanFocus = true;
		this.button2.Name = "button2";
		this.button2.UseUnderline = true;
		this.button2.Label = global::Mono.Unix.Catalog.GetString("Add Donor Window");
		this.fixed1.Add(this.button2);
		global::Gtk.Fixed.FixedChild w2 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.button2]));
		w2.X = 368;
		w2.Y = 220;
		this.Add(this.fixed1);
		if ((this.Child != null))
		{
			this.Child.ShowAll();
		}
		this.DefaultWidth = 493;
		this.DefaultHeight = 300;
		this.Show();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler(this.OnDeleteEvent);
		this.button2.Clicked += new global::System.EventHandler(this.AddDonorWindow);
	}
}
