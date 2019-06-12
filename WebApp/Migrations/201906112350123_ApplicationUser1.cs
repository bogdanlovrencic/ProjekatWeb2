namespace JGSPNSWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicationUser1 : DbMigration
    {
        public override void Up()
        {
           
            AddColumn("dbo.AspNetUsers", "Ime", c => c.String());
            AddColumn("dbo.AspNetUsers", "Prezime", c => c.String());
            AddColumn("dbo.AspNetUsers", "Lozinka", c => c.String());
            AddColumn("dbo.AspNetUsers", "DatumRodjenja", c => c.String());
            AddColumn("dbo.AspNetUsers", "Adresa", c => c.String());
            AddColumn("dbo.AspNetUsers", "TipPutnika", c => c.String());
           
        }
        
        public override void Down()
        {
                    
            DropColumn("dbo.AspNetUsers", "TipPutnika");
            DropColumn("dbo.AspNetUsers", "Adresa");
            DropColumn("dbo.AspNetUsers", "DatumRodjenja");
            DropColumn("dbo.AspNetUsers", "Lozinka");
            DropColumn("dbo.AspNetUsers", "Prezime");
            DropColumn("dbo.AspNetUsers", "Ime");
           
        }
    }
}
