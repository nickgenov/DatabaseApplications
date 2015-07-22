using System.Data.Entity.ModelConfiguration.Conventions;
using ForumSystem.Models;
using ForumSystem.Data.Migrations;

namespace ForumSystem.Data
{
    using System.Data.Entity;

    public class ForumContext : DbContext
    {
        public ForumContext()
            : base("name=ForumContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ForumContext,Configuration>());
        }

        //Added change to disable cascade deletion:
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<User>()
                .HasMany(u => u.Friends)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("UserId");
                    m.MapRightKey("FriendId");
                    m.ToTable("UserFriends");
                });

            //modelBuilder.Entity<Question>()
            //    .HasMany(q => q.Answers)
            //    .WithRequired(a => a.Question);

            //this disables cascade delete on Users:
            //same as the conventions above:

            //modelBuilder.Entity<User>()
            //    .HasMany(u => u.Questions)
            //    .WithRequired(q => q.Author)
            //    .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
    }
}