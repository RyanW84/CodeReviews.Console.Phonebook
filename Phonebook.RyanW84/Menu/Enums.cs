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
        [Display(Name = "[DarkSeaGreen2_1]Add Person[/]")]
        AddPerson,
        [Display(Name = "[DarkSeaGreen2_1]Delete Person[/]")]
        DeletePerson,
        [Display(Name = "[DarkSeaGreen2_1]Update Person[/]")]
        UpdatePerson,
        [Display(Name = "[DarkSeaGreen2_1]View Person[/]")]
        ViewPerson,
        [Display(Name = "[DarkSeaGreen2_1]View All Persons[/]")]
        ViewAllPersons,
        [Display(Name = "[Red3_1]Go Back[/]")]
        GoBack
        }
    internal enum CategoryMenuOptions
        {
        [Display(Name = "[Gold1]Add Category[/]")]
        AddCategory,
        [Display(Name = "[Gold1]Delete Category[/]")]
        DeleteCategory,
        [Display(Name = "[Gold1]View Category[/]")]
        ViewCategory,
        [Display(Name = "[Gold1]View All Categories[/]")]
        ViewAllCategories,
        [Display(Name = "[Gold1]Update Category[/]")]
        UpdateCategory,
        [Display(Name = "[Red3_1]Go Back[/]")]
        GoBack
        }
    internal enum ContactMenuOptions
        {
        [Display(Name = "[DarkOrange]Text a contact[/]")]
        Text,
        [Display(Name = "[DarkOrange]Email a contact[/]")]
        Email,
        [Display(Name = "[Red]Go Back[/]")]
        GoBack
        }
    }
