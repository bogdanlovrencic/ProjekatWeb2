using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JGSPNSWebApp.Persistence.Repository;
using JGSPNSWebApp.Models;

namespace JGSPNSWebApp.Persistence.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Korisnik,int> Korisnici { get; set; }
        IRepository<Karta,int> Karte { get; set; }
        IRepository<EmailService,int> Servisi { get; set; }
        int Complete();
    }
}
