namespace JGSPNSWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class s : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Kartas", "Korisnik_Email", "dbo.Korisniks");
            DropIndex("dbo.Kartas", new[] { "Korisnik_Email" });
            DropColumn("dbo.Kartas", "Korisnik_Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Kartas", "Korisnik_Email", c => c.String(maxLength: 128));
            CreateIndex("dbo.Kartas", "Korisnik_Email");
            AddForeignKey("dbo.Kartas", "Korisnik_Email", "dbo.Korisniks", "Email");
        }
    }
}
