using System;
using System.Collections.Generic;
using StudentSystem.Models;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace StudentSystem.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<StudentSystem.Data.StudentContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationDataLossAllowed = false;
            this.AutomaticMigrationsEnabled = true;
            this.ContextKey = "StudentSystem.Data.StudentContext";
        }

        protected override void Seed(StudentContext context)
        {
            context.Students.AddOrUpdate(s => s.Name, new Student()
            {
                Name = "Stamat Stamatov",
                PhoneNumber = "+359 0885 235 596",
                RegisteredOn = new DateTime(2015, 5, 1),
                Courses = new List<Course>()
                    {
                        new Course()
                        {
                            Name = "Databases",
                            StartDate = new DateTime(2015, 6, 1),
                            EndDate = new DateTime(2015, 7, 12),
                            Price = 200,
                            Homeworks = new List<Homework>()
                            {
                                new Homework()
                                {
                                    Content = "Transact-SQL",
                                    ContentType = ContentType.Zip,
                                    SubmissionDate = new DateTime(2015, 6, 28),
                                }
                            },
                            Resources = new List<Resource>()
                            {
                                new Resource()
                                {
                                    Name = "SQL Server Internals",
                                    ResourceType = ResourceType.Document,
                                    Url = "www.amazon.com/Microsoft-Server-Internals-Developer-Reference/dp/0735658560",
                                },
                                new Resource()
                                {
                                    Name = "SQL For DUMMIES",
                                    ResourceType = ResourceType.Document,
                                    Url = "www.fordummies.net",
                                },
                                new Resource()
                                {
                                    Name = "SQL Triggers",
                                    ResourceType = ResourceType.Document,
                                    Url = "www.w3c.com",
                                },
                                 new Resource()
                                {
                                    Name = "SQL Cursors",
                                    ResourceType = ResourceType.Document,
                                    Url = "www.w3c.com",
                                },
                                 new Resource()
                                {
                                    Name = "SQL Stored Procedures",
                                    ResourceType = ResourceType.Document,
                                    Url = "www.w3c.com",
                                },
                                 new Resource()
                                {
                                    Name = "SQL Transactions in depth",
                                    ResourceType = ResourceType.Document,
                                    Url = "www.pluralsight.com",
                                },

                            }
                        }
                    }
            });

            context.SaveChanges();

            context.Students.AddOrUpdate(s => s.Name, new Student()
            {
                Name = "Pesho Peshev",
                RegisteredOn = new DateTime(2015, 2, 3),
                PhoneNumber = "+359 0897 335 596",
                Courses = new List<Course>()
                {
                    new Course()
                    {
                        Name = "Database Apps",
                        StartDate = new DateTime(2015, 8, 1),
                        EndDate = new DateTime(2015, 9, 12),
                        Price = 250,
                        Homeworks = new List<Homework>()
                        {
                            new Homework()
                            {
                                Content = "Code First",
                                ContentType = ContentType.Zip,
                                SubmissionDate = new DateTime(2015, 6, 28),
                            }
                        },
                        Resources = new List<Resource>()
                        {
                            new Resource()
                            {
                                Name = "SQL Migrations",
                                ResourceType = ResourceType.Video,
                                Url = "www.pluralsight.com",
                            }
                        }
                    }
                }
            });

            context.SaveChanges();

            context.Students.AddOrUpdate(s => s.Name, new Student()
            {
                Name = "Zdravka Yakimova",
                RegisteredOn = new DateTime(2015, 7, 12),
                PhoneNumber = "+359 0859 335 596",
                Courses = new List<Course>()
                {
                    new Course()
                    {
                        Name = "ASP.NET",
                        StartDate = new DateTime(2015, 7, 1),
                        EndDate = new DateTime(2015, 8, 12),
                        Price = 180,
                        Homeworks = new List<Homework>()
                        {
                            new Homework()
                            {
                                Content = "Course Introduction",
                                ContentType = ContentType.Zip,
                                SubmissionDate = new DateTime(2015, 6, 15),
                            }
                        },
                        Resources = new List<Resource>()
                        {
                            new Resource()
                            {
                                Name = "ASP.NET for Beginners",
                                ResourceType = ResourceType.Video,
                                Url = "www.w3c.com/sql",
                            }
                        }
                    }
                }
            });

            context.SaveChanges();
        }
    }
}