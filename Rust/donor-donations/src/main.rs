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
    let hbox = gtk::Box::new(gtk::Orientation::Horizontal, 12);
    let button_box = gtk::Box::new(gtk::Orientation::Vertical, 10);

    let show_donations_button = gtk::Button::new_with_label("Show Donations");
    let show_total_amount_button = gtk::Button::new_with_label("Calculate Total Donation Amount");
    let intro_label = gtk::Label::new(Some("The purpose of this program is to keep track of monetary donations, and who gave them. The target use case is for non-profit organizations."));
    intro_label.set_line_wrap(true);
    let table_title_label = gtk::Label::new(Some("Select button on right to show data"));
    let label = gtk::Label::new(None);
    let total_donation_prelabel = gtk::Label::new(Some("Total donation amount:"));
    let total_donation_label = gtk::Label::new(None);

    window.add(&vbox);

    vbox.add(&intro_label);

    button_box.add(&show_donations_button);
    button_box.add(&show_total_amount_button);
    button_box.add(&total_donation_prelabel);
    button_box.add(&total_donation_label);

    let vbox_of_table = gtk::Box::new(gtk::Orientation::Vertical, 12);
    vbox_of_table.add(&table_title_label);
    vbox_of_table.add(&label);

    hbox.add(&vbox_of_table);
    hbox.add(&button_box);
    vbox.add(&hbox);

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

