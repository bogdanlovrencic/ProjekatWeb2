namespace JGSPNSWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Linije : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Linijas",
                c => new
                    {
                        IdLinije = c.Int(nullable: false, identity: true),
                        TipRedaVoznje = c.String(),
                        Relacija = c.String(),
                    })
                .PrimaryKey(t => t.IdLinije);
            
            CreateTable(
                "dbo.Stanicas",
                c => new
                    {
                        Naziv = c.String(nullable: false, maxLength: 128),
                        Adresa = c.String(),
                        KordinataX = c.String(),
                        KordinataY = c.String(),
                    })
                .PrimaryKey(t => t.Naziv);
            
            CreateTable(
                "dbo.StanicaLinijas",
                c => new
                    {
                        Stanica_Naziv = c.String(nullable: false, maxLength: 128),
                        Linija_IdLinije = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Stanica_Naziv, t.Linija_IdLinije })
                .ForeignKey("dbo.Stanicas", t => t.Stanica_Naziv, cascadeDelete: true)
                .ForeignKey("dbo.Linijas", t => t.Linija_IdLinije, cascadeDelete: true)
                .Index(t => t.Stanica_Naziv)
                .Index(t => t.Linija_IdLinije);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StanicaLinijas", "Linija_IdLinije", "dbo.Linijas");
            DropForeignKey("dbo.StanicaLinijas", "Stanica_Naziv", "dbo.Stanicas");
            DropIndex("dbo.StanicaLinijas", new[] { "Linija_IdLinije" });
            DropIndex("dbo.StanicaLinijas", new[] { "Stanica_Naziv" });
            DropTable("dbo.StanicaLinijas");
            DropTable("dbo.Stanicas");
            DropTable("dbo.Linijas");
        }
    }
}
