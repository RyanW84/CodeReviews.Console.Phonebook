using PointOfSale.EntityFramework.RyanW84.Controllers;
using PointOfSale.EntityFramework.RyanW84.Models;

using Spectre.Console;

namespace PointOfSale.EntityFramework.RyanW84.Services;

internal class ContactService
    {
    internal static void InsertContact()
        {
        var contact = new Contact();
        contact.Name = AnsiConsole.Ask<string>("Contact's name:");
        contact.PhoneNumber = AnsiConsole.Ask<string>("Contact's phone number:");
        contact.EmailAddress = AnsiConsole.Ask<string>("Contact's phone number:");
        contact.CategoryId = CategoryService.
       GetCategoryOptionInput().CategoryId;

        ContactController.AddContact(contact);
        }
    internal static void DeleteContact()
        {
        var contact = GetContactOptionInput();
        ContactController.DeleteContact(contact);
        }
    internal static void UpdateContact()
        {
        var contact = GetContactOptionInput();

        contact.Name = AnsiConsole.Confirm("Update contact name?") ?
        AnsiConsole.Ask<string>("Contact's new name: ")
        : contact.Name;

        contact.PhoneNumber = AnsiConsole.Confirm("Update contact phone number?") ?
       AnsiConsole.Ask<string>("Contact's new phone number: ")
       : contact.PhoneNumber;
        contact.EmailAddress = AnsiConsole.Confirm("Update contact E-mail address?") ?
      AnsiConsole.Ask<string>("Contact's new E-mail address: ")
      : contact.EmailAddress;
        contact.Category = AnsiConsole.Confirm("Update Category?") ?
        CategoryService.GetCategoryOptionInput() : contact.Category; 

        ContactController.UpdateContact(contact);
        }
    internal static void GetContact()
        {
        var contact = GetContactOptionInput();
        UserInterface.ShowContact(contact);
        }
    internal static void GetContacts()
        {
        var contacts = ContactController.GetContacts();
        UserInterface.ShowContactTable(contacts);
        }
    static private Contact GetContactOptionInput()
        {
        var contacts = ContactController.GetContacts();
        var contactsArray = contacts.Select(x => x.Name).ToArray();
        var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
        .Title("Choose Contact")
        .AddChoices(contactsArray));
        var id = contacts.Single(x => x.Name == option).ContactId;
        var contact = ContactController.GetContactById(id);

        return contact;
        }
    }

