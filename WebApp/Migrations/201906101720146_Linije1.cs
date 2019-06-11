namespace JGSPNSWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Linije1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
               "dbo.RedVoznjes",
               c => new
               {
                   Id = c.Int(nullable: false, identity: true),
                   DanUNedelji = c.Int(nullable: false),
                   Aktivan = c.Boolean(nullable: false),
               })
               .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Cenovnik1",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    TipKarte = c.String(),
                    Cena = c.Double(nullable: false),
                })
                .PrimaryKey(t => t.Id);
           
        }
        
        public override void Down()
        {
            DropTable("dbo.Cenovnik1");
            DropTable("dbo.RedVoznjes");

        }
    }
}
