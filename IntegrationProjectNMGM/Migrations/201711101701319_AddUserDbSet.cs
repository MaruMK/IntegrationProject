namespace IntegrationProjectNMGM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserDbSet : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Images", "ProductId", c => c.Int(nullable: false));
            AlterColumn("dbo.Reviews", "ProductId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropIndex("dbo.Reviews", new[] { "ProductId" });
            DropIndex("dbo.Images", new[] { "ProductId" });
            AlterColumn("dbo.Reviews", "ProductId", c => c.Int());
            AlterColumn("dbo.Images", "ProductId", c => c.Int());
            RenameColumn(table: "dbo.Reviews", name: "ProductId", newName: "Product_ProductId");
            RenameColumn(table: "dbo.Images", name: "ProductId", newName: "Product_ProductId");
            CreateIndex("dbo.Reviews", "Product_ProductId");
        }
    }
}
