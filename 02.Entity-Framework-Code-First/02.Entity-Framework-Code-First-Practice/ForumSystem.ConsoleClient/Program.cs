using System;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
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
                //var questions = context.Questions.Count();
                //Console.WriteLine(questions);

                //var user = new User()
                //{
                //    FirstName = "Nick",
                //    LastName = "Genov",
                //    Gender = Gender.Male,
                //    //Username = "nick.genov",
                //    RegisteredOn = DateTime.Now
                //};

                //context.Users.Add(user);
                //context.SaveChanges();

                //var question = new Question()
                //{
                //    Title = "How do I create a code first project?",
                //    Content = "PLS help.",
                //    AuthorId = 2
                //};

                //context.Questions.Add(question);
                //context.SaveChanges();

                var question = context.Questions.Find(1);
                
                question.Tags.Add(new Tag()
                {
                    Name = "Random questions"
                });
                
                question.Tags.Add(new Tag()
                {
                    Name = "Silly stuff"
                });

                context.SaveChanges();

                foreach (var tag in question.Tags)
                {
                    Console.WriteLine(tag.Name);
                }

                Console.WriteLine(question.Content);
            }
        }
    }
}
