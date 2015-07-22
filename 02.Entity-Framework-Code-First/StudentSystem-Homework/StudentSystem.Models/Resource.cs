﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace StudentSystem.Models
{
    public class Resource
    {
        private ICollection<License> licenses;

        public Resource()
        {
            this.licenses = new HashSet<License>();
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ResourceType ResourceType { get; set; }
        [Required]
        public string Url { get; set; }
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }

        public virtual ICollection<License> Licenses
        {
            get { return this.licenses; }
            set { this.licenses = value; }
        }
    }
}