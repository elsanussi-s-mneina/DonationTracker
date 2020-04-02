use postgres::{Client, NoTls};
use rust_decimal::Decimal;


pub fn get_donations() -> String
{
    let mut client = Client::connect("host=localhost user=donation_tracker_user dbname=donation_tracking password=secret1secret", NoTls).unwrap();

    let mut result : String = String::new();
    for row in client.query("SELECT donor.id, donor.first_name, donor.last_name, donation.donation_amount FROM donation INNER JOIN donor ON donation.donor_id = donor.id;", &[]).unwrap()
    {
        let id: i32 = row.get(0);
        let first_name: &str = row.get(1);
        let last_name: &str = row.get(2);
        let donation_amount : Decimal  = row.get(3);

        result.push_str(&id.to_string());
        result.push_str("\t");

        result.push_str(&first_name);
        result.push_str("\t");

        result.push_str(&last_name);
        result.push_str("\t");

        result.push_str(&donation_amount.to_string());
        result.push_str("\n");
    }
    return result.to_string();
}
