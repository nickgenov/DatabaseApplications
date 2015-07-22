using System;
using ForumSystem.Data;
using ForumSystem.Models;

namespace ForumSystem.ConsoleClient
{
    class Program
    {
        static void Main()
        {
            using (var context = new ForumContext())
            {
                var user = new User()
                {
                    UserInfo = new UserInfo()
                    {
                        FirstName = "Nick",
                        LastName = "Genov"
                    },
                    Gender = Gender.Male,
                    Username = "genov",
                    RegisteredOn = DateTime.Now
                };

                context.Users.Add(user);
                context.SaveChanges();

                var question = new Question()
                {
                    Content = "Exam preparation",
                    Title = "C# Exam",
                    AuthorId = 1
                };

                context.Questions.Add(question);
                context.SaveChanges();

                user = context.Users.Find(2);
                Console.WriteLine(user.UserInfo.FirstName);

                question.Tags.Add(new Tag
                {
                    Name = "Homework"
                });
                question.Tags.Add(new Tag()
                {
                    Name = "Exam"
                });
                context.SaveChanges();

                foreach (var tag in question.Tags)
                {
                    Console.WriteLine(tag.Name);
                }


            }
        }
    }
}