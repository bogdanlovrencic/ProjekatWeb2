using JGSPNSWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JGSPNSWebApp.Persistence.Repository
{
    public class ServiceRepository : Repository<EmailService, int>,IServiceRepository 
    {
        public ServiceRepository(System.Data.Entity.DbContext context) : base(context)
        {

        }
    }
}