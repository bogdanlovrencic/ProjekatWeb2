using JGSPNSWebApp.Models;
using JGSPNSWebApp.Persistence;
using JGSPNSWebApp.Persistence.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JGSPNSWebApp.Controllers
{
    [RoutePrefix("api/RedVoznje")]
    public class RedVoznjeController : ApiController
    {
        private static ApplicationDbContext dbContext=new ApplicationDbContext();
        private IUnitOfWork unitOfWork=new DemoUnitOfWork(dbContext);

        public RedVoznjeController(IUnitOfWork unitOfWork,ApplicationDbContext context)
        {
            this.unitOfWork = unitOfWork;
            dbContext = context;
        }

        public RedVoznjeController()
        {

        }

        [HttpGet,Route("ucitajLinije")]
       public IEnumerable<Linija> UcitajLinije()
       {
            List<Linija> linije = new List<Linija>();

            foreach(var linija in unitOfWork.Linije.GetAll())
            {
                linije.Add(linija);
            }

            return linije;
       }
    }
}
