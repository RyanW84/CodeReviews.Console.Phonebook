using MailKit.Net.Smtp;

using Microsoft.Extensions.Configuration;

using MimeKit;

using Phonebook.RyanW84.Models;

using Spectre.Console;

namespace Phonebook.RyanW84.API;

internal class EmailPerson
    {

    internal static void Email(Person contact)
        {
        var email = new MimeMessage();

        ConfigurationBuilder configurationBuilder = new ();
        IConfiguration configuration = configurationBuilder.AddUserSecrets<EmailPerson>().Build();

        var smtp_username = configuration.GetSection("EmailAPI")["Email:smtp_username"];
        var smtp_password = configuration.GetSection("EmailAPI")["Email:smtp_password"];

        AnsiConsole.MarkupLine($"[bold]\nSending an Email to: {contact.Name} at {contact.EmailAddress}[/]");
        AnsiConsole.MarkupLine("[bold]\nPlease enter the Subject line:[/]");
        var subject = Console.ReadLine();
        AnsiConsole.MarkupLine("[bold]\nPlease type your email here (HTML Friendly):[/]");
        var body = Console.ReadLine();

        email.From.Add(new MailboxAddress("Ryan Weavers", "ryanweavers@gmail.com"));
        email.To.Add(new MailboxAddress(contact.Name, contact.EmailAddress));
        email.Subject = $"{subject}";
        email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
            Text = $"{body}"
            };

        using SmtpClient smtp = new();
        smtp.Connect("smtp.gmail.com", 587, false);
        smtp.Authenticate(smtp_username, smtp_password);
        smtp.Send(email);
        smtp.Disconnect(true);
        }
    }
