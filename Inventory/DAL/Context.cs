﻿using Inventory.Model;
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
        public Context(): base("DefaultConnection") {}
        public DbSet<Item> Items { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Container> Containers { get; set; }
           
     
        protected override void OnModelCreating(DbModelBuilder m) {
            base.OnModelCreating(m);
    
            m.Entity<Item>().HasKey(n => n.Id);
            m.Entity<Item>().HasMany(n => n.Tags).WithMany();    
            m.Entity<Container>().ToTable("Containers");
            m.Entity<Container>().HasMany(n => n.Items).WithOptional(n => n.Container);

            m.Entity<Tag>().HasKey(n => n.Id);
        }
    }
}
