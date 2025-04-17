using System.ComponentModel.DataAnnotations;

using Phonebook.RyanW84.Models;
using Phonebook.RyanW84.Services;

using Spectre.Console;
using Spectre.Console.Rendering;

using static Phonebook.RyanW84.UserInterface.Enums;

namespace Phonebook.RyanW84.UserInterface;

static internal class UserInterface
    {

    //Menu Methods
    private static string GetEnumDisplayName(Enum enumValue) //Enums weren't showing their display name, this fixes it
        {
        var displayAttribute =
            enumValue
                .GetType()
                .GetField(enumValue.ToString())
                .GetCustomAttributes(typeof(DisplayAttribute), false)
                .FirstOrDefault() as DisplayAttribute;

        if (displayAttribute == null)
            {
            Console.WriteLine("No Enum display names found");
            }

        return displayAttribute != null ? displayAttribute.Name : enumValue.ToString();
        }
    internal static void MainMenu()
        {
        Console.Clear();

        bool isMenuRunning = true;

        while (isMenuRunning)
            {
            Console.Clear();
            var usersChoice = AnsiConsole.Prompt(
                new SelectionPrompt<MainMenuOptions>()
                    .Title("Welcome to Phonebook\nWhat would you like to do?")
                    .AddChoices(Enum.GetValues(typeof(MainMenuOptions)).Cast<MainMenuOptions>())
                    .UseConverter(choice => GetEnumDisplayName(choice))
            );

            switch (usersChoice)
                {
                case MainMenuOptions.ManageCategories:
                CategoriesMenu();
                break;
                case MainMenuOptions.ManagePersons:
                PersonMenu();
                break;
                case MainMenuOptions.Quit:
                isMenuRunning = false;
                Console.WriteLine("Thank you for using my Phonebook App");
                break;
                default:
                Console.WriteLine("Please enter a correct option");
                Console.ReadKey();
                MainMenu();
                break;

                }
            }
        }
    internal static void PersonMenu()
        {
        bool isProductMenuRunning = true;

        while (isProductMenuRunning)
            {
            Console.Clear();
            var usersChoice = AnsiConsole.Prompt(
                new SelectionPrompt<PersonMenuOptions>()
                    .Title("Welcome to Phonebook\nWhat would you like to do?")
                    .AddChoices(Enum.GetValues(typeof(PersonMenuOptions)).Cast<PersonMenuOptions>())
                    .UseConverter(choice => GetEnumDisplayName(choice))
            );

            switch (usersChoice)
                {
                case Enums.PersonMenuOptions.AddPerson:
                PersonService.InsertPerson();
                break;
                case Enums.PersonMenuOptions.DeletePerson:
                PersonService.DeletePerson();
                break;
                case Enums.PersonMenuOptions.UpdatePerson:
                PersonService.UpdatePerson();
                break;
                case Enums.PersonMenuOptions.EmailPerson:
                API.EmailPerson.Email(PersonService.GetPersonOptionInput());
                break;
                case Enums.PersonMenuOptions.TextPerson:
                API.TextPerson.Text(PersonService.GetPersonOptionInput());
                break;
                case Enums.PersonMenuOptions.ViewPerson:
                PersonService.GetPerson();
                break;
                case Enums.PersonMenuOptions.ViewAllPersons:
                PersonService.GetPersons();
                break;
                case Enums.PersonMenuOptions.GoBack:
                isProductMenuRunning = false;
                break;
                default:
                Console.Write("Please choose a valid option (Press Any Key to continue:");
                Console.ReadLine();
                PersonMenu();
                break;
                }
            }
        }
    internal static void CategoriesMenu()
        {
        bool isCategoryMenuRunning = true;

        while (isCategoryMenuRunning)
            {
            Console.Clear();
            var usersChoice = AnsiConsole.Prompt(
                new SelectionPrompt<CategoryMenuOptions>()
                    .Title("Welcome to Phonebook\nWhat would you like to do?")
                    .AddChoices(Enum.GetValues(typeof(CategoryMenuOptions)).Cast<CategoryMenuOptions>())
                    .UseConverter(choice => GetEnumDisplayName(choice))
            );

            switch (usersChoice)
                {
                case CategoryMenuOptions.AddCategory:
                CategoryService.InsertCategory();
                break;
                case CategoryMenuOptions.DeleteCategory:
                CategoryService.DeleteCategory();
                break;
                case CategoryMenuOptions.UpdateCategory:
                CategoryService.UpdateCategory();
                break;
                case CategoryMenuOptions.ViewCategory:
                CategoryService.GetCategory();
                break;
                case CategoryMenuOptions.ViewAllCategories:
                CategoryService.GetCategories();
                break;
                case CategoryMenuOptions.GoBack:
                isCategoryMenuRunning = false;
                break;
                default:
                Console.Write("Please choose a valid option (Press Any Key to continue:");
                Console.ReadLine();
                CategoriesMenu();
                break;
                }
            }
        }

    //Helpers
    internal static void ShowPerson(Person person)
        {
        var panel = new Panel($"ID: {person.PersonId} \nName: {person.Name} \nPhone Number: {person.PhoneNumber} \nE-mail Address: {person.EmailAddress} \nCategory: {person.Category.Name}");
        panel.Header = new PanelHeader("** Contact Info **").Centered();
        panel.Padding = new Padding(2, 2, 2, 2);
        panel.Border=BoxBorder.Heavy;

        AnsiConsole.Write(panel);
        Console.WriteLine("Press any key to return to Main Menu");
        Console.ReadLine();

        }
    static internal void ShowPersonsTable(List<Person> persons)
        {
        var table = new Table();
        table.Border = TableBorder.Double;
        table.AddColumn("ID").Centered();
        table.AddColumn("Name").Centered();
        table.AddColumn("Phone Number").Centered();
        table.AddColumn("E-mail Address").Centered();
        table.AddColumn("Category").Centered();

        foreach (var person in persons)
            {
            table.AddRow(
            person.PersonId.ToString(),
            person.Name,
            person.PhoneNumber,
            person.EmailAddress,
            person.Category.Name
            ).Centered();
            }

        AnsiConsole.Write(table);

        Console.WriteLine("Press any key to continue");
        Console.ReadLine();
        }
    internal static void ShowCategoryTable(List<Category> categories)
        {
        var table = new Table();
        table.AddColumn("ID");
        table.AddColumn("Name");

        foreach (Category category in categories)
            {
            table.AddRow(
            category.CategoryId.ToString(),
            category.Name
            );
            }

        AnsiConsole.Write(table);

        Console.WriteLine("Press any key to continue");
        Console.ReadLine();
        }
    internal static void ShowCategory(Category category)
        {
        var panel = new Panel($"ID: {category.CategoryId} \nName: {category.Name} \nContact Count: {category.Persons.Count}");
        panel.Header = new PanelHeader($"** {category.Name} **").Centered();
        panel.Padding = new Padding(2, 2, 2, 2);
        panel.Border = BoxBorder.Rounded;
        

        AnsiConsole.Write(panel);

        // Convert ICollection<Person> to List<Person> before passing it to ShowPersonsTable
        ShowPersonsTable(category.Persons.ToList());

        Console.WriteLine("Press any key to return to Main Menu");
        Console.ReadLine();
        }
    }

