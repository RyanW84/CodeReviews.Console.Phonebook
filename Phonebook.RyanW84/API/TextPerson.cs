using Microsoft.Extensions.Configuration;

using Phonebook.RyanW84.Models;

using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Phonebook.RyanW84.API
    {
    internal class TextPerson
        {
        internal static void Text(Person contact)
            {
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            IConfiguration configuration = configurationBuilder.AddUserSecrets<EmailPerson>().Build();

            var accountSID = configuration.GetSection("TextAPI")["Text:accountSID"];
            var authToken = configuration.GetSection("TextAPI")["Text:authToken"];
            TwilioClient.Init(accountSID, authToken);

            Console.WriteLine("\nPlease type your Message below:");
            var messageBody = Console.ReadLine();
            var message = MessageResource.Create(
            body: $"{messageBody}",
            from: new Twilio.Types.PhoneNumber("+447367181284"), // virtual Twilio number
            to: new Twilio.Types.PhoneNumber(contact.PhoneNumber) // On a Twilio Trial account - the number has to be verified in the account under caller ID
);
            Console.Write("\nHere is your message that was sent: ");
            Console.WriteLine(message.Body);
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
            }
        }
    }