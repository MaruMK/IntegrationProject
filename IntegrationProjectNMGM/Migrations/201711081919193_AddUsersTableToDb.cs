namespace IntegrationProjectNMGM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUsersTableToDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.String(nullable: false, maxLength: 128),
                        Username = c.String(),
                        FName = c.String(),
                        LName = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
