namespace Inventory.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Description = c.String(),
                        Added = c.DateTime(nullable: false),
                        Tags = c.String(),
                        Container_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Container", t => t.Container_Id)
                .Index(t => t.Container_Id);
            
            CreateTable(
                "dbo.Container",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Container", "Id", "dbo.Items");
            DropForeignKey("dbo.Items", "Container_Id", "dbo.Container");
            DropIndex("dbo.Container", new[] { "Id" });
            DropIndex("dbo.Items", new[] { "Container_Id" });
            DropTable("dbo.Container");
            DropTable("dbo.Items");
        }
    }
}
