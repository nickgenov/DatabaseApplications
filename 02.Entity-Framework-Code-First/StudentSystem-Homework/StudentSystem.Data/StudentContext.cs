using System.Data.Entity;
using StudentSystem.Data.Migrations;
using StudentSystem.Models;

namespace StudentSystem.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext()
            : base("StudentContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentContext, Configuration>());
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Homework> Homeworks { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
    }   
}