using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Phonebook.RyanW84.Models;

[Index(nameof(Name), IsUnique = true)]
internal class Contact
    {
    [Key]
    public int ContactId { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string PhoneNumber { get; set; }

    [Required]
    public string EmailAddress { get; set; }

    public int CategoryId { get; set; }
    [ForeignKey(nameof(CategoryId))]

    public Category Category { get; set; }
    }

