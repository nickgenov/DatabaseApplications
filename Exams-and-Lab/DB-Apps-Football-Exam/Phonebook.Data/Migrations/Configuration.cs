using System.Collections.Generic;
using Phonebook.Models;

namespace Phonebook.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Phonebook.Data;

    internal sealed class Configuration : DbMigrationsConfiguration<Phonebook.Data.PhonebookContext>
    {
        public Configuration()
        {
            AutomaticMigrationDataLossAllowed = true;
            AutomaticMigrationsEnabled = true;
            ContextKey = "Phonebook.Data.PhonebookContext";
        }

        protected override void Seed(PhonebookContext context)
        {
            context.Contacts.AddOrUpdate(
                c => c.Name,
                new Contact()
                {
                    Name = "Peter Ivanov",
                    Position = "CTO",
                    Company = "Smart Ideas",
                    Emails = new List<Email>() { new Email(){ EmailAddress = "peter@gmail.com"},new Email(){EmailAddress = "peter_ivanov@yahoo.com"}},
                    Phones = new List<Phone>() { new Phone() { PhoneNumber = "+359 2 22 22 22" }, new Phone() { PhoneNumber = "+359 88 77 88 99" } },
                    Url = "http://blog.peter.com",
                    Notes = "Friend from school"
                }
                );

            context.Contacts.AddOrUpdate(
                c => c.Name,
                new Contact()
                {
                    Name = "Maria",
                    Phones = new List<Phone>() { new Phone() { PhoneNumber = "+359 22 33 44 55" } }
                }
                );

            context.Contacts.AddOrUpdate(
                c => c.Name,
                new Contact()
                {
                    Name = "Angie Stanton",
                    Emails = new List<Email>() { new Email() { EmailAddress = "info@angiestanton.com" } },
                    Phones = new List<Phone>() { new Phone() { PhoneNumber = "http://angiestanton.com" } }
                }
                
                );
        }
    }
}
