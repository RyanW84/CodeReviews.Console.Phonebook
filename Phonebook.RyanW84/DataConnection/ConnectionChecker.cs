using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Phonebook.RyanW84.DataConnection;

internal static class ConnectionChecker
    {
   
    private static DbContext? dbContext;

    static ConnectionChecker()
        {
        DbContext = new PhonebookDBContext();
        }

    internal static DbContext DbContext { get => dbContext; set => dbContext = value; }

    internal static void TestDatabaseConnection()
        {
        if (DbContext == null)
            {
            Console.WriteLine("Database context is not initialized.");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            return;
            }
        try
            {
            using var connection = DbContext.Database.GetDbConnection();
            connection.Open();
            for (int i = 0; i <= 100; i++)
                {
                Console.Write($"\rPhonebook App: {i}% loaded");
                Thread.Sleep(3); 
                }
            Console.WriteLine("\nDatabase connection successful!");
            Thread.Sleep(800);
            }
        catch (SqlException ex)
            {
            Console.WriteLine($"Database connection failed: {ex.Message}");
            Console.ReadKey();
            }
        catch (Exception ex)
            {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            Console.ReadKey();
            }
        }
    }
