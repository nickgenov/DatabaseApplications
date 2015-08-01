using System;
using System.ComponentModel.DataAnnotations;

namespace EF_Phonebook.Model
{
    public class ChannelMessage
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public int ChannelId { get; set; }
        public virtual Channel Channel { get; set; }

        [Required]
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}