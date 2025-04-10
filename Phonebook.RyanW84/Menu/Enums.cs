﻿using System.ComponentModel.DataAnnotations;

namespace Phonebook.RyanW84.UserInterface;

internal class Enums
    {
    internal enum MainMenuOptions
        {
        [Display(Name = "Manage Categories")]
        ManageCategories,
        [Display(Name = "Manage Contacts")]
        ManageContacts,
        [Display(Name = "Quit")]
        Quit
        }

    internal enum CategoryMenu
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

    internal enum ContactMenu
        {
        [Display(Name = "Add Contact")]
        AddContact,
        [Display(Name = "Delete Contact")]
        DeleteContact,
        [Display(Name = "Update Contact")]
        UpdateContact,
        [Display(Name = "Email Contact")]
        EmailContact,
        [Display(Name = "Text Contact")]
        TextContact,
        [Display(Name = "View Contact")]
        ViewContact,
        [Display(Name = "View All Contacts")]
        ViewAllContacts,
        [Display(Name = "Go Back")]
        GoBack
        }
    }
