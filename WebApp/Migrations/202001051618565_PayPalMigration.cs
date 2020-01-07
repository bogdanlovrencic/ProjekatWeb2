namespace JGSPNSWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PayPalMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PayPals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TransactionId = c.String(),
                        PayerId = c.String(),
                        PayerEmail = c.String(),
                        IdKarte = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kartas", t => t.IdKarte, cascadeDelete: true)
                .Index(t => t.IdKarte);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PayPals", "IdKarte", "dbo.Kartas");
            DropIndex("dbo.PayPals", new[] { "IdKarte" });
            DropTable("dbo.PayPals");
        }
    }
}
