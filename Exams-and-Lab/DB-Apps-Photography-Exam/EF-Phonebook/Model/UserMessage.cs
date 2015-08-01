using System;
using System.ComponentModel.DataAnnotations;

namespace EF_Phonebook.Model
{
    public class UserMessage
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public int RecipientId { get; set; }
        public virtual User Recipient { get; set; }

        [Required]
        public int SenderId { get; set; }
        public virtual User Sender { get; set; }
    }
}