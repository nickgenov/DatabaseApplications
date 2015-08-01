using System.ComponentModel.DataAnnotations;

namespace Phonebook.Models
{
    public class Phone
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }
}