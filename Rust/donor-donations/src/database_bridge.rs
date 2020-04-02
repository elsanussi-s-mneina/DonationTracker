use postgres::{Client, NoTls};

pub fn access_database()
{

    let mut client = Client::connect("host=localhost user=donation_tracker_user dbname=donation_tracking password=secret1secret", NoTls).unwrap();

    for row in client.query("SELECT donor.id, donor.first_name, donor.last_name FROM donation INNER JOIN donor ON donation.donor_id = donor.id;", &[]).unwrap()
    {
        let id: i32 = row.get(0);
        let first_name: &str = row.get(1);
        let last_name: &str = row.get(2);
        println!("found person: {}\t{}\t{}", id, first_name, last_name);
    }
}
