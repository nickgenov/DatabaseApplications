using System.Data.Entity.ModelConfiguration.Conventions;
using EF_Phonebook.Migrations;
using EF_Phonebook.Model;

namespace EF_Phonebook
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PhonebookModel : DbContext
    {
        public PhonebookModel()
            : base("PhonebookModel")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PhonebookModel, Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserMessage>()
                .HasRequired(x => x.Sender)
                .WithMany(x => x.SentUserMessages)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserMessage>()
                .HasRequired(x => x.Recipient)
                .WithMany(x => x.RecievedUserMessages)
                .WillCascadeOnDelete(false);
        }

        public virtual DbSet<Channel> Channels { get; set; }
        public virtual DbSet<ChannelMessage> ChannelMessages { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserMessage> UserMessages { get; set; }
    }
}