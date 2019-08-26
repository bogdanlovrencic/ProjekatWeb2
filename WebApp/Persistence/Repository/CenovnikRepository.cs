using JGSPNSWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace JGSPNSWebApp.Persistence.Repository
{
    public class CenovnikRepository : Repository<Cenovnik, int>, ICenovnikRepository
    {
        public CenovnikRepository(DbContext context) : base(context)
        {
        }
    }
}