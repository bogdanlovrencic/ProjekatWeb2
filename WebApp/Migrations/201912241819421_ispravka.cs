namespace JGSPNSWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ispravka : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Stanicas", "Linija_Id", "dbo.Linijas");
            DropIndex("dbo.Stanicas", new[] { "Linija_Id" });
            CreateTable(
                "dbo.StanicaLinijas",
                c => new
                    {
                        Stanica_Id = c.Int(nullable: false),
                        Linija_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Stanica_Id, t.Linija_Id })
                .ForeignKey("dbo.Stanicas", t => t.Stanica_Id, cascadeDelete: true)
                .ForeignKey("dbo.Linijas", t => t.Linija_Id, cascadeDelete: true)
                .Index(t => t.Stanica_Id)
                .Index(t => t.Linija_Id);
            
            DropColumn("dbo.Stanicas", "Linija_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stanicas", "Linija_Id", c => c.Int());
            DropForeignKey("dbo.StanicaLinijas", "Linija_Id", "dbo.Linijas");
            DropForeignKey("dbo.StanicaLinijas", "Stanica_Id", "dbo.Stanicas");
            DropIndex("dbo.StanicaLinijas", new[] { "Linija_Id" });
            DropIndex("dbo.StanicaLinijas", new[] { "Stanica_Id" });
            DropTable("dbo.StanicaLinijas");
            CreateIndex("dbo.Stanicas", "Linija_Id");
            AddForeignKey("dbo.Stanicas", "Linija_Id", "dbo.Linijas", "Id");
        }
    }
}
