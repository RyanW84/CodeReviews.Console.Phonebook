# Flashcards

Welcome to the Phonebook App!

![icons8-contact-book-512-150x150](https://github.com/user-attachments/assets/c153e447-146d-4e3d-b9b9-7a5522324597)

This is a .NET project designed to demonstrate using SQL Server with Entity Framework to store and retain data, in the form of a Phonebook. The project also features using API's to send an SMS text message and an email!

Phonebook is a console app using .NET and SQL
The app comes with some sample data to demonstrate its full functionality, each time the app is run, it will delete the database and create a new one with the sample data. The user can amend or add their own data.

The front end is a console app.
There is an integrated SQL Server database in the back end.

## Requirements
1) This application fulfils the following The C# Academy - Phonebook App requirements:
2) This is an application where you should record contacts with their phone numbers.
3) Users should be able to Add, Delete, Update and Read from a database, using the console.
4) You need to use Entity Framework, raw SQL isn't allowed.
5) Your code should contain a base Contact class with AT LEAST {Id INT, Name STRING, Email STRING and Phone Number(STRING)}
6) You should validate e-mails and phone numbers and let the user know what formats are expected
7) You should use Code-First Approach, which means EF will create the database schema for you.
8)You should use SQL Server, not SQLite


## Challenges
This project has the following challenges:
1) Create a functionality that allows users to add the contact's e-mail address and send an e-mail message from the app.
2) Expand the app by creating categories of contacts (i.e. Family, Friends, Work, etc).
3) What if you want to send not only e-mails but SMS?

## Technologies
* .NET (.Net 9.0)
* C# (C# 12.0)
* SQL Server 2022
* Entity Framework
* Twilio (SMS API)
* Mailkit (Email API)
* Microsoft Testing Platform
* User Secrets
* Spectre Console

## Nuget Packages:
* Microsoft.Extensions.Configuration Version= 9.0.4
* Microsoft.Extensions.Configuration.Binder Version= 9.0.4
* Microsoft.Extensions.Configuration.EnvironmentVariables Version="9.0.4
* Microsoft.Extensions.Configuration.Json Version= 9.0.4
* Microsoft.Extensions.Configuration.UserSecrets Version= 9.0.4
* Microsoft.Extensions.DependencyInjection Version= 9.0.4
* Microsoft.Extensions.Logging Version= 9.0.4
* Microsoft.Extensions.Logging.Console Version= 9.0.4
* Microsoft.Extensions.Options Version= 9.0.4
* Newtonsoft.Json" Version = 13.0.3
* Spectre.Console" Version = 0.50.0
* Twilio Version = 7.10.0
* LanguageExt.Core" Version = 4.4.9
* MailKit" Version = 4.11.0
* Microsoft.EntityFrameworkCore Version = 9.0.4
* Microsoft.EntityFrameworkCore.SqlServer Version= 9.0.4
* Microsoft.EntityFrameworkCore.Tools Version= 9.0.4

## What I learned from this project
1) Configuring Entity Framework to connext to an SQL Server
2) Configuring Entity Framework to Delete and create tables on loading
3) Configuring Entity Framework to Create a Database without having to create one first in SQL Server Management Suite
4) Using SQL Server Management Suite
5) SQL Server tools and toolbars in Visual Studio
6) Validating input using Regex
7) Accessing the Twilio API to send Text messages
8) Using the Mailkit API to send Emails via SMTP
9) Unit Testing
10) Microsoft Testing Platform
11) Managing User Secrets
12) Creating a passcode in Gmail to allow specific apps to access the account without two factor authentication
13) Using Panels in Spectre Console
14) Adding more styling such as colours and different borders in Spectre Consoe

## Getting Started
# IMPORTANT NOTE:
* There is data created in the context file, to give you a preview of all the features
* You will need to create your own Secrets file or add code to add your own credentials for the SMS and SMTP email functionality

## Prerequisites
* .NET 9 SDK
* An IDE (code editor) like Visual Studio or Visual Studio Code.
* A database management tool (optional).
* SQL Server 2022

## Installation
Clone the repository:

git clone https://github.com/RyanW84/CodeReviews.Console.Phonebook.git

## Configure the application:
You can disable the Sensitive Data logging and LoggerFactory in the PhonebookDBContext file, just comment those two out and add a ";" after the connection string parentheses

Update the connection string in appsettings.json to target your SQL Server (localDB)
Build the application using the .NET CLI:

dotnet build

##Running the Application
 You can run the Application from Visual Studio.
OR
Run using the .NET CLI in the folder you have chosen when cloning

## Usage
Please refer to the short demonstration below


![Animation](https://github.com/user-attachments/assets/ab7e276c-4365-4c4a-b5ab-8c8009252110)


## How It Works
1) The console app connects to the database and confirms the connection is open
2) The menu system is presented to the user to make a choice.
3) Each menu option has a method that performs the function selected, in some cases such as adding an item there will be a User Interface Method to gather the information from the user, and back end method to act on the database
4) The data is stored in two tables: Person and Category. They are linked using CategoryID as the Foreign Key (See the Entity Relationship Diagram below)
5) The app stores and retrieves data from these tables.
6) The user can perform CRUD operation on the Person and category records
7) The user can send text messages
8) The user can send emails
9) The app is exited through the Main Menu


## Database
### entity-relationship-diagram

![ER Diagram](https://github.com/user-attachments/assets/efcc8b62-52f6-4d98-bee8-4a84c33c44f6)


## Solution Diagram showing all Methods and classes (generated using Mermaid Design)


[MermaidDiagramOfSolutionMethodsAndClasses.html.pdf](https://github.com/user-attachments/files/19815744/MermaidDiagramOfSolutionMethodsAndClasses.html.pdf)


## Credits
* Many thanks as always to Pablo De Souza from The C Sharp Academy for his mentoring and guidance
* https://www.abstractapi.com/guides/phone-validation/c-validate-phone-number
* https://mailtrap.io/blog/csharp-send-email-gmail/
* https://www.twilio.com/docs/messaging/quickstart/csharp-dotnet-framework
* https://programmingwithwolfgang.com/use-net-secrets-in-console-application/
* https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-9.0&tabs=windows#secret-manager
