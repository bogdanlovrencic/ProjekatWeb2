namespace JGSPNSWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class polazak1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RedVoznjes", "Polazak_Id", c => c.Int());
            CreateIndex("dbo.RedVoznjes", "Polazak_Id");
            AddForeignKey("dbo.RedVoznjes", "Polazak_Id", "dbo.Polazaks", "Id");
            DropColumn("dbo.RedVoznjes", "Polazak");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RedVoznjes", "Polazak", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.RedVoznjes", "Polazak_Id", "dbo.Polazaks");
            DropIndex("dbo.RedVoznjes", new[] { "Polazak_Id" });
            DropColumn("dbo.RedVoznjes", "Polazak_Id");
        }
    }
}
