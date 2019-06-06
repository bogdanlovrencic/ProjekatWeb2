using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using JGSPNSWebApp.Models;

namespace JGSPNSWebApp.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<JGSPNSWebApp.Models.Korisnik> Korisnik { get; set; }
        public DbSet<Cenovnik> Cenovnik { get; set; }
        public DbSet<CenovnikStavka> CenovnikStavka { get; set; }
        public DbSet<Stavka> Stavka { get; set; }
        public DbSet<RedVoznje> RedVoznje { get; set; }
       // public DbSet<Linija> Linije { get; set; }

        public System.Data.Entity.DbSet<JGSPNSWebApp.Models.Karta> Karte { get; set; }
    }
}