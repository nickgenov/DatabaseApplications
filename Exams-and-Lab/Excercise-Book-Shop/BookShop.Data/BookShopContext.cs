namespace BookShop.Data
{
    using System.Data.Entity;
    using BookShop.Models;
    using BookShop.Data.Migrations;

    public class BookShopContext : DbContext
    {
        public BookShopContext()
            : base("BookShopContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookShopContext, Configuration>());
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}