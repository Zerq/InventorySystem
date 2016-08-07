namespace Omnitory.Migrations
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
                        Container_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Containers", t => t.Container_Id)
                .Index(t => t.Container_Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ItemTags",
                c => new
                    {
                        Item_Id = c.String(nullable: false, maxLength: 128),
                        Tag_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Item_Id, t.Tag_Id })
                .ForeignKey("dbo.Items", t => t.Item_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .Index(t => t.Item_Id)
                .Index(t => t.Tag_Id);
            
            CreateTable(
                "dbo.Containers",
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
            DropForeignKey("dbo.Containers", "Id", "dbo.Items");
            DropForeignKey("dbo.Items", "Container_Id", "dbo.Containers");
            DropForeignKey("dbo.ItemTags", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.ItemTags", "Item_Id", "dbo.Items");
            DropIndex("dbo.Containers", new[] { "Id" });
            DropIndex("dbo.ItemTags", new[] { "Tag_Id" });
            DropIndex("dbo.ItemTags", new[] { "Item_Id" });
            DropIndex("dbo.Items", new[] { "Container_Id" });
            DropTable("dbo.Containers");
            DropTable("dbo.ItemTags");
            DropTable("dbo.Tags");
            DropTable("dbo.Items");
        }
    }
}
