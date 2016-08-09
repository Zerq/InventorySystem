namespace Omnitory.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init3 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Items", name: "Container_Id", newName: "ContainerId");
            RenameIndex(table: "dbo.Items", name: "IX_Container_Id", newName: "IX_ContainerId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Items", name: "IX_ContainerId", newName: "IX_Container_Id");
            RenameColumn(table: "dbo.Items", name: "ContainerId", newName: "Container_Id");
        }
    }
}
