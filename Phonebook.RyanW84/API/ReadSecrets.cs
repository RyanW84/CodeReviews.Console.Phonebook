using Microsoft.Extensions.Configuration;

namespace Phonebook.RyanW84.API;

public class SecretAppsettingReader
    {
    public T ReadSection<T>(string sectionName)
        {
        var environment = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");
        var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{environment}.json", optional: true)
            .AddUserSecrets<Program>()
            .AddEnvironmentVariables();
        var configurationRoot = builder.Build();

        // Use the Options pattern to bind the section to the type
        var section = configurationRoot.GetSection(sectionName);
        var options = section.Get<T>(); // Ensure the required using directives are added

        return options;
        }
    }
