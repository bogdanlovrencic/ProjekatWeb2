namespace JGSPNSWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class linija_izmena : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Linijas", "TipLinije", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Linijas", "TipLinije");
        }
    }
}
