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
                var user = new ApplicationUser() { Id = "appu", UserName = "appu@yahoo.com", Email = "appu@yahoo.com", PasswordHash = ApplicationUser.HashPassword("Appu123!") };
                userManager.Create(user);
                userManager.AddToRole(user.Id, "AppUser");
            }

            if (!context.Users.Any(u => u.UserName == "controller@yahoo.com"))
            {
                var user = new ApplicationUser() { Id = "controller", UserName = "controller@yahoo.com", Email = "controller@yahoo.com", PasswordHash = ApplicationUser.HashPassword("Controller123!") };
                userManager.Create(user);
                userManager.AddToRole(user.Id, "Controller");
            }

            if (!context.Koeficijenti.Any(c => c.TipPutnika == TipPutnika.Regularni))
            {
                var koefRegularni = new Koeficijent()
                {
                    TipPutnika = TipPutnika.Regularni,
                    Koef = 1
                };
                context.Koeficijenti.Add(koefRegularni);
            }

            if (!context.Koeficijenti.Any(c => c.TipPutnika == TipPutnika.Djak))
            {
                var koefStudent = new Koeficijent()
                {
                    TipPutnika = TipPutnika.Djak,
                    Koef = 0.8
                };
                context.Koeficijenti.Add(koefStudent);
            }

            if (!context.Koeficijenti.Any(c => c.TipPutnika == TipPutnika.Penzioner))
            {
                var koefPenzioner = new Koeficijent()
                {
                    TipPutnika = TipPutnika.Penzioner,
                    Koef = 0.6
                };
                context.Koeficijenti.Add(koefPenzioner);
            }



            //Stavka vremenskaKarta = new Stavka() { Id = 1, Naziv =VrstaKarte.VREMENSKA_KARTA.ToString() };
            //Stavka dnevnaKarta = new Stavka() { Id = 2, Naziv = VrstaKarte.DNEVNA_KARTA.ToString() };
            //Stavka mesecnaKarta = new Stavka() { Id = 3, Naziv=VrstaKarte.MESECNA_KARTA.ToString() };
            //Stavka godisnjaKarta = new Stavka() { Id = 4, Naziv = VrstaKarte.GODISNJA_KARTA.ToString() };

            //Cenovnik jesenjiCenovnik = new Cenovnik { Id = 1, VaziOd= new DateTime(2019, 9, 1), VaziDo = new DateTime(2019, 12, 31), Aktivan = true };

            //context.Stavke.AddOrUpdate(vremenskaKarta);
            //context.Stavke.AddOrUpdate(dnevnaKarta);
            //context.Stavke.AddOrUpdate(mesecnaKarta);
            //context.Stavke.AddOrUpdate(godisnjaKarta);
            //context.Cenovnici.AddOrUpdate(jesenjiCenovnik);

            //CenovnikStavka vremenskaKartaStv = new CenovnikStavka() { Id = 1, Cenovnik = jesenjiCenovnik, Stavka = vremenskaKarta, Cena = 1.5 };
            //CenovnikStavka dnevnaKartaStv = new CenovnikStavka() { Id = 2, Cenovnik = jesenjiCenovnik, Stavka = dnevnaKarta, Cena = 3.5 };
            //CenovnikStavka mesecnaKartaStv = new CenovnikStavka() { Id = 3, Cenovnik = jesenjiCenovnik, Stavka = mesecnaKarta, Cena = 7.5 };
            //CenovnikStavka godisnjaKartaStv = new CenovnikStavka() { Id = 4, Cenovnik = jesenjiCenovnik, Stavka = godisnjaKarta, Cena = 15.0 };

            //context.CenovnikStavka.AddOrUpdate(vremenskaKartaStv);
            //context.CenovnikStavka.AddOrUpdate(dnevnaKartaStv);
            //context.CenovnikStavka.AddOrUpdate(mesecnaKartaStv);
            //context.CenovnikStavka.AddOrUpdate(godisnjaKartaStv);

            //context.SaveChanges();

            //Cenovnik1 vremenska = new Cenovnik1(123, VrstaKarte.VREMENSKA_KARTA.ToString(), 65);
            //context.Cenovnik.Add(vremenska);
            //context.SaveChanges();

            //Cenovnik1 dnevna = new Cenovnik1(114, VrstaKarte.DNEVNA_KARTA.ToString(), 330);
            //context.Cenovnik.Add(dnevna);
            //context.SaveChanges();

            //Cenovnik1 mesecna = new Cenovnik1(167, VrstaKarte.MESECNA_KARTA.ToString(), 970);
            //context.Cenovnik.Add(mesecna);
            //context.SaveChanges();

            //Cenovnik1 godisnja = new Cenovnik1(114, VrstaKarte.GODISNJA_KARTA.ToString(), 11900);
            //context.Cenovnik.Add(godisnja);
            //context.SaveChanges();

            //Linija linija1 = new Linija();
            //linija1.IdLinije = "1";
            //linija1.Relacija = "KLISA-CENTAR-LIMAN I";
            //linija1.TipRedaVoznje = TipRedaVoznje.GRADSKI.ToString();

            //Linija linija3 = new Linija();
            //linija3.IdLinije = "3";
            //linija3.Relacija = "DETELINARA-CENTAR-PETROVARADIN";
            //linija3.TipRedaVoznje = TipRedaVoznje.GRADSKI.ToString();

            //Linija linija5 = new Linija();
            //linija5.IdLinije = "5";
            //linija5.Relacija = "AVIJATICAR.NASELJE-CENTAR-TEMERINSKI PUT";
            //linija5.TipRedaVoznje = TipRedaVoznje.GRADSKI.ToString();

            //Linija linija11 = new Linija();
            //linija11.IdLinije = "11";
            //linija11.Relacija = "Z.STANICA-BOLNICA-LIMAN IV-Z.STANICA";
            //linija11.TipRedaVoznje = TipRedaVoznje.GRADSKI.ToString();

            //context.Linije.Add(linija1);
            //context.Linije.Add(linija3);
            //context.Linije.Add(linija5);
            //context.Linije.Add(linija11);

            //context.SaveChanges();
        }
    }
}
