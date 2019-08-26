namespace JGSPNSWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class all : DbMigration
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
            
            CreateTable(
                "dbo.CenovnikStavkas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdCenovnika = c.Int(nullable: false),
                        IdStavke = c.Int(nullable: false),
                        Cena = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cenovniks", t => t.IdCenovnika, cascadeDelete: true)
                .ForeignKey("dbo.Stavkas", t => t.IdStavke, cascadeDelete: true)
                .Index(t => t.IdCenovnika)
                .Index(t => t.IdStavke);
            
            CreateTable(
                "dbo.Stavkas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Kartas",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        VremeOd = c.DateTime(nullable: false),
                        VremeDo = c.DateTime(nullable: false),
                        Kupac_Email = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Korisniks", t => t.Kupac_Email)
                .Index(t => t.Kupac_Email);
            
            CreateTable(
                "dbo.Korisniks",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 128),
                        Ime = c.String(),
                        Prezime = c.String(),
                        DatumRodjenja = c.DateTime(nullable: false),
                        Adresa = c.String(),
                        Lozinka = c.String(),
                        Verifikovan = c.Boolean(nullable: false),
                        Status = c.String(),
                        ImageUrl = c.String(),
                        Uloga_Naziv = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Email)
                .ForeignKey("dbo.Rolas", t => t.Uloga_Naziv)
                .Index(t => t.Uloga_Naziv);
            
            CreateTable(
                "dbo.Rolas",
                c => new
                    {
                        Naziv = c.String(nullable: false, maxLength: 128),
                        Sifra = c.Int(nullable: false),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Naziv);
            
            CreateTable(
                "dbo.Linijas",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        RedniBroj = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Stanicas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                        Adresa = c.String(),
                        KordinataX = c.String(),
                        KordinataY = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RedVoznjes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Polazak = c.DateTime(nullable: false),
                        IzabraniRedaVoznje = c.Int(nullable: false),
                        IzabranTipDana = c.Int(nullable: false),
                        Aktivan = c.Boolean(nullable: false),
                        IzabranaLinija_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Linijas", t => t.IzabranaLinija_Id)
                .Index(t => t.IzabranaLinija_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
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
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.StanicaLinijas",
                c => new
                    {
                        Stanica_Id = c.Int(nullable: false),
                        Linija_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Stanica_Id, t.Linija_Id })
                .ForeignKey("dbo.Stanicas", t => t.Stanica_Id, cascadeDelete: true)
                .ForeignKey("dbo.Linijas", t => t.Linija_Id, cascadeDelete: true)
                .Index(t => t.Stanica_Id)
                .Index(t => t.Linija_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.RedVoznjes", "IzabranaLinija_Id", "dbo.Linijas");
            DropForeignKey("dbo.StanicaLinijas", "Linija_Id", "dbo.Linijas");
            DropForeignKey("dbo.StanicaLinijas", "Stanica_Id", "dbo.Stanicas");
            DropForeignKey("dbo.Kartas", "Kupac_Email", "dbo.Korisniks");
            DropForeignKey("dbo.Korisniks", "Uloga_Naziv", "dbo.Rolas");
            DropForeignKey("dbo.CenovnikStavkas", "IdStavke", "dbo.Stavkas");
            DropForeignKey("dbo.CenovnikStavkas", "IdCenovnika", "dbo.Cenovniks");
            DropIndex("dbo.StanicaLinijas", new[] { "Linija_Id" });
            DropIndex("dbo.StanicaLinijas", new[] { "Stanica_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.RedVoznjes", new[] { "IzabranaLinija_Id" });
            DropIndex("dbo.Korisniks", new[] { "Uloga_Naziv" });
            DropIndex("dbo.Kartas", new[] { "Kupac_Email" });
            DropIndex("dbo.CenovnikStavkas", new[] { "IdStavke" });
            DropIndex("dbo.CenovnikStavkas", new[] { "IdCenovnika" });
            DropTable("dbo.StanicaLinijas");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.StatusRegistracijes");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.RedVoznjes");
            DropTable("dbo.Stanicas");
            DropTable("dbo.Linijas");
            DropTable("dbo.Rolas");
            DropTable("dbo.Korisniks");
            DropTable("dbo.Kartas");
            DropTable("dbo.Stavkas");
            DropTable("dbo.CenovnikStavkas");
            DropTable("dbo.Cenovniks");
        }
    }
}
