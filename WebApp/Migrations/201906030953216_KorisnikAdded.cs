namespace JGSPNSWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KorisnikAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Korisniks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(),
                        Prezime = c.String(),
                        Email = c.String(),
                        Lozinka = c.String(),
                        DatumRodjenja = c.String(),
                        Adresa = c.String(),
                        Uloga = c.Int(nullable: false),
                        Tip = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "KorisnikId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "KorisnikId");
            AddForeignKey("dbo.AspNetUsers", "KorisnikId", "dbo.Korisniks", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "KorisnikId", "dbo.Korisniks");
            DropIndex("dbo.AspNetUsers", new[] { "KorisnikId" });
            DropColumn("dbo.AspNetUsers", "KorisnikId");
            DropTable("dbo.Korisniks");
        }
    }
}
