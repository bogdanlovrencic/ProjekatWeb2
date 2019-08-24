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
                "dbo.Cenovnik1",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TipKarte = c.String(),
                        Cena = c.Double(nullable: false),
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
                        VrstaKarte = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Kartas",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        VremeOd = c.DateTime(nullable: false),
                        VremeDo = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Linijas",
                c => new
                    {
                        IdLinije = c.String(nullable: false, maxLength: 128),
                        TipRedaVoznje = c.String(),
                        Relacija = c.String(),
                    })
                .PrimaryKey(t => t.IdLinije);
            
            CreateTable(
                "dbo.Stanicas",
                c => new
                    {
                        Naziv = c.String(nullable: false, maxLength: 128),
                        Adresa = c.String(),
                        KordinataX = c.String(),
                        KordinataY = c.String(),
                    })
                .PrimaryKey(t => t.Naziv);
            
            CreateTable(
                "dbo.RedVoznjes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DanUNedelji = c.Int(nullable: false),
                        Aktivan = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.Rolas",
                c => new
                    {
                        Naziv = c.String(nullable: false, maxLength: 128),
                        Sifra = c.Int(nullable: false),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Naziv);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Ime = c.String(),
                        Prezime = c.String(),
                        Lozinka = c.String(),
                        DatumRodjenja = c.String(),
                        Adresa = c.String(),
                        TipPutnika = c.String(),
                        ImageUrl = c.String(),
                        Status = c.String(),
                        Verifikovan = c.Boolean(nullable: false),
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
                        Uloga_Naziv = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rolas", t => t.Uloga_Naziv)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.Uloga_Naziv);
            
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
                        Stanica_Naziv = c.String(nullable: false, maxLength: 128),
                        Linija_IdLinije = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Stanica_Naziv, t.Linija_IdLinije })
                .ForeignKey("dbo.Stanicas", t => t.Stanica_Naziv, cascadeDelete: true)
                .ForeignKey("dbo.Linijas", t => t.Linija_IdLinije, cascadeDelete: true)
                .Index(t => t.Stanica_Naziv)
                .Index(t => t.Linija_IdLinije);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Uloga_Naziv", "dbo.Rolas");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.StanicaLinijas", "Linija_IdLinije", "dbo.Linijas");
            DropForeignKey("dbo.StanicaLinijas", "Stanica_Naziv", "dbo.Stanicas");
            DropForeignKey("dbo.CenovnikStavkas", "IdStavke", "dbo.Stavkas");
            DropForeignKey("dbo.CenovnikStavkas", "IdCenovnika", "dbo.Cenovniks");
            DropIndex("dbo.StanicaLinijas", new[] { "Linija_IdLinije" });
            DropIndex("dbo.StanicaLinijas", new[] { "Stanica_Naziv" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "Uloga_Naziv" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.CenovnikStavkas", new[] { "IdStavke" });
            DropIndex("dbo.CenovnikStavkas", new[] { "IdCenovnika" });
            DropTable("dbo.StanicaLinijas");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Rolas");
            DropTable("dbo.StatusRegistracijes");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.RedVoznjes");
            DropTable("dbo.Stanicas");
            DropTable("dbo.Linijas");
            DropTable("dbo.Kartas");
            DropTable("dbo.Stavkas");
            DropTable("dbo.CenovnikStavkas");
            DropTable("dbo.Cenovnik1");
            DropTable("dbo.Cenovniks");
        }
    }
}
