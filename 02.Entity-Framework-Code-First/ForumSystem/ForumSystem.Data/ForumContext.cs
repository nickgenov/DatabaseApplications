using ForumSystem.Models;

namespace ForumSystem.Data
{
    using System.Data.Entity;

    public class ForumContext : DbContext
    {
        public ForumContext()
            : base("name=ForumContext")
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
    }
}