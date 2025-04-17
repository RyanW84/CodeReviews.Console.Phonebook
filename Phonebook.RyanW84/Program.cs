using Phonebook.RyanW84.DataConnection;
using Phonebook.RyanW84.UserInterface;

var context = new PhonebookDBContext();
context.Database.EnsureDeleted();
context.Database.EnsureCreated();

ConnectionChecker.TestDatabaseConnection();
UserInterface.MainMenu();

