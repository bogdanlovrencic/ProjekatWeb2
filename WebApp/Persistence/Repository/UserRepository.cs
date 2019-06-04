using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using JGSPNSWebApp.Models;

namespace JGSPNSWebApp.Persistence.Repository
{
    public class UserRepository : Repository<Korisnik,string>,IUserRepository 
    {
        public UserRepository(DbContext context) : base(context)
        {
            
        }

        public Korisnik Get(int id)
        {
            throw new NotImplementedException();
        }

        public Korisnik GetUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}