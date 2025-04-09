using System.ComponentModel.DataAnnotations;
using Phonebook.RyanW84.Models;
using Phonebook.RyanW84.Services;
using Spectre.Console;
using static Phonebook.RyanW84.Enums;

namespace Phonebook.RyanW84;

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
                case MainMenuOptions.ManageContacts:
                ProductsMenu();
                break;
                case MainMenuOptions.Quit:
                isMenuRunning = false;
                Console.WriteLine("Thank you for using our E.P.O.S App");
                break;
                default:
                Console.WriteLine("Please enter a correct option");
                Console.ReadKey();
                MainMenu();
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
                new SelectionPrompt<CategoryMenu>()
                    .Title("Welcome to E.P.O.S\nWhat would you like to do?")
                    .AddChoices(Enum.GetValues(typeof(CategoryMenu)).Cast<CategoryMenu>())
                    .UseConverter(choice => GetEnumDisplayName(choice))
            );

            switch (usersChoice)
                {
                case CategoryMenu.AddCategory:
                CategoryService.InsertCategory();
                break;
                case CategoryMenu.DeleteCategory:
                CategoryService.DeleteCategory();
                break;
                case CategoryMenu.UpdateCategory:
                CategoryService.UpdateCategory();
                break;
                case CategoryMenu.ViewCategory:
                CategoryService.GetCategory();
                break;
                case CategoryMenu.ViewAllCategories:
                CategoryService.GetCategories();
                break;
                case CategoryMenu.GoBack:
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

    internal static void ProductsMenu()
        {
        bool isProductMenuRunning = true;

        while (isProductMenuRunning)
            {
            Console.Clear();
            var usersChoice = AnsiConsole.Prompt(
                new SelectionPrompt<ContactMenu>()
                    .Title("Welcome to E.P.O.S\nWhat would you like to do?")
                    .AddChoices(Enum.GetValues(typeof(ContactMenu)).Cast<ContactMenu>())
                    .UseConverter(choice => GetEnumDisplayName(choice))
            );

            switch (usersChoice)
                {
                case ContactMenu.AddContact:
                ContactService.InsertContact();
                break;
                case ContactMenu.DeleteContact:
                ContactService.DeleteContact();
                break;
                case ContactMenu.UpdateContact:
                ContactService.UpdateContact();
                break;
                case ContactMenu.EmailContact:
                ContactService.UpdateContact();
                break;
                case ContactMenu.ViewContact:
                ContactService.GetContact();
                break;
                case ContactMenu.ViewAllContacts:
                ContactService.GetContacts();
                break;
                case ContactMenu.GoBack:
                isProductMenuRunning = false;
                break;
                default:
                Console.Write("Please choose a valid option (Press Any Key to continue:");
                Console.ReadLine();
                ProductsMenu();
                break;
                }
            }
        }

    internal static void ShowContact(Contact contact)
        {
        var panel = new Panel($"ID: {contact.ContactId} \nName: {contact.Name} \nPhone Number: {contact.PhoneNumber} \nE-mail Address: {contact.EmailAddress} \nCategory: {contact.Category.Name}");
        panel.Header = new PanelHeader("** Contact Info **");
        panel.Padding = new Padding(2, 2, 2, 2);

        AnsiConsole.Write(panel);
        Console.WriteLine("Press any key to return to Main Menu");
        Console.ReadLine();

        }

    static internal void ShowContactTable(List<Contact> contacts)
        {
        var table = new Table();
        table.AddColumn("ID");
        table.AddColumn("Name");
        table.AddColumn("Phone Number");
        table.AddColumn("E-mail Address");
        table.AddColumn("Category");

        foreach (var contact in contacts)
            {
            table.AddRow(
            contact.ContactId.ToString(),
            contact.Name,
            contact.PhoneNumber,
            contact.EmailAddress,
            contact.Category.Name
            );
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
        var panel = new Panel($"ID: {category.CategoryId} \nName: {category.Name} \nContact Count: {category.Contacts.Count}");
        panel.Header = new PanelHeader($"** {category.Name} **");
        panel.Padding = new Padding(2, 2, 2, 2);

        AnsiConsole.Write(panel);

        ShowContactTable(category.Contacts);

        Console.WriteLine("Press any key to return to Main Menu");
        Console.ReadLine();
        }
    }

