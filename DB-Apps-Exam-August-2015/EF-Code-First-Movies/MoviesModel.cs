namespace EF_Code_First_Movies
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Migrations;
    using Models;

    public class MoviesModel : DbContext
    {
        public MoviesModel()
            : base("name=MoviesModel")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MoviesModel, Configuration>());
        }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}