using Phonebook.Data.Migrations;
using Phonebook.Models;
using System.Data.Entity;

namespace Phonebook.Data
{
    public class PhonebookContext : DbContext
    {
      public PhonebookContext()
            : base("PhonebookContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PhonebookContext, Configuration>());
        }

        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Email> Emails { get; set; }
        public virtual DbSet<Phone> Phones { get; set; }
    }
}