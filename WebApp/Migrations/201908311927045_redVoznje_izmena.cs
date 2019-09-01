namespace JGSPNSWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class redVoznje_izmena : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RedVoznjes", "IzabraniRedVoznje", c => c.String());
            DropColumn("dbo.RedVoznjes", "IzabraniRedaVoznje");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RedVoznjes", "IzabraniRedaVoznje", c => c.String());
            DropColumn("dbo.RedVoznjes", "IzabraniRedVoznje");
        }
    }
}
