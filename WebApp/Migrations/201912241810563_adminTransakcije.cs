namespace JGSPNSWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adminTransakcije : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StanicaLinijas", "Stanica_Id", "dbo.Stanicas");
            DropForeignKey("dbo.StanicaLinijas", "Linija_Id", "dbo.Linijas");
            DropForeignKey("dbo.Putniks", "Korisnik_Email", "dbo.Korisniks");
            DropIndex("dbo.Putniks", new[] { "Korisnik_Email" });
            DropIndex("dbo.StanicaLinijas", new[] { "Stanica_Id" });
            DropIndex("dbo.StanicaLinijas", new[] { "Linija_Id" });
            AddColumn("dbo.Cenovniks", "Version", c => c.Long(nullable: false));
            AddColumn("dbo.Korisniks", "Version", c => c.Long(nullable: false));
            AddColumn("dbo.Linijas", "Version", c => c.Long(nullable: false));
            AddColumn("dbo.Stanicas", "Version", c => c.Long(nullable: false));
            AddColumn("dbo.Stanicas", "Linija_Id", c => c.Int());
            AddColumn("dbo.RedVoznjes", "Version", c => c.Long(nullable: false));
            CreateIndex("dbo.Stanicas", "Linija_Id");
            AddForeignKey("dbo.Stanicas", "Linija_Id", "dbo.Linijas", "Id");
            DropTable("dbo.Putniks");
            DropTable("dbo.StanicaLinijas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.StanicaLinijas",
                c => new
                    {
                        Stanica_Id = c.Int(nullable: false),
                        Linija_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Stanica_Id, t.Linija_Id });
            
            CreateTable(
                "dbo.Putniks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TipPutnika = c.String(),
                        Korisnik_Email = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Stanicas", "Linija_Id", "dbo.Linijas");
            DropIndex("dbo.Stanicas", new[] { "Linija_Id" });
            DropColumn("dbo.RedVoznjes", "Version");
            DropColumn("dbo.Stanicas", "Linija_Id");
            DropColumn("dbo.Stanicas", "Version");
            DropColumn("dbo.Linijas", "Version");
            DropColumn("dbo.Korisniks", "Version");
            DropColumn("dbo.Cenovniks", "Version");
            CreateIndex("dbo.StanicaLinijas", "Linija_Id");
            CreateIndex("dbo.StanicaLinijas", "Stanica_Id");
            CreateIndex("dbo.Putniks", "Korisnik_Email");
            AddForeignKey("dbo.Putniks", "Korisnik_Email", "dbo.Korisniks", "Email");
            AddForeignKey("dbo.StanicaLinijas", "Linija_Id", "dbo.Linijas", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StanicaLinijas", "Stanica_Id", "dbo.Stanicas", "Id", cascadeDelete: true);
        }
    }
}
