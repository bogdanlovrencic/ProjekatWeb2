namespace JGSPNSWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class izmene : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Korisniks", "Uloga_Naziv", "dbo.Rolas");
            DropIndex("dbo.Korisniks", new[] { "Uloga_Naziv" });
            CreateTable(
                "dbo.Putniks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TipPutnika = c.String(),
                        Korisnik_Email = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Korisniks", t => t.Korisnik_Email)
                .Index(t => t.Korisnik_Email);
            
            AddColumn("dbo.Korisniks", "Uloga", c => c.String());
            DropColumn("dbo.Korisniks", "Uloga_Naziv");
            DropTable("dbo.Rolas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Rolas",
                c => new
                    {
                        Naziv = c.String(nullable: false, maxLength: 128),
                        Sifra = c.Int(nullable: false),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Naziv);
            
            AddColumn("dbo.Korisniks", "Uloga_Naziv", c => c.String(maxLength: 128));
            DropForeignKey("dbo.Putniks", "Korisnik_Email", "dbo.Korisniks");
            DropIndex("dbo.Putniks", new[] { "Korisnik_Email" });
            DropColumn("dbo.Korisniks", "Uloga");
            DropTable("dbo.Putniks");
            CreateIndex("dbo.Korisniks", "Uloga_Naziv");
            AddForeignKey("dbo.Korisniks", "Uloga_Naziv", "dbo.Rolas", "Naziv");
        }
    }
}
