using JGSPNSWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JGSPNSWebApp.Persistence.Repository
{
    public class KartaRepository : Repository<Karta,string>, IKartaRepository
    {
        public KartaRepository(System.Data.Entity.DbContext context) : base(context)
        {

        }
    }
}