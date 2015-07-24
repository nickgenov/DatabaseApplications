using System;
using System.Collections.Generic;

namespace ForumSystem.Models
{
    public class User
    {
        private ICollection<Question> questions;

        public User()
        {
            this.questions = new HashSet<Question>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Username { get; set; }
        public int? Age { get; set; }
        public Gender Gender { get; set; }
        public DateTime RegisteredOn { get; set; }
        public DateTime? Birthday { get; set; }
        public virtual ICollection<Question> Questions
        {
            get { return this.questions; }
            set { this.questions = value; }
        }
    }
}