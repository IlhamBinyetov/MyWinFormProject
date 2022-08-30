namespace MyWinFormProject.Migrations
{
    using MyWinFormProject.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyWinFormProject.Models.MyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MyWinFormProject.Models.MyDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.


            IList<Detail> defaultDetails = new List<Detail>();

            defaultDetails.Add(new Detail() { Name = "Ilham", Surname = "Binyetov", Address = "Baku", Age = 28, BirthDate = DateTime.Now });
            defaultDetails.Add(new Detail() { Name = "Murad", Surname = "Binyetov", Address = "Qala", Age = 25, BirthDate = DateTime.Now });
            defaultDetails.Add(new Detail() { Name = "Memmed", Surname = "Memmedli", Address = "Seki", Age = 20, BirthDate = DateTime.Now });

            context.Details.AddRange(defaultDetails);

            base.Seed(context);
        }
    }
}
