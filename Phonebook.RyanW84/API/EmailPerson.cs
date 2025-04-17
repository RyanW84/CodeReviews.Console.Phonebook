using MailKit.Net.Smtp;

using Microsoft.Extensions.Configuration;

using MimeKit;

using Phonebook.RyanW84.Models;

namespace Phonebook.RyanW84.API;

internal class EmailPerson
    {

    internal static void Email(Person contact)
        {
        var email = new MimeMessage();

        ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
        IConfiguration configuration = configurationBuilder.AddUserSecrets<EmailPerson>().Build();

        var smtp_username = configuration.GetSection("EmailAPI")["Email:smtp_username"];
        var smtp_password = configuration.GetSection("EmailAPI")["Email:smtp_password"];


        Console.WriteLine("Plese enter the Subject line");
        var subject = Console.ReadLine();
        Console.WriteLine("Please type your email here (HTML Friendly)");
        var body = Console.ReadLine();

        email.From.Add(new MailboxAddress("Ryan Weavers", "ryanweavers@gmail.com"));
        email.To.Add(new MailboxAddress(contact.Name, contact.EmailAddress));
        email.Subject = $"{subject}";
        email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
            Text = $"{body}"
            };

        using (var smtp = new SmtpClient())
            {
            smtp.Connect("smtp.gmail.com", 587, false);
            smtp.Authenticate(smtp_username, smtp_password);
            smtp.Send(email);
            smtp.Disconnect(true);
            }
        }
    }
