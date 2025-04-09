using Microsoft.EntityFrameworkCore;

using Phonebook.RyanW84.Models;

namespace Phonebook.RyanW84.DataConnection;

internal class PhonebookDBContext : DbContext
    {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer(@"Server=(localdb)\Phonebook; Initial Catalog=PhonebookDB; Integrated Security=True; TrustServerCertificate=True;");
        }

    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Category> Categories { get; set; }
    }


