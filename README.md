# dotnet-conventions

![Logo](https://avatars.githubusercontent.com/u/19664623?s=200&v=4)
![Logo](https://upload.wikimedia.org/wikipedia/commons/thumb/e/ee/.NET_Core_Logo.svg/120px-.NET_Core_Logo.svg.png)

### This Template is also a part of the Blink22 .Net Learning Track, To Follow Progress Please Refer To The Roadmap Attached Below
[Blink22 .Net RoadMap](https://roadmap.sh/r?id=6643472c662f1deb3431399f)



## Description:
The dotnet-conventions project is a .NET application that demonstrates best practices and conventions for developing ASP.NET Core web APIs using Entity Framework Core for data access. It includes various features like middleware, exception handling, Swagger API documentation, and more, all following recommended conventions.

this template is also a part of the Blink22 RoadMap

## How to Run Using Visual Studio 2022 Community Edition:

Clone the repository to your local machine.
Open Visual Studio 2022 Community Edition.
Select "Open a project or solution" and navigate to the cloned repository folder. Open the solution file (.sln).
Once the solution is loaded, ensure that the startup project is set to the WebApi project.
Build the solution by selecting "Build" > "Build Solution" from the top menu.

## Installing SQL Server Locally:

Download and install SQL Server locally from the official Microsoft website or via the Microsoft SQL Server Management Studio (SSMS).
Follow the installation instructions provided during the installation process.
Make note of the SQL Server instance name and credentials for later use.
Adding Connection String in appsettings.json:

Open the appsettings.json file in the WebApi project.
Locate the "ConnectionStrings" section.
Update the "DefaultConnection" value with your SQL Server connection string. Replace placeholders like Server, Database, User ID, and Password with your SQL Server instance details.

## Running Migrations:

Open the Package Manager Console in Visual Studio (View -> Other Windows -> Package Manager Console).
Ensure that the Default Project selected in the Package Manager Console is set to the Infrastructure project.

#### Run the following command to add a new migration:
* Add-Migration [MigrationName]
Replace [MigrationName] with a meaningful name for your migration.
After adding the migration, we need to update the database with the current migration, or in other words run the migration

* Update-Database
This command will execute any pending migrations and update the database schema.

#### To remove a previously applied migration, you can use the following:
#### use the Update-Database [PreviousMigrationName] to roll back to this specific migration, then use Remove-Migration to delete most recent

* Remove-Migration
This command will revert/delete the last generated migration, will result in an error if migration was applied.

## Migration Commands:

* Add-Migration [MigrationName]: Creates a new migration with the specified name based on the changes detected in the DbContext.
 
* Update-Database: Applies pending migrations to the database and updates the database schema.
  
* Remove-Migration: Reverts the last applied migration, undoing its changes to the database schema.
  
#### Note: Ensure that you have necessary permissions and configurations set up for SQL Server and Entity Framework Core migrations to run successfully.
