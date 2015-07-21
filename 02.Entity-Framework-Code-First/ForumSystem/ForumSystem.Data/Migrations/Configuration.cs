using ForumSystem.Models;

namespace ForumSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ForumSystem.Data.ForumContext>
    {
        public Configuration()
        {
            AutomaticMigrationDataLossAllowed = true;
            this.AutomaticMigrationsEnabled = true;
            this.ContextKey = "ForumSystem.Data.ForumContext";
        }

        protected override void Seed(ForumContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Users.AddOrUpdate(
                u => u.Username,
                new User()
                {
                    UserInfo = new UserInfo()
                    {
                        FirstName = "Stamat",
                        LastName = "Penkov",
                        Age = 33,
                    },
                    Username = "Stamatkata",
                    Gender = Gender.Male,
                    RegisteredOn = DateTime.Now,
                });

            context.SaveChanges();
        }
    }
}