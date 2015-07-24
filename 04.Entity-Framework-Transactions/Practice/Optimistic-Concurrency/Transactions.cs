using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using EntityFramework.Extensions;

namespace Optimistic_Concurrency
{
    class Transactions
    {
        static void Main()
        {
            AddProject();
            ConflictingChangesOptimistic();

            AddTown();
            ConflictingChangesPessimistic();
        }

        private static void AddProject()
        {
            using (var context = new SoftUniEntities())
            {
                var project = new Project()
                {
                    Name = "New project",
                    Description = "some description",
                    StartDate = new DateTime(2015, 1, 1),
                    EndDate = new DateTime(2015, 12, 31)
                };

                context.Projects.Add(project);
                context.SaveChanges();
            }
        }
        private static void ConflictingChangesOptimistic()
        {
            //first user changes the project name
            var contextFirst = new SoftUniEntities();
            var projectFirstUser = contextFirst.Projects
                .OrderByDescending(p => p.ProjectID)
                .First();
            projectFirstUser.Name = "changed by the first user";

            //second user changes the same project name
            var contextSecond = new SoftUniEntities();
            var projectSecondUser = contextSecond.Projects
                .OrderByDescending(p => p.ProjectID)
                .First();
            projectSecondUser.Name = "changed by the second user";

            //the last change wins
            contextFirst.SaveChanges();
            contextSecond.SaveChanges();
        }
        private static void AddTown()
        {
            using (var context = new SoftUniEntities())
            {
                context.Towns.Add(new Town()
                {
                    Name = "New Town"
                });
                context.SaveChanges();
            }
        }
        private static void ConflictingChangesPessimistic()
        {
            var contextFirst = new SoftUniEntities();

            var townFirst = contextFirst.Towns
                .OrderByDescending(t => t.TownID)
                .First();
            townFirst.Name = "changed by the first user";

            var contextSecond = new SoftUniEntities();

            var townSecond = contextSecond.Towns
                .OrderByDescending(t => t.TownID)
                .First();
            townSecond.Name = "changed by the second user";

            contextFirst.SaveChanges();
            try
            {
                contextSecond.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Console.WriteLine("Conflicting update occurred.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}