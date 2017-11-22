namespace IntegrationProjectNMGM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserManagerChangeProductParentCategory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "ParentCategory_CategoryId", "dbo.Categories");
            DropIndex("dbo.Categories", new[] { "ParentCategory_CategoryId" });
            AddColumn("dbo.Categories", "ParentCategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "Manager", c => c.Boolean(nullable: false));
            DropColumn("dbo.Categories", "ParentCategory_CategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "ParentCategory_CategoryId", c => c.Int());
            DropColumn("dbo.Users", "Manager");
            DropColumn("dbo.Categories", "ParentCategoryId");
            CreateIndex("dbo.Categories", "ParentCategory_CategoryId");
            AddForeignKey("dbo.Categories", "ParentCategory_CategoryId", "dbo.Categories", "CategoryId");
        }
    }
}
