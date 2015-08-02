﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Code_First_Movies.Models
{
    using System.ComponentModel.DataAnnotations;
    using Enums;

    public class Movie
    {
        private ICollection<Rating> ratings;
        private ICollection<User> users;

        public Movie()
        {
            this.ratings = new HashSet<Rating>();
            this.users = new HashSet<User>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Isbn { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Title { get; set; }

        public AgeRestriction AgeRestriction { get; set; }

        public virtual ICollection<Rating> Ratings
        {
            get { return this.ratings; }
            set { this.ratings = value; }
        }

        public virtual ICollection<User> Users
        {
            get { return this.users; }
            set { this.users = value; }
        }
    }
}