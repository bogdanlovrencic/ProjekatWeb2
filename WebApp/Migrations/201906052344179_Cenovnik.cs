namespace JGSPNSWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cenovnik : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cenovniks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VaziOd = c.DateTime(nullable: false),
                        VaziDo = c.DateTime(nullable: false),
                        Aktivan = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Korisniks", "Tip");
            DropColumn("dbo.Korisniks", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Korisniks", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Korisniks", "Tip", c => c.Int());
            DropTable("dbo.Cenovniks");
        }
    }
}
