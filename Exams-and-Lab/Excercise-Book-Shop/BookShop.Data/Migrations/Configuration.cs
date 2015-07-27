using System.Globalization;
using System.IO;
using BookShop.Models.Enums;

namespace BookShop.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using BookShop.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<BookShop.Data.BookShopContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationDataLossAllowed = true;
            this.AutomaticMigrationsEnabled = true;
            this.ContextKey = "BookShop.Data.BookShopContext";
        }

        protected override void Seed(BookShop.Data.BookShopContext context)
        {
            //using (var reader = new StreamReader("../../SeedData/books.txt"))
            //{
            //    var random = new Random();
            //    var line = reader.ReadLine();
            //    line = reader.ReadLine();
            //    while (line != null)
            //    {
            //        var data = line.Split(new[] { ' ' }, 6);
            //        var authorIndex = random.Next(0, authors.Count);
            //        var author = authors[authorIndex];
            //        var edition = (EditionType)int.Parse(data[0]);
            //        var releaseDate = DateTime.ParseExact(data[1], "d/M/yyyy", CultureInfo.InvariantCulture);
            //        var copies = int.Parse(data[2]);
            //        var price = decimal.Parse(data[3]);
            //        var ageRestriction = (AgeRestriction)int.Parse(data[4]);
            //        var title = data[5];

            //        context.Books.Add(new Book()
            //        {
            //            Author = author,
            //            Edition = edition,
            //            ReleaseDate = releaseDate,
            //            Copies = copies,
            //            Price = price,
            //            AgeRestriction = ageRestriction,
            //            Title = title
            //        });

            //        line = reader.ReadLine();
            //    }
            //}

        }
    }
}