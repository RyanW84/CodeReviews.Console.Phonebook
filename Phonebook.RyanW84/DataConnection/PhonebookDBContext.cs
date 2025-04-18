using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using Phonebook.RyanW84.Models;

namespace Phonebook.RyanW84.DataConnection;

internal class PhonebookDBContext : DbContext
    {
    public DbSet<Person> Person { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder
      .UseSqlServer(@"Server=(localdb)\MSSQLlocaldb; Database = PhonebookDB; initial Catalog=PhonebookDB; Integrated Security=True; TrustServerCertificate=True;")
          .EnableSensitiveDataLogging()
        .UseLoggerFactory(GetLoggerFactory());

        }

    private ILoggerFactory GetLoggerFactory()
        {
        var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
            builder.AddFilter((category, level) =>
                category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information);
        });
        return loggerFactory;
        }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<Person>()
        .HasOne(p => p.Category)
        .WithMany(c => c.Persons)
        .HasForeignKey(p => p.CategoryId);

        modelBuilder.Entity<Category>()
            .HasData(new List<Category>
            {
                new() {
                    CategoryId = 1,
                    Name = "Family"
                },
                new() {
                    CategoryId = 2,
                    Name = "Friends"
                },
                new() {
                    CategoryId = 3,
                    Name = "Colleagues"
                },
                new() {
                    CategoryId = 4,
                    Name = "Customers"
                }
            });
        modelBuilder.Entity<Person>()
      .HasData(new List<Person>
      {
                new() {
                    PersonId = 1,
                    CategoryId = 1,
                    Name = "Ryan Weavers",
                    PhoneNumber = "+441215458558",
                    EmailAddress="xox@pxp.com"
                },
                 new() {
                    PersonId = 2,
                    CategoryId = 1,
                    Name = "Ruth Weavers",
                    PhoneNumber = "+441212111364",
                    EmailAddress="xox2@oxo.com"
                },
                    new() {
                    PersonId = 3,
                    CategoryId = 2,
                    Name = "Pablo DeSouza",
                    PhoneNumber = "+441212111363",
                    EmailAddress="xox4@oxo.com"
                },
                    new() {
                    PersonId = 4,
                    CategoryId = 3,
                    Name = "Adam Smith",
                    PhoneNumber = "+441212111362",
                    EmailAddress="xox5@oxo.com"
                },
                     new() {
                    PersonId = 6,
                    CategoryId = 4,
                    Name = "Adam Jones",
                    PhoneNumber = "+441212111360",
                    EmailAddress="xox6@oxo.com"
                },
                 new() {
                    PersonId = 5,
                    CategoryId = 1,
                    Name = "Joshy Weavers",
                    PhoneNumber = "+441212111361",
                    EmailAddress="xox3@oxo.com"
                }
          });

        }
    }


