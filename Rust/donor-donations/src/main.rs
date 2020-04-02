//  The following code was taken directly from
// https://www.gtk.org/docs/language-bindings/rust/
// On April 1, 2020, then modified.

mod database_bridge;

use gio::prelude::*;
use glib::clone;
use gtk::prelude::*;

// When the application is launched…
fn on_activate(application: &gtk::Application)
{
    // … create a new window …
    let window = gtk::ApplicationWindow::new(application);
    // … with a button in it …
    let button = gtk::Button::new_with_label("Hello World!");
    // … which closes the window when clicked
    button.connect_clicked(clone!(@weak window => move |_| window.destroy()));
    window.add(&button);
    window.show_all();
}

fn main()
{
    // Talk to the database:
    database_bridge::access_database();

    // Create a new application
    let app = gtk::Application::new(Some("com.github.gtk-rs.examples.basic"), Default::default())
        .expect("Initialization failed...");
    app.connect_activate(|app| on_activate(app));
    // Run the application
    app.run(&std::env::args().collect::<Vec<_>>());
}

