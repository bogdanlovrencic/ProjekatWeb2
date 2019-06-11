namespace JGSPNSWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Linije : DbMigration
    {
        public override void Up()
        {
            CreateTable(
             "dbo.Linijas",
             c => new
             {
                 IdLinije = c.String(nullable: false, maxLength: 128),
                 TipRedaVoznje = c.String(nullable: false),
                 Relacija = c.String(nullable: false),
             })
             .PrimaryKey(t => t.IdLinije);
        }
        
        public override void Down()
        {
            DropTable("dbo.Linijas");
        }
    }
}
