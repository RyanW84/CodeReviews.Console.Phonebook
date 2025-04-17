namespace Phonebook.RyanW84.Models;

internal class Category
    {

    public int CategoryId { get; set; }


    public string Name { get; set; }

    public ICollection<Person> Persons { get; set; }
    }

