# Donation Tracker

## Framework
- .Net Core


## Setup:
- You need PostgreSQL to run the database part.
Although the Program will start without it, nothing will function, and if you click
any button it will crash.

You must setup the database by running both SQL scripts:
  - DatabaseSetup1.sql
  - DatabaseSetup2.sql

These two scripts are contained in the DonationTracker_IntegrationLayer directory.




## Troubleshooting tips


### How to deal with Nuget packages need to be restored before building.
- Right-click on solution, and select Restore NuGet Packages.

### Problems building DonationTracker.Wpf project.
Note: if you are building all projects in Mac OS, you will get the following error:

/usr/local/share/dotnet/sdk/3.1.201/Sdks/Microsoft.NET.Sdk/targets/Microsoft.NET.Sdk.FrameworkReferenceResolution.targets(5,5): Error NETSDK1073: The FrameworkReference 'Microsoft.WindowsDesktop.App' was not recognized (NETSDK1073) (DonationTracker.Wpf)

This error is expected, and happens because there is no way to run Windows specific code in Mac OS.

Instead run the DonationTracker.Mac project instead.
If you are running Visual Studio on Mac, unload the DonationTracker.WPF project from the soluttion, and you will not see the error again.



## Why do I make a new solution in order to change to .NET Core? Why not change the existing projects target framework instead?

I tried that, but when you have more than one project in a solution, and multiple dependencies; this
becomes a huge headache. I think it will be easier to start a new solution,
with exclusively .NET Core projects, and then move each C-sharp file one-by-one.

## Why are you moving to .NET Core?
The reason I was on .NET Framework before was that GTK Sharp did not support
.NET Core at the time. Later, when I noticed GTK Sharp does not provide the
user interface solution I wanted, I decided to move to Eto Forms. I decided
to use this as an opportunity to also change frameworks. We will see if it works.


## How did you create this project?

I used Visual Studio for Mac, 8.5.2.
I first installed the Visual Studio extension titled "Eto.Forms Support Add In".
I got the extension from https://github.com/picoe/Eto/releases  .
I used the file titled Eto.Addin.MonoDevelop-2.5.0.mpack , since I was on MacOS.
After that, when you create a new (Eto Forms) solution,
  I used the wizard, and chose .NET Core, and XAML in the wizard.