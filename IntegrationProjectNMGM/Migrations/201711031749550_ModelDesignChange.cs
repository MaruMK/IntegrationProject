namespace IntegrationProjectNMGM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelDesignChange : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ProductCategories");
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        ColorId = c.Int(nullable: false, identity: true),
                        ColorName = c.String(),
                        ColorHex = c.String(),
                        Product_ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.ColorId)
                .ForeignKey("dbo.Products", t => t.Product_ProductId)
                .Index(t => t.Product_ProductId);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ImageId = c.Int(nullable: false, identity: true),
                        ImageName = c.String(),
                        ImagePath = c.String(),
                        Product_ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.ImageId)
                .ForeignKey("dbo.Products", t => t.Product_ProductId)
                .Index(t => t.Product_ProductId);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ReviewId = c.Int(nullable: false, identity: true),
                        ReviewDescription = c.String(maxLength: 2500),
                        Rating = c.String(),
                        Product_ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.ReviewId)
                .ForeignKey("dbo.Products", t => t.Product_ProductId)
                .Index(t => t.Product_ProductId);
            
            AddColumn("dbo.Categories", "ParentCategory_CategoryId", c => c.Int());
            AddColumn("dbo.Products", "MSRP", c => c.Double(nullable: false));
            AddColumn("dbo.Products", "CurrentPrice", c => c.Double(nullable: false));
            AddColumn("dbo.Products", "Enabled", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Categories", "ParentCategory_CategoryId");
            AddForeignKey("dbo.Categories", "ParentCategory_CategoryId", "dbo.Categories", "CategoryId");
            DropColumn("dbo.ProductCategories", "ProductBookId");
            DropColumn("dbo.Products", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Price", c => c.Double(nullable: false));
            AddColumn("dbo.ProductCategories", "ProductBookId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Reviews", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.Images", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.Colors", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.Categories", "ParentCategory_CategoryId", "dbo.Categories");
            DropIndex("dbo.Reviews", new[] { "Product_ProductId" });
            DropIndex("dbo.Images", new[] { "Product_ProductId" });
            DropIndex("dbo.Colors", new[] { "Product_ProductId" });
            DropIndex("dbo.Categories", new[] { "ParentCategory_CategoryId" });
            DropPrimaryKey("dbo.ProductCategories");
            DropColumn("dbo.Products", "Enabled");
            DropColumn("dbo.Products", "CurrentPrice");
            DropColumn("dbo.Products", "MSRP");
            DropColumn("dbo.ProductCategories", "ProductCategoryId");
            DropColumn("dbo.Categories", "ParentCategory_CategoryId");
            DropTable("dbo.Reviews");
            DropTable("dbo.Images");
            DropTable("dbo.Colors");
            AddPrimaryKey("dbo.ProductCategories", "ProductBookId");
        }
    }
}
