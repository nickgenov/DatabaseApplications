﻿using System;
using System.ComponentModel.DataAnnotations;

namespace StudentSystem.Models
{
    public class Homework
    {
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        public ContentType ContentType { get; set; }
        public DateTime SubmissionDate { get; set; }
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}