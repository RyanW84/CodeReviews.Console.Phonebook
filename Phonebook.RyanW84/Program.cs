using Phonebook.RyanW84.DataConnection;
using Phonebook.RyanW84.Menu;

var context = new PhonebookDBContext();
context.Database.EnsureDeleted();
context.Database.EnsureCreated();

ConnectionChecker.TestDatabaseConnection();
UserInterface.MainMenu();

