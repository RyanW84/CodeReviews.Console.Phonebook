using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Phonebook.RyanW84;

public class PhonebookDBContextFactory : IDesignTimeDbContextFactory<PhonebookDBContext>
    {
    public PhonebookDBContext CreateDBContext(string[] args)
        {
        var optionsBuilder = new DbContextOptionsBuilder<PhonebookDBContext>();
        optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB;Initial Catalog = Flashcards;Integrated Security = true;");

        return new PhonebookDBContext(optionsBuilder.Options);
        }
    }

