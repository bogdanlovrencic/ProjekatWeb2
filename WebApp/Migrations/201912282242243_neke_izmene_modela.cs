namespace JGSPNSWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class neke_izmene_modela : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.StatusRegistracijes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.StatusRegistracijes",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 128),
                        ImgUrl = c.String(),
                        Status = c.String(),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Email);
            
        }
    }
}
