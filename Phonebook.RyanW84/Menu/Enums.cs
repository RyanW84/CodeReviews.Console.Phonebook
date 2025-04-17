using System.ComponentModel.DataAnnotations;

namespace Phonebook.RyanW84.UserInterface;
internal class Enums
    {
    internal enum MainMenuOptions
        {
        [Display(Name = "Manage Person")]
        ManagePersons,
        [Display(Name = "Manage Categories")]
        ManageCategories,
        [Display(Name = "Quit")]
        Quit
        }
    internal enum PersonMenuOptions
        {
        [Display(Name = "Add Person")]
        AddPerson,
        [Display(Name = "Delete Person")]
        DeletePerson,
        [Display(Name = "Update Person")]
        UpdatePerson,
        [Display(Name = "Email Person")]
        EmailPerson,
        [Display(Name = "Text Person")]
        TextPerson,
        [Display(Name = "View Person")]
        ViewPerson,
        [Display(Name = "View All Persons")]
        ViewAllPersons,
        [Display(Name = "Go Back")]
        GoBack
        }
    internal enum CategoryMenuOptions
        {
        [Display(Name = "Add Category")]
        AddCategory,
        [Display(Name = "Delete Category")]
        DeleteCategory,
        [Display(Name = "View Category")]
        ViewCategory,
        [Display(Name = "View All Categories")]
        ViewAllCategories,
        [Display(Name = "Update Category")]
        UpdateCategory,
        [Display(Name = "Go Back")]
        GoBack
        }
    internal enum ContactMenuOptions
        {
        [Display(Name = "[green]Text a contact[/]")]
        Text,
        [Display(Name = "Email a contact")]
        Email,
        [Display(Name = "Go Back")]
        GoBack
        }
    }
