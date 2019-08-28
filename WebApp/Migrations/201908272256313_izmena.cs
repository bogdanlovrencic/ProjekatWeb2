namespace JGSPNSWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class izmena : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RedVoznjes", "IzabraniRedaVoznje", c => c.String());
            AlterColumn("dbo.RedVoznjes", "IzabranTipDana", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RedVoznjes", "IzabranTipDana", c => c.Int(nullable: false));
            AlterColumn("dbo.RedVoznjes", "IzabraniRedaVoznje", c => c.Int(nullable: false));
        }
    }
}
