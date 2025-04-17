using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace Phonebook.RyanW84.Models;

[Index(nameof(Name), IsUnique = true)]
internal class Person
    {
    
    public int PersonId { get; set; }

    
    public string Name { get; set; }

    
    public string PhoneNumber { get; set; }

    
    public string EmailAddress { get; set; }

    public int CategoryId { get; set; }

    public Category Category { get; set; }
    }

