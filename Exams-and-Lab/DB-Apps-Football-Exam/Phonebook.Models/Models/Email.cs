using System.ComponentModel.DataAnnotations;

namespace Phonebook.Models
{
    public class Email
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid email address")]
        public string EmailAddress { get; set; }
    }
}