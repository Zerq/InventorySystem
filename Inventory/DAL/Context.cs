using Inventory.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.DAL {
    public class Context : DbContext {

        public Context(): base("DefaultConnection") {


        }

        public DbSet<Container> Containers { get; set; }
        public DbSet<Item> Items { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder m) {
            base.OnModelCreating(m);
            m.Entity<Item>().HasKey(n => n.Id);    
            m.Entity<Container>().ToTable(typeof(Container).Name);
            m.Entity<Container>().HasMany(n => n.Items).WithOptional(n => n.Container);
        }

    }
}
