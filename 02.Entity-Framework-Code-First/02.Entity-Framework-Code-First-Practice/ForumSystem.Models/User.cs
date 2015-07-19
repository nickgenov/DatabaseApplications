using System;

namespace ForumSystem.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
<<<<<<< HEAD
        //public string Username { get; set; }
=======
>>>>>>> 7e9a429d204b5e1738e92259f65fadc6f48473dd
        public Gender Gender { get; set; }
        public DateTime RegisteredOn { get; set; }
        public DateTime? Birthday { get; set; }
    }
}