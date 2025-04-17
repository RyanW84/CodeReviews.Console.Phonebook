using Microsoft.EntityFrameworkCore;

using Phonebook.RyanW84.DataConnection;
using Phonebook.RyanW84.Models;

namespace Phonebook.RyanW84.Controllers;

internal class PersonController
    {
    internal static void AddPerson(Person person)
        {

        using var db = new PhonebookDBContext();
        db.Add(person);
        db.SaveChanges();
        }

    internal static void DeletePerson(Person person)
        {
        using var db = new PhonebookDBContext();
        db.Remove(person);
        db.SaveChanges();
        }
    internal static void UpdatePerson(Person contact)
        {
        using var db = new PhonebookDBContext();

        db.Update(contact);

        db.SaveChanges();
        }

    internal static Person GetContactById(int id)
        {
        using var db = new PhonebookDBContext();
        var person = db.Person
        .Include(x => x.Category)
        .SingleOrDefault(x => x.PersonId == id);

        return person;
        }
    internal static List<Person> GetPersons()
        {
        using var db = new PhonebookDBContext();

        var persons = db.Person
        .Include(x => x.Category)
        .ToList();

        return persons;
        }
    }

