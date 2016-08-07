namespace Inventory.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Inventory.DAL.Context>
    {
        public Configuration() {
            AppDomain.CurrentDomain.SetData("DataDirectory", $@"{new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName}\App_Data");
 
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Inventory.DAL.Context context)
        {
 
            context.SaveChanges();

        }
    }
}
