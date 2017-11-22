namespace IntegrationProjectNMGM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedParentCategory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "ParentCategory_CategoryId", "dbo.Categories");
            DropIndex("dbo.Categories", new[] { "ParentCategory_CategoryId" });
            AddColumn("dbo.Categories", "ParentCategory", c => c.Int(nullable: false));
            DropColumn("dbo.Categories", "ParentCategory_CategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "ParentCategory_CategoryId", c => c.Int());
            DropColumn("dbo.Categories", "ParentCategoryId");
            CreateIndex("dbo.Categories", "ParentCategory_CategoryId");
            AddForeignKey("dbo.Categories", "ParentCategory_CategoryId", "dbo.Categories", "CategoryId");
        }
    }
}
