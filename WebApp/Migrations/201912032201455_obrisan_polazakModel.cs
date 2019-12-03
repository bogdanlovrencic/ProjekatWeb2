namespace JGSPNSWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class obrisan_polazakModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Polazaks", "LinijaId", "dbo.Linijas");
            DropIndex("dbo.Polazaks", new[] { "LinijaId" });
            DropTable("dbo.Polazaks");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Polazaks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Vreme = c.String(),
                        TipDana = c.String(),
                        LinijaId = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Polazaks", "LinijaId");
            AddForeignKey("dbo.Polazaks", "LinijaId", "dbo.Linijas", "Id", cascadeDelete: true);
        }
    }
}
