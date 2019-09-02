namespace JGSPNSWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class izmena_modela : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stavkas", "Aktivna", c => c.Boolean(nullable: false));
            AddColumn("dbo.Linijas", "Aktivna", c => c.Boolean(nullable: false));
            AddColumn("dbo.Stanicas", "Aktivna", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Stanicas", "Aktivna");
            DropColumn("dbo.Linijas", "Aktivna");
            DropColumn("dbo.Stavkas", "Aktivna");
        }
    }
}
