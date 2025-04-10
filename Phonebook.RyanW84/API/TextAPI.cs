using Microsoft.Extensions.Configuration;
using Phonebook.RyanW84.Models;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Phonebook.RyanW84.API
    {
    internal class TextAPI
        {
        internal static void Text(Contact contact)
            {
            var secretAppSettingsReader = new SecretAppsettingReader();

            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();

            IConfiguration configuration = configurationBuilder.AddUserSecrets<EmailAPI>().Build();

            var accountSID = configuration.GetSection("TextAPI")["Text:accountSID"];
            var authToken = configuration.GetSection("TextAPI")["Text:authToken"];
            TwilioClient.Init(accountSID, authToken);

            Console.WriteLine("Please type your Message below:");
            var messageBody=Console.ReadLine();
    

            var message = MessageResource.Create(
                body: $"{messageBody}",
                from: new Twilio.Types.PhoneNumber("+447367181284"), // virtual Twilio number
                to: new Twilio.Types.PhoneNumber(contact.PhoneNumber) // On a Twilio Trial account - the number has to be verified in the account under caller ID
            );

            Console.WriteLine(message.Body);
            }
        }
    }