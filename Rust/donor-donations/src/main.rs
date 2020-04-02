mod database_bridge;

use gio::prelude::*;
use glib::clone;
use gtk::prelude::*;

// When the application is launched…
fn on_activate(application: &gtk::Application)
{
    // … create a new window …
    let window = gtk::ApplicationWindow::new(application);

    window.set_title("Donor Tracker");
    window.set_border_width(10);
    window.set_position(gtk::WindowPosition::Center);
    window.set_default_size(350, 70);


    let vbox = gtk::Box::new(gtk::Orientation::Vertical, 12);

    // … with a button in it …
    let button = gtk::Button::new_with_label("Show Donations");
    // that shows the donations in the following label:
    let label = gtk::Label::new(None);

    window.add(&vbox);

    vbox.add(&button);
    vbox.add(&label);

    button.connect_clicked(clone!(@weak window => move |button| label.set_label(&database_bridge::get_donations().to_string())));

    window.show_all();
}

fn main()
{
    // Create a new application
    let app = gtk::Application::new(Some("com.github.gtk-rs.examples.basic"), Default::default())
        .expect("Initialization failed...");
    app.connect_activate(|app| on_activate(app));
    // Run the application
    app.run(&std::env::args().collect::<Vec<_>>());
}

