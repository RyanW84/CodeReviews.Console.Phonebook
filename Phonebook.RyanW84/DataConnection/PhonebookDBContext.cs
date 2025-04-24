using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Faker;

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

    private static ILoggerFactory GetLoggerFactory()
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
        for (int i = 1; i <= 30; i++)
        {
            Random random = new Random();
            modelBuilder.Entity<Person>()
   .HasData(new List<Person>
   {
                new() {
                    PersonId = i,
                    CategoryId = random.Next(1, 5),
                    Name = Faker.Name.FullName(),
                    PhoneNumber = Faker.Phone.Number(),
                    EmailAddress= Faker.Internet.Email(),
                }
   });
        }
    }
}


