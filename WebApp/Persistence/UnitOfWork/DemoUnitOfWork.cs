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
            Korisnici = new Repository<Korisnik, int>(_context);
            Karte = new Repository<Karta, int>(_context);
        }
        // dodati sve repozitorijume ovde
        [Dependency]
        public IRepository<Karta, int> Karte { get; set; }
        [Dependency]
        public IRepository<Korisnik, int> Korisnici { get; set; }

        public IRepository<EmailService,int> Servisi { get; set; }
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