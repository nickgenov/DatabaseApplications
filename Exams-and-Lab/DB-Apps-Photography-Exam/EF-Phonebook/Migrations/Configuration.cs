using EF_Phonebook.Model;

namespace EF_Phonebook.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EF_Phonebook.PhonebookModel>
    {
        public Configuration()
        {
            AutomaticMigrationDataLossAllowed = true;
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(EF_Phonebook.PhonebookModel context)
        {
            
            context.Users.AddOrUpdate(
                u => u.Username,
                new User()
                {
                    Username = "VGeorgiev", 
                    FullName = "Vladimir Georgiev", 
                    PhoneNumber = "0894545454"
                },
                new User()
                {
                    Username = "Nakov",
                    FullName = "Svetlin Nakov",
                    PhoneNumber = "0897878787"
                },
                new User()
                {
                    Username = "Ache",
                    FullName = "Angel Georgiev",
                    PhoneNumber = "0897121212"
                },
                new User()
                {
                    Username = "Alex",
                    FullName = "Alexandra Svilarova",
                    PhoneNumber = "0894151417"
                },
                new User()
                {
                    Username = "Petya",
                    FullName = "Petya Grozdarska",
                    PhoneNumber = "0895464646"
                }
            );

            context.Channels.AddOrUpdate(
                c => c.Name,
                new Channel() { Name = "Malinki" },
                new Channel() { Name = "SoftUni" },
                new Channel() { Name = "Admins" },
                new Channel() { Name = "Programmers" },
                new Channel() { Name = "Geeks" }
            );

            context.ChannelMessages.AddOrUpdate(
                cm => cm.Content,
                new ChannelMessage() 
                { 
                    Channel = context.Channels.FirstOrDefault(c => c.Name == "Malinki"),
                    Content = "Hey dudes, are you ready for tonight?",
                    DateTime = DateTime.Now,
                    User = context.Users.FirstOrDefault(u => u.Username == "Petya")
                },
                new ChannelMessage() 
                { 
                    Channel = context.Channels.FirstOrDefault(c => c.Name == "Malinki"),
                    Content = "Hey Petya, this is the SoftUni chat.",
                    DateTime = DateTime.Now,
                    User = context.Users.FirstOrDefault(u => u.Username == "VGeorgiev")
                },
                new ChannelMessage() 
                { 
                    Channel = context.Channels.FirstOrDefault(c => c.Name == "Malinki"),
                    Content = "Hahaha, we are ready!",
                    DateTime = DateTime.Now,
                    User = context.Users.FirstOrDefault(u => u.Username == "Nakov")
                },
                new ChannelMessage() 
                { 
                    Channel = context.Channels.FirstOrDefault(c => c.Name == "Malinki"),
                    Content = "Oh my god. I mean for drinking beers!",
                    DateTime = DateTime.Now,
                    User = context.Users.FirstOrDefault(u => u.Username == "Petya")
                },
                new ChannelMessage() 
                { 
                    Channel = context.Channels.FirstOrDefault(c => c.Name == "Malinki"),
                    Content = "We are sure!",
                    DateTime = DateTime.Now,
                    User = context.Users.FirstOrDefault(u => u.Username == "VGeorgiev")
                }
            );
        }
    }
}