using System.ComponentModel.DataAnnotations;

namespace Phonebook.RyanW84.UserInterface;
internal class Enums
    {
    internal enum MainMenuOptions
        {
        [Display(Name = "[DarkSeaGreen2_1]Manage Person[/]")]
        ManagePersons,
        [Display(Name = "[Gold1]Manage Categories[/]")]
        ManageCategories,
        [Display(Name = "[DarkOrange]Communications Menu[/]")]
        Communications,
        [Display(Name = "[Red3_1]Quit[/]")]
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
        [Display(Name = "[DarkSeaGreen2_1]Text a contact[/]")]
        Text,
        [Display(Name = "[Gold1]Email a contact[/]")]
        Email,
        [Display(Name = "[Red]Go Back[/]")]
        GoBack
        }
    }
