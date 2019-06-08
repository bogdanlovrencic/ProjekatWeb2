namespace JGSPNSWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Karta : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kartas",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        VremeOd = c.DateTime(nullable: false),
                        VremeDo = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Kartas");
        }
    }
}
