namespace JGSPNSWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class appUserModelModified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
            AddColumn("dbo.AspNetUsers", "Surname", c => c.String());
            AddColumn("dbo.AspNetUsers", "DateOfBirth", c => c.String());
            AddColumn("dbo.AspNetUsers", "Address", c => c.String());
            AddColumn("dbo.AspNetUsers", "UserType", c => c.String());
            AddColumn("dbo.AspNetUsers", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Status");
            DropColumn("dbo.AspNetUsers", "UserType");
            DropColumn("dbo.AspNetUsers", "Address");
            DropColumn("dbo.AspNetUsers", "DateOfBirth");
            DropColumn("dbo.AspNetUsers", "Surname");
            DropColumn("dbo.AspNetUsers", "Name");
        }
    }
}
