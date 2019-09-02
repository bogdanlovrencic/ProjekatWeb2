namespace JGSPNSWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class korisnik_izmena : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Korisniks", "Aktivan", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Korisniks", "Aktivan");
        }
    }
}
