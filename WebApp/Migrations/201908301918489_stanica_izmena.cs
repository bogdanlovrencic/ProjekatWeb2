namespace JGSPNSWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stanica_izmena : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stanicas", "Lat", c => c.Double(nullable: false));
            AddColumn("dbo.Stanicas", "Lon", c => c.Double(nullable: false));
            DropColumn("dbo.Stanicas", "KordinataX");
            DropColumn("dbo.Stanicas", "KordinataY");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stanicas", "KordinataY", c => c.String());
            AddColumn("dbo.Stanicas", "KordinataX", c => c.String());
            DropColumn("dbo.Stanicas", "Lon");
            DropColumn("dbo.Stanicas", "Lat");
        }
    }
}
