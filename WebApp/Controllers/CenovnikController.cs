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

       




        }
}
