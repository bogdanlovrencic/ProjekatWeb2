using JGSPNSWebApp.Models;
using JGSPNSWebApp.Persistence;
using JGSPNSWebApp.Persistence.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace JGSPNSWebApp.Controllers
{
    [RoutePrefix("api/cenovnik")]
    public class CenovnikController : ApiController
    {
        private static ApplicationDbContext context = new ApplicationDbContext();

        IUnitOfWork unitOfWork=new DemoUnitOfWork(context);

        public CenovnikController(IUnitOfWork unitOfWork, ApplicationDbContext dbContext)
        {
            this.unitOfWork = unitOfWork;
            context = dbContext;

        }

        public CenovnikController()
        {

        }

        [HttpGet, Route("prikaziCene")]    
        public IEnumerable<Cenovnik1> PrikaziCenovnik()
        {
            List<Cenovnik1> cenovnici = new List<Cenovnik1>();

            foreach(var cenovnik in unitOfWork.Cenovnik.GetAll())
            {
                cenovnici.Add(new Cenovnik1() {Id=cenovnik.Id, TipKarte = cenovnik.TipKarte, Cena = cenovnik.Cena });
            }

            return cenovnici;
        }




        }
}
