namespace Omnitory.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Omnitory.DAL.Context>
    {
        public Configuration()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", $@"{new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName}\App_Data");

            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Omnitory.DAL.Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
