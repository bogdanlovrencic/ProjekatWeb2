using JGSPNSWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace JGSPNSWebApp.Persistence.Repository
{
    public class LinijeRepository : Repository<Linija,string>,ILinijeRepository
    {
        public LinijeRepository(DbContext context) : base(context)
        {
        }
    }
}