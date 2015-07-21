using System;

namespace ForumSystem.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public Gender Gender { get; set; }
        public DateTime RegisteredOn { get; set; }
        //DateTime? makes it a NULLALBLE property
        public DateTime? BirthDay { get; set; }
    }
}