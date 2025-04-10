
using MailKit.Net.Smtp;

using Microsoft.Extensions.Configuration;

using MimeKit;

using Phonebook.RyanW84.Models;


namespace Phonebook.RyanW84.API;

internal class EmailAPI
    {

    internal static void Email(Contact contact)
        {
        var email = new MimeMessage();

        email.From.Add(new MailboxAddress("Ryan Weavers", "ryanweavers@gmail.com"));
        email.To.Add(new MailboxAddress(contact.Name, contact.EmailAddress));

        email.Subject = "Testing out email sending";
        email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
            Text = "<b>Hello all the way from the land of C#</b>"
            };

        using (var smtp = new SmtpClient())
            {
            smtp.Connect("smtp.gmail.com", 587, false);

            var secretAppSettingsReader = new SecretAppsettingReader();

            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();

            IConfiguration configuration = configurationBuilder.AddUserSecrets<EmailAPI>().Build();

            var smtp_username = configuration.GetSection("EmailAPI")["Email:smtp_username"];
            var smtp_password = configuration.GetSection("EmailAPI")["Email:smtp_password"];
            // Note: only needed if the SMTP server requires authentication
            smtp.Authenticate(smtp_username, smtp_password);

            smtp.Send(email);
            smtp.Disconnect(true);
            }
        }
    }
