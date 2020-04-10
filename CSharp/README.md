# Donation Tracker Project

This application is still a prototype, and is not ready for serious use.

This is meant to become a desktop application that can be used to add information
about donations to a charitable organization. So far very few features are implemented.

This project is written in C# using the .NET framework 4.x.
I wrote it using Eto Forms so that it could run on Windows, Mac, or Linux.

Although, I have only tested it so far on Mac.

I used Visual Studio for Mac version 8.5 to start it.

The applicaiton has a 3-tier layered architecture. But unfortunately
I had to reference the Integration layer from the desktop layer, just so
that the DLL file would be copied over (I have not determined how to get
Visual Studio to copy over transitive dependencies).

The application uses PostgreSQL (version 12.1) as a relational database management system, and does not use an ORM.




some-computer:~some-username:  psql --version
psql (PostgreSQL) 12.1
