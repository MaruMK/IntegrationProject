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
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Categories", "ParentCategory_CategoryId");
            AddForeignKey("dbo.Categories", "ParentCategory_CategoryId", "dbo.Categories", "CategoryId");
        }
    }
}
