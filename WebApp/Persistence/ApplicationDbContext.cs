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

       
        public DbSet<Cenovnik> Cenovnici { get; set; }      
        public DbSet<Stavka> Stavke { get; set; }
        public DbSet<RedVoznje> RedVoznje { get; set; }
        public DbSet<Karta> Karte { get; set; }
        public DbSet<Linija> Linije { get; set; }
        public DbSet<CenovnikStavka> CenovnikStavke { get; set; }
        public System.Data.Entity.DbSet<JGSPNSWebApp.Models.Stanica> Stanice { get; set; }
        public DbSet<Koeficijent> Koeficijenti { get; set; }
        public DbSet<PayPal> PayPal { get; set; }
    }
}