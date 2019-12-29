namespace JGSPNSWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uklonjenKorisnik2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Kartas", "IdKorisnika", "dbo.Korisniks");
            DropIndex("dbo.Kartas", new[] { "IdKorisnika" });
            AddColumn("dbo.Kartas", "IdApplicationUser", c => c.String(maxLength: 128));
            CreateIndex("dbo.Kartas", "IdApplicationUser");
            AddForeignKey("dbo.Kartas", "IdApplicationUser", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Kartas", "IdKorisnika");
            DropTable("dbo.Korisniks");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Korisniks",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 128),
                        Ime = c.String(),
                        Prezime = c.String(),
                        DatumRodjenja = c.DateTime(nullable: false),
                        Adresa = c.String(),
                        Lozinka = c.String(),
                        Uloga = c.String(),
                        TipPutnika = c.String(),
                        Status = c.String(),
                        ImageUrl = c.String(),
                        Aktivan = c.Boolean(nullable: false),
                        Version = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Email);
            
            AddColumn("dbo.Kartas", "IdKorisnika", c => c.String(maxLength: 128));
            DropForeignKey("dbo.Kartas", "IdApplicationUser", "dbo.AspNetUsers");
            DropIndex("dbo.Kartas", new[] { "IdApplicationUser" });
            DropColumn("dbo.Kartas", "IdApplicationUser");
            CreateIndex("dbo.Kartas", "IdKorisnika");
            AddForeignKey("dbo.Kartas", "IdKorisnika", "dbo.Korisniks", "Email");
        }
    }
}
