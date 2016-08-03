namespace OmnicatzInventory.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OmnicatzInventory.DAL.Context>
    {
        public Configuration()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", $@"{new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName}\App_Data");
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(OmnicatzInventory.DAL.Context context)
        {
            var c1 = new Model.Container { Id = "123abc", Name = "blueTub1", Description = "it's blue... and plastic", Added = DateTime.Now };
            var c2 = new Model.Container { Id = "abc123", Name = "redTub1", Description = "it's red... and plastic", Added = DateTime.Now };
            var c3 = new Model.Container { Id = "1a3a2bc", Name = "greenTub1", Description = "it's greens... and plastic", Added = DateTime.Now };


            context.Containers.AddOrUpdate(
              p => p.Id, c1, c2, c3
             );
            context.SaveChanges();

            context.Items.AddOrUpdate(
          p => p.Id,
          new Model.Item { Id = "1123abc", Name = "shoe", Description = "it's a shoe", Added = DateTime.Now, Container = c1 },
          new Model.Item { Id = "1abc123", Name = "stone", Description = "it's a stone", Added = DateTime.Now, Container = c1 },
          new Model.Item { Id = "11a3a2bc", Name = "monster", Description = "it's a monster", Added = DateTime.Now, Container = c3 }
        );
            context.SaveChanges();
        }
    }
}
