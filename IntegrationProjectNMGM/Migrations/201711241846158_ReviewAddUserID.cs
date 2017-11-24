namespace IntegrationProjectNMGM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReviewAddUserID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "UserID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reviews", "UserID");
        }
    }
}
