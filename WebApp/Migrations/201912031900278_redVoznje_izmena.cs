namespace JGSPNSWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class redVoznje_izmena : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RedVoznjes", "Polasci", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RedVoznjes", "Polasci");
        }
    }
}
