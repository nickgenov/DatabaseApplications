﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ForumSystem.Models
{
    [ComplexType]
    public class UserInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }

        [NotMapped]
        public string FullName
        {
            get { return this.FirstName + " " + this.LastName; }

        }
    }
}