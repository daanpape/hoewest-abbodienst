using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using System.Data.Entity.Migrations;

using AbonnementenDienst.Models;

namespace AbonnementenDienst.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Models.MagazineContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Models.MagazineContext context)
        {
            // Add one demo magazine entry 
            //context.Magazines.Add(new Magazine
            //{
            //    ID = 1,
            //    name = "PC Magazine",
            //    price = 2.50M,
            //    publisher = new Publisher { ID = 1, name = "Minoc Media Services" },
            //    category = new Category { ID = 1, name = "Computer" }
            //});

            //base.Seed(context);
        }
    }
}