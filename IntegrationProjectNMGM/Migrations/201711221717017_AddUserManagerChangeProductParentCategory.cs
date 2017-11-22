namespace IntegrationProjectNMGM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserManagerChangeProductParentCategory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "ParentCategoryId", "dbo.Categories");
            DropIndex("dbo.Categories", new[] { "ParentCategoryId" });
            AddColumn("dbo.Categories", "ParentCategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "Manager", c => c.Boolean(nullable: false));
            DropColumn("dbo.Categories", "ParentCategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "ParentCategoryId", c => c.Int());
            DropColumn("dbo.Users", "Manager");
            DropColumn("dbo.Categories", "ParentCategoryId");
            CreateIndex("dbo.Categories", "ParentCategoryId");
            AddForeignKey("dbo.Categories", "ParentCategoryId", "dbo.Categories", "CategoryId");
        }
    }
}
