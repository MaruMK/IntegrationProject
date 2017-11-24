namespace IntegrationProjectNMGM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReviewAddUserId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "UserId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reviews", "UserId");
        }
    }
}
