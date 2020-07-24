# Donor Donations (in Rust)



## Requirements (for Developer)

- A Rust compiler
- Cargo build tool (for building Rust projects)
- GTK 3
- PostgreSQL server running with a database
   - You can find the SQL script to create the schema within the CSharp project in the integration folder.

## If you get an error about glib-sys:
If you get an error such as:

`error: failed to run custom build command for glib-sys v0.9.1`

The reason is that you need to install GTK 3.
