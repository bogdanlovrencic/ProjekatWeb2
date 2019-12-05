namespace JGSPNSWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stavka_izmena : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CenovnikStavkas", "Cena", c => c.Double(nullable: false));
            DropColumn("dbo.Stavkas", "Cena");
            DropColumn("dbo.Stavkas", "Aktivna");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stavkas", "Aktivna", c => c.Boolean(nullable: false));
            AddColumn("dbo.Stavkas", "Cena", c => c.Double(nullable: false));
            DropColumn("dbo.CenovnikStavkas", "Cena");
        }
    }
}
