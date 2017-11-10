namespace IntegrationProjectNMGM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ColorAddProductFields : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Colors", "Product_ProductId", "dbo.Products");
            DropIndex("dbo.Colors", new[] { "Product_ProductId" });
            RenameColumn(table: "dbo.Colors", name: "Product_ProductId", newName: "ProductId");
            AlterColumn("dbo.Colors", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.Colors", "ProductId");
            AddForeignKey("dbo.Colors", "ProductId", "dbo.Products", "ProductId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Colors", "ProductId", "dbo.Products");
            DropIndex("dbo.Colors", new[] { "ProductId" });
            AlterColumn("dbo.Colors", "ProductId", c => c.Int());
            RenameColumn(table: "dbo.Colors", name: "ProductId", newName: "Product_ProductId");
            CreateIndex("dbo.Colors", "Product_ProductId");
            AddForeignKey("dbo.Colors", "Product_ProductId", "dbo.Products", "ProductId");
        }
    }
}
