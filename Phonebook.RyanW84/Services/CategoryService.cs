﻿using Phonebook.RyanW84.Controllers;
using Phonebook.RyanW84.Models;

using Spectre.Console;

namespace Phonebook.RyanW84.Services;

internal class CategoryService
    {
    internal static void InsertCategory()
        {
        var category = new Category();
        category.Name = AnsiConsole.Ask<string>("Category's name:");

        CategoryController.AddCategory(category);

        }
    internal static void DeleteCategory()
        {
        var category = GetCategoryOptionInput();
        CategoryController.DeleteCategory(category);
        }
    internal static void UpdateCategory()
        {
        var category = GetCategoryOptionInput();

        category.Name = AnsiConsole.Ask<string>("Category's new name:");

        CategoryController.UpdateCategory(category);
        }
    internal static Category GetCategoryOptionInput()
        {
        var categories = CategoryController.GetCategories();
        var categoriesArray = categories.Select(x => x.Name).ToArray();
        var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
        .Title("Choose Category")
        .AddChoices(categoriesArray));
        var category = categories.Single(x => x.Name == option);

        return category;
        }
    internal static void GetCategories()
        {
        var categories = CategoryController.GetCategories();
        UserInterface.UserInterface.ShowCategoryTable(categories);
        }
    internal static void GetCategory()
        {
        var category = GetCategoryOptionInput();
        UserInterface.UserInterface.ShowCategory(category);
        }
    }

