namespace JGSPNSWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class korisnik : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Uloga_Naziv", "dbo.Rolas");
            DropIndex("dbo.AspNetUsers", new[] { "Uloga_Naziv" });
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
                        Verifikovan = c.Boolean(nullable: false),
                        Status = c.String(),
                        ImageUrl = c.String(),
                        Uloga_Naziv = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Email)
                .ForeignKey("dbo.Rolas", t => t.Uloga_Naziv)
                .Index(t => t.Uloga_Naziv);
            
            AddColumn("dbo.Kartas", "Korisnik_Email", c => c.String(maxLength: 128));
            CreateIndex("dbo.Kartas", "Korisnik_Email");
            AddForeignKey("dbo.Kartas", "Korisnik_Email", "dbo.Korisniks", "Email");
            DropColumn("dbo.AspNetUsers", "Ime");
            DropColumn("dbo.AspNetUsers", "Prezime");
            DropColumn("dbo.AspNetUsers", "Lozinka");
            DropColumn("dbo.AspNetUsers", "DatumRodjenja");
            DropColumn("dbo.AspNetUsers", "Adresa");
            DropColumn("dbo.AspNetUsers", "TipPutnika");
            DropColumn("dbo.AspNetUsers", "ImageUrl");
            DropColumn("dbo.AspNetUsers", "Status");
            DropColumn("dbo.AspNetUsers", "Verifikovan");
            DropColumn("dbo.AspNetUsers", "Uloga_Naziv");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Uloga_Naziv", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "Verifikovan", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "Status", c => c.String());
            AddColumn("dbo.AspNetUsers", "ImageUrl", c => c.String());
            AddColumn("dbo.AspNetUsers", "TipPutnika", c => c.String());
            AddColumn("dbo.AspNetUsers", "Adresa", c => c.String());
            AddColumn("dbo.AspNetUsers", "DatumRodjenja", c => c.String());
            AddColumn("dbo.AspNetUsers", "Lozinka", c => c.String());
            AddColumn("dbo.AspNetUsers", "Prezime", c => c.String());
            AddColumn("dbo.AspNetUsers", "Ime", c => c.String());
            DropForeignKey("dbo.Korisniks", "Uloga_Naziv", "dbo.Rolas");
            DropForeignKey("dbo.Kartas", "Korisnik_Email", "dbo.Korisniks");
            DropIndex("dbo.Korisniks", new[] { "Uloga_Naziv" });
            DropIndex("dbo.Kartas", new[] { "Korisnik_Email" });
            DropColumn("dbo.Kartas", "Korisnik_Email");
            DropTable("dbo.Korisniks");
            CreateIndex("dbo.AspNetUsers", "Uloga_Naziv");
            AddForeignKey("dbo.AspNetUsers", "Uloga_Naziv", "dbo.Rolas", "Naziv");
        }
    }
}
