using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Unity;
using JGSPNSWebApp.Persistence.Repository;
using JGSPNSWebApp.Models;

namespace JGSPNSWebApp.Persistence.UnitOfWork
{
    public class DemoUnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public DemoUnitOfWork(ApplicationDbContext context)
        {
            _context = context;
          
            Karte = new KartaRepository(_context);
            Linije = new LinijeRepository(_context);
            Cenovnici = new Repository<Cenovnik, int>(_context);
            Cenovnik = new CenovnikRepository(_context);


        }
        // dodati sve repozitorijume ovde
        [Dependency]
        public IKartaRepository Karte { get; set; }
     

        [Dependency]
        public IRepository<Cenovnik, int> Cenovnici  { get;  set;}

        [Dependency]
        public ICenovnikRepository Cenovnik { get; set; }

        [Dependency]
        public ILinijeRepository Linije { get; set; }
       

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}