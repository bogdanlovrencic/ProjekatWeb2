using JGSPNSWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JGSPNSWebApp.Persistence.Repository
{
    public interface IServiceRepository : IRepository<EmailService,int>
    {
    }
}