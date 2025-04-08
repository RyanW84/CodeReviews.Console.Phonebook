using Microsoft.EntityFrameworkCore;

using PointOfSale.EntityFramework.EntityFramework;
using PointOfSale.EntityFramework.RyanW84.Models;

namespace PointOfSale.EntityFramework.RyanW84.Controllers;

internal class CategoryController
    {
    internal static void AddCategory(Category category)
        {
        using var db = new PhonebookDBContext();

        db.Add(category);

        db.SaveChanges();
        }

    internal static void DeleteCategory(Category category)
        {
        using var db = new PhonebookDBContext();

        db.Remove(category);

        db.SaveChanges();
        }

    internal static void UpdateCategory(Category category)
        {
        using var db = new PhonebookDBContext();

        db.Update(category);

        db.SaveChanges();
        }

    internal static List<Category> GetCategories()
        {
        using var db = new PhonebookDBContext();

        var categories = db.Categories
        .Include(x => x.Contacts)
        .ToList();

        return categories;
        }
    }

