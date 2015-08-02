using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace EF_Code_First_Movies.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<MoviesModel>
    {
        public Configuration()
        {
            this.AutomaticMigrationDataLossAllowed = true;
            this.AutomaticMigrationsEnabled = true;
            this.ContextKey = "MoviesModel";
        }

        protected override void Seed(MoviesModel context)
        {

        }
    }
}