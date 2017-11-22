namespace IntegrationProjectNMGM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeUserUserID : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "UserID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Users", "UserID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "UserID", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Users", "UserID");
        }
    }
}
