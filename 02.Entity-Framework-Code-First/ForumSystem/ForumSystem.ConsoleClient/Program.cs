using System;
using System.Linq;
using ForumSystem.Data;

namespace ForumSystem.ConsoleClient
{
    class Program
    {
        static void Main()
        {
            using (var context = new ForumContext())
            {
                var count = context.Questions.Count();
                Console.WriteLine(count);
            }
        }
    }
}