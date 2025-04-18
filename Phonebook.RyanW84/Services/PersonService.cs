using Phonebook.RyanW84.Controllers;
using Phonebook.RyanW84.Menu;
using Phonebook.RyanW84.Models;
using Phonebook.RyanW84.Validators;

using Spectre.Console;

namespace Phonebook.RyanW84.Services;

internal class PersonService
    {
    internal static void InsertPerson()
        {
        Person person = new()
            {
            Name = AnsiConsole.Ask<string>("Person's name:"),
            PhoneNumber = AnsiConsole.Ask<string>("Person's phone number:(format +441234567891)"),
            EmailAddress = AnsiConsole.Ask<string>("Person's E-mail address:"),
            CategoryId = CategoryService.
           GetCategoryOptionInput().CategoryId
            };

        //Validation
        var phoneValidationResult = ContactValidator.IsPhoneNumberValid(person.PhoneNumber);

        while (!phoneValidationResult)
            {
            Console.WriteLine("Please check the Phone Number is correct - press any key to try again\n");
            person.PhoneNumber = AnsiConsole.Ask<string>("Person's phone number:(format +441234567891)");
            phoneValidationResult = ContactValidator.IsPhoneNumberValid(person.PhoneNumber);
            }

        var emailValidationResult = ContactValidator.IsEmailAddressValid(person.EmailAddress);

        while (!emailValidationResult)
            {
            Console.WriteLine("Please check the E-mail Address is correct - press any key to try again\n");
            person.PhoneNumber = AnsiConsole.Ask<string>("Person's E-mail address");
            emailValidationResult = ContactValidator.IsEmailAddressValid(person.EmailAddress);
            }

        PersonController.AddPerson(person);
        }
    internal static void DeletePerson()
        {
        var person = GetPersonOptionInput();
        PersonController.DeletePerson(person);
        }
    internal static void UpdatePerson()
        {
        var person = GetPersonOptionInput();

        person.Name = AnsiConsole.Confirm("Update person name?") ?
        AnsiConsole.Ask<string>("Person's new name: ")
        : person.Name;

        person.PhoneNumber = AnsiConsole.Confirm("Update person phone number?") ?
        AnsiConsole.Ask<string>("Person's new phone number: ") : person.PhoneNumber;

        person.EmailAddress = AnsiConsole.Confirm("Update person E-mail address?") ?
        AnsiConsole.Ask<string>("Person's new E-mail address: ") : person.EmailAddress;

        person.Category = AnsiConsole.Confirm("Update Category?") ?
        CategoryService.GetCategoryOptionInput() : person.Category;

        PersonController.UpdatePerson(person);
        }

    internal static void EmailPerson()
        {
        var person = GetPersonOptionInput();
        API.EmailPerson.Email(person);
        }
    internal static void GetPerson()
        {
        var person = GetPersonOptionInput();
        UserInterface.ShowPerson(person);
        }
    internal static void GetPersons()
        {
        var persons = PersonController.GetPersons();
        UserInterface.ShowPersonsTable(persons);
        }
    internal static Person GetPersonOptionInput()
        {
        var persons = PersonController.GetPersons();
        var personsArray = persons.Select(x => x.Name).ToArray();
        var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
        .Title("Choose Person")
        .AddChoices(personsArray));
        var id = persons.Single(x => x.Name == option).PersonId;
        var person = PersonController.GetContactById(id);

        return person;
        }
    }

