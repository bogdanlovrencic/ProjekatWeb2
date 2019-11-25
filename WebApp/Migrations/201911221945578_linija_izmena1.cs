namespace JGSPNSWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class linija_izmena1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Linijas", "Naziv", c => c.String());
            DropColumn("dbo.Linijas", "RedniBroj");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Linijas", "RedniBroj", c => c.String());
            DropColumn("dbo.Linijas", "Naziv");
        }
    }
}
