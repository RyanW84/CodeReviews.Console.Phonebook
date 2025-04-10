using Microsoft.EntityFrameworkCore;

using Phonebook.RyanW84.DataConnection;
using Phonebook.RyanW84.Models;

namespace Phonebook.RyanW84.Controllers;

internal class ContactController
    {
    internal static void AddContact(Contact contact)
        {

        using var db = new PhonebookDBContext();
        db.Add(contact);
        db.SaveChanges();
        }

    internal static void DeleteContact(Contact contact)
        {
        using var db = new PhonebookDBContext();
        db.Remove(contact);
        db.SaveChanges();
        }
    internal static void UpdateContact(Contact contact)
        {
        using var db = new PhonebookDBContext();

        db.Update(contact);

        db.SaveChanges();
        }


    internal static Contact GetContactById(int id)
        {
        using var db = new PhonebookDBContext();
        var contact = db.Contacts
        .Include(x => x.Category)
        .SingleOrDefault(x => x.ContactId == id);

        return contact;
        }

    internal static List<Contact> GetContacts()
        {
        using var db = new PhonebookDBContext();

        var contacts = db.Contacts
        .Include(x => x.Category)
        .ToList();

        return contacts;
        }
    }

