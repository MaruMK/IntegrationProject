namespace IntegrationProjectNMGM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SomeUnknownChange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Images", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Reviews", "ProductId", "dbo.Products");
            DropIndex("dbo.Images", new[] { "ProductId" });
            DropIndex("dbo.Reviews", new[] { "ProductId" });
            RenameColumn(table: "dbo.Images", name: "ProductId", newName: "ProductId");
            RenameColumn(table: "dbo.Reviews", name: "ProductId", newName: "ProductId");
            AlterColumn("dbo.Images", "ProductId", c => c.Int(nullable: false));
            AlterColumn("dbo.Reviews", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.Images", "ProductId");
            CreateIndex("dbo.Reviews", "ProductId");
            AddForeignKey("dbo.Images", "ProductId", "dbo.Products", "ProductId", cascadeDelete: true);
            AddForeignKey("dbo.Reviews", "ProductId", "dbo.Products", "ProductId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Images", "ProductId", "dbo.Products");
            DropIndex("dbo.Reviews", new[] { "ProductId" });
            DropIndex("dbo.Images", new[] { "ProductId" });
            AlterColumn("dbo.Reviews", "ProductId", c => c.Int());
            AlterColumn("dbo.Images", "ProductId", c => c.Int());
            RenameColumn(table: "dbo.Reviews", name: "ProductId", newName: "Product_ProductId");
            RenameColumn(table: "dbo.Images", name: "ProductId", newName: "Product_ProductId");
            CreateIndex("dbo.Reviews", "Product_ProductId");
            CreateIndex("dbo.Images", "Product_ProductId");
            AddForeignKey("dbo.Reviews", "Product_ProductId", "dbo.Products", "ProductId");
            AddForeignKey("dbo.Images", "Product_ProductId", "dbo.Products", "ProductId");
        }
    }
}
