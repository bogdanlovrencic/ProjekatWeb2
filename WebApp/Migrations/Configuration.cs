namespace JGSPNSWebApp.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using JGSPNSWebApp.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<JGSPNSWebApp.Persistence.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(JGSPNSWebApp.Persistence.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Controller"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Controller" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "AppUser"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "AppUser" };

                manager.Create(role);
            }

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            if (!context.Users.Any(u => u.UserName == "admin@yahoo.com"))
            {
                var user = new ApplicationUser() { Id = "admin", UserName = "admin@yahoo.com", Email = "admin@yahoo.com", PasswordHash = ApplicationUser.HashPassword("Admin123!") };
                userManager.Create(user);
                userManager.AddToRole(user.Id, "Admin");
            }

            if (!context.Users.Any(u => u.UserName == "appu@yahoo.com"))
            { 
                var user = new ApplicationUser() { Id = "appu", UserName = "appu@yahoo", Email = "appu@yahoo.com", PasswordHash = ApplicationUser.HashPassword("Appu123!") };
                userManager.Create(user);
                userManager.AddToRole(user.Id, "AppUser");
            }

            Cenovnik1 vremenska = new Cenovnik1(123,VrstaKarte.VREMENSKA_KARTA.ToString(),65);     
            context.Cenovnik.Add(vremenska);
            context.SaveChanges();

            Cenovnik1 dnevna = new Cenovnik1(114, VrstaKarte.DNEVNA_KARTA.ToString(), 330);
            context.Cenovnik.Add(dnevna);
            context.SaveChanges();

            Cenovnik1 mesecna = new Cenovnik1(167, VrstaKarte.MESECNA_KARTA.ToString(), 970);
            context.Cenovnik.Add(mesecna);
            context.SaveChanges();

            Cenovnik1 godisnja = new Cenovnik1(114, VrstaKarte.GODISNJA_KARTA.ToString(), 11900);
            context.Cenovnik.Add(godisnja);
            context.SaveChanges();

            Linija linija1 = new Linija();
            linija1.IdLinije = "1";
            linija1.Relacija = "KLISA-CENTAR-LIMAN I";
            linija1.TipRedaVoznje = TipRedaVoznje.GRADSKI.ToString();

            Linija linija3 = new Linija();
            linija3.IdLinije = "3";
            linija3.Relacija = "DETELINARA-CENTAR-PETROVARADIN";
            linija3.TipRedaVoznje = TipRedaVoznje.GRADSKI.ToString();

            Linija linija5 = new Linija();
            linija5.IdLinije = "5";
            linija5.Relacija = "AVIJATICAR.NASELJE-CENTAR-TEMERINSKI PUT";
            linija5.TipRedaVoznje = TipRedaVoznje.GRADSKI.ToString();

            Linija linija11 = new Linija();
            linija11.IdLinije = "11";
            linija11.Relacija = "Z.STANICA-BOLNICA-LIMAN IV-Z.STANICA";
            linija11.TipRedaVoznje = TipRedaVoznje.GRADSKI.ToString();

            context.Linije.Add(linija1);
            context.Linije.Add(linija3);
            context.Linije.Add(linija5);
            context.Linije.Add(linija11);

            context.SaveChanges();
        }
    }
}
