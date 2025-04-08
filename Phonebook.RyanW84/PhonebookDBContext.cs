using Microsoft.EntityFrameworkCore;

using PointOfSale.EntityFramework.RyanW84.Models;

namespace PointOfSale.EntityFramework.EntityFramework;

internal class PhonebookDBContext : DbContext
    {
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        optionsBuilder.UseSqlServer();
        }
    }

