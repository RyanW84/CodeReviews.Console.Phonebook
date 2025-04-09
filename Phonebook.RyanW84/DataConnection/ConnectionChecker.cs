using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Phonebook.RyanW84.DataConnection;

internal static class ConnectionChecker
    {
    internal static DbContext? _dbContext;

    static ConnectionChecker()
        {
        // Initialize the DbContext
        _dbContext = new PhonebookDBContext();
        }

    internal static void TestDatabaseConnection()
        {
        if (_dbContext == null)
            {
            Console.WriteLine("Database context is not initialized.");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            return;
            }

        try
            {
            using var connection = _dbContext.Database.GetDbConnection();
            connection.Open();
            Console.WriteLine("Database connection successful! Press any key to continue");
            Console.ReadKey();
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
