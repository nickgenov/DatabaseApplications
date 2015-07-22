using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace StudentSystem.Models
{
    public class Course
    {
        private ICollection<Homework> homeworks;
        private ICollection<Student> students;
        private ICollection<Resource> resources;

        public Course()
        {
            this.homeworks = new HashSet<Homework>();
            this.students = new HashSet<Student>();
            this.resources = new HashSet<Resource>();
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string  Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Homework> Homeworks
        {
            get { return this.homeworks; }
            set { this.homeworks = value; }
        }

        public virtual ICollection<Student> Students
        {
            get { return this.students; }
            set { this.students = value; }
        }

        public virtual ICollection<Resource> Resources
        {
            get { return this.resources; }
            set { this.resources = value; }
        }
    }
}