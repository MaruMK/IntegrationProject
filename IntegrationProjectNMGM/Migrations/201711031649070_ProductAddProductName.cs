namespace IntegrationProjectNMGM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductAddProductName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ProductName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "ProductName");
        }
    }
}
