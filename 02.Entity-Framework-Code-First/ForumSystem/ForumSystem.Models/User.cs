using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForumSystem.Models
{
    [Table("ApplicationUsers")]
    public class User
    {
        private ICollection<Question> questions;
        private ICollection<Answer> answers;
        private ICollection<User> friends; 

        public User()
        {
            this.questions = new HashSet<Question>();
            this.answers = new HashSet<Answer>();
            this.friends = new HashSet<User>();
        }

        public virtual ICollection<User> Friends
        {
            get { return this.friends; }
            set { this.friends = value; }
        }

        [Key]
        public int Id { get; set; }
        
        //[Required]
        //public string MiddleName { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(30)]
        public string Username { get; set; }
        public Gender Gender { get; set; }
        public UserInfo UserInfo { get; set; }

        [Column("RegisterDate")]
        public DateTime RegisteredOn { get; set; }
        //DateTime? makes it a NULLALBLE property
        public DateTime? BirthDay { get; set; }

        public virtual ICollection<Question> Questions
        {
            get { return this.questions; }
            set { this.questions = value; }
        }

        public virtual ICollection<Answer> Answers
        {
            get { return this.answers; }
            set { this.answers = value; }
        }

        [Timestamp]
        public byte[] TimeStamp { get; set; }
    }
}