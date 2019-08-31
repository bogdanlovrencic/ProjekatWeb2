namespace JGSPNSWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class polazak : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Linijas", t => t.LinijaId, cascadeDelete: true)
                .Index(t => t.LinijaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Polazaks", "LinijaId", "dbo.Linijas");
            DropIndex("dbo.Polazaks", new[] { "LinijaId" });
            DropTable("dbo.Polazaks");
        }
    }
}
