namespace JGSPNSWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class redVoznje_izmena1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RedVoznjes", "Polazak_Id", "dbo.Polazaks");
            DropForeignKey("dbo.RedVoznjes", "IzabranaLinija_Id", "dbo.Linijas");
            DropIndex("dbo.RedVoznjes", new[] { "IzabranaLinija_Id" });
            DropIndex("dbo.RedVoznjes", new[] { "Polazak_Id" });
            RenameColumn(table: "dbo.RedVoznjes", name: "IzabranaLinija_Id", newName: "LinijaId");
            AlterColumn("dbo.RedVoznjes", "LinijaId", c => c.Int(nullable: false));
            CreateIndex("dbo.RedVoznjes", "LinijaId");
            AddForeignKey("dbo.RedVoznjes", "LinijaId", "dbo.Linijas", "Id", cascadeDelete: true);
            DropColumn("dbo.RedVoznjes", "Polazak_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RedVoznjes", "Polazak_Id", c => c.Int());
            DropForeignKey("dbo.RedVoznjes", "LinijaId", "dbo.Linijas");
            DropIndex("dbo.RedVoznjes", new[] { "LinijaId" });
            AlterColumn("dbo.RedVoznjes", "LinijaId", c => c.Int());
            RenameColumn(table: "dbo.RedVoznjes", name: "LinijaId", newName: "IzabranaLinija_Id");
            CreateIndex("dbo.RedVoznjes", "Polazak_Id");
            CreateIndex("dbo.RedVoznjes", "IzabranaLinija_Id");
            AddForeignKey("dbo.RedVoznjes", "IzabranaLinija_Id", "dbo.Linijas", "Id");
            AddForeignKey("dbo.RedVoznjes", "Polazak_Id", "dbo.Polazaks", "Id");
        }
    }
}
