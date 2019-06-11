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
            Karte = new Repository<Karta, string>(_context);
            Linije = new Repository<Linija, string>(_context);
            Cenovnici = new Repository<Cenovnik, int>(_context);
            Cenovnik = new Repository<Cenovnik1, int>(_context);

        }
        // dodati sve repozitorijume ovde
        [Dependency]
        public IRepository<Karta, string> Karte { get; set; }
        [Dependency]
        public IRepository<Korisnik, int> Korisnici { get; set; }

        public IRepository<EmailService,int> Servisi { get; set; }

        [Dependency]
        public IRepository<Linija, string> Linije { get; set; }
        [Dependency]
        public IRepository<Cenovnik, int> Cenovnici  { get;  set;}

        [Dependency]
        public IRepository<Cenovnik1,int>Cenovnik { get; set; }
      

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