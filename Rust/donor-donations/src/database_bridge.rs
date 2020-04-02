use postgres::{Client, NoTls};
use rust_decimal::Decimal;

pub fn access_database()
{

    let mut client = Client::connect("host=localhost user=donation_tracker_user dbname=donation_tracking password=secret1secret", NoTls).unwrap();

    for row in client.query("SELECT donor.id, donor.first_name, donor.last_name, donation.donation_amount FROM donation INNER JOIN donor ON donation.donor_id = donor.id;", &[]).unwrap()
    {
        let id: i32 = row.get(0);
        let first_name: &str = row.get(1);
        let last_name: &str = row.get(2);
        let donation_amount : Decimal  = row.get(3);

        println!("found person: {}\t{}\t{}\t{}", id, first_name, last_name, donation_amount);
    }
}
