namespace IntegrationProjectNMGM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelDesignChange12 : DbMigration
    {
        public override void Up()
        {
            AddPrimaryKey("dbo.ProductCategories", new[] { "ProductId", "CategoryId" });
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductCategories", "ProductCategoryId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.ProductCategories");
            AddPrimaryKey("dbo.ProductCategories", "ProductCategoryId");
        }
    }
}
