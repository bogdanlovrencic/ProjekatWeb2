namespace JGSPNSWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CenovnikStavka : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CenovnikStavkas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdCenovnika = c.Int(nullable: false),
                        IdStavke = c.Int(nullable: false),
                        Cena = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cenovniks", t => t.IdCenovnika, cascadeDelete: true)
                .ForeignKey("dbo.Stavkas", t => t.IdStavke, cascadeDelete: true)
                .Index(t => t.IdCenovnika)
                .Index(t => t.IdStavke);
            
            CreateTable(
                "dbo.Stavkas",
                c => new
                    {
                        IdStavke = c.Int(nullable: false, identity: true),
                        VrstaKarte = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdStavke);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CenovnikStavkas", "IdStavke", "dbo.Stavkas");
            DropForeignKey("dbo.CenovnikStavkas", "IdCenovnika", "dbo.Cenovniks");
            DropIndex("dbo.CenovnikStavkas", new[] { "IdStavke" });
            DropIndex("dbo.CenovnikStavkas", new[] { "IdCenovnika" });
            DropTable("dbo.Stavkas");
            DropTable("dbo.CenovnikStavkas");
        }
    }
}
