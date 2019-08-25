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
        IKorisnikRepository Korisnici { get; set; }
        IKartaRepository Karte { get; set; }    
        IRepository<Cenovnik,int> Cenovnici { get; set; }
        ILinijeRepository Linije { get; set; }
        ICenovnikRepository Cenovnik { get; set; }
        int Complete();
    }
}
