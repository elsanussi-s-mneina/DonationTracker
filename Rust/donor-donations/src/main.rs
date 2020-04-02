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

    let show_donations_button = gtk::Button::new_with_label("Show Donations");
    let show_total_amount_button = gtk::Button::new_with_label("Calculate Total Donation Amount");
    let label = gtk::Label::new(None);
    let total_donation_prelabel = gtk::Label::new(Some("Total donation amount:"));
    let total_donation_label = gtk::Label::new(None);

    window.add(&vbox);


    vbox.add(&show_donations_button);
    vbox.add(&show_total_amount_button);
    vbox.add(&label);
    vbox.add(&total_donation_prelabel);
    vbox.add(&total_donation_label);

    show_donations_button.connect_clicked(clone!(@weak window => move |button| label.set_label(&database_bridge::get_donations().to_string())));
    show_total_amount_button.connect_clicked(clone!(@weak window => move |button| total_donation_label.set_label(&database_bridge::calculate_total_donation_amount().to_string())));



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

