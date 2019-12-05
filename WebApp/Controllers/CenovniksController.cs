using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using JGSPNSWebApp.Models;
using JGSPNSWebApp.Persistence;

namespace JGSPNSWebApp.Controllers
{
    [RoutePrefix("api/Cenovniks")]
    public class CenovniksController : ApiController
    {
        
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Cenovniks
        public IQueryable<Cenovnik> GetCenovnici()
        {
            return db.Cenovnici.Where(cen => cen.Aktivan);
        }

        [Route("Cenovnici")]
        [HttpGet]
        [ResponseType(typeof(CenovnikPrikaz))]
        public IHttpActionResult  GetAllCenovnici()
        {
            List<CenovnikStavka> cs = db.CenovnikStavke.Where(x=>x.Cenovnik.Aktivan).ToList();

            List<Cenovnik> cenovnici = db.Cenovnici.Where(cen => cen.Aktivan).ToList();

            List<Stavka> stavke = db.Stavke.ToList();
            List<StavkaP> stavkee = new List<StavkaP>();
            
            List<CenovnikPrikaz> cenovniciZaprikaz = new List<CenovnikPrikaz>();
            CenovnikPrikaz cp = new CenovnikPrikaz();
            List<StavkaP> sortiraneStavke = new List<StavkaP>();

            cp.Stavke = new List<StavkaP>();

           
            foreach (var c in cenovnici)
            {         
                foreach (var s in stavke)
                {
                    foreach (var cst in cs)
                    {
                        if (cst.Cenovnik_Id == c.Id && cst.Stavka_Id == s.Id)
                        {
                            StavkaP sp = new StavkaP()
                            {
                                Id = s.Id,
                                Naziv = s.Naziv,
                                Cena =cst.Cena
                            };
                            cp.Stavke.Add(sp);
                            
                            break;                         
                        }

                    }

                }

                cp.Id = c.Id;
                cp.VaziOd = c.VaziOd;
                cp.VaziDo = c.VaziDo;
                cp.Aktivan = c.Aktivan;
                sortiraneStavke = cp.Stavke.OrderBy(x => x.Cena).ToList();
                cp.Stavke = sortiraneStavke;
                cenovniciZaprikaz.Add(cp);
                
                cp = new CenovnikPrikaz();
                cp.Stavke = new List<StavkaP>();
            }


            return Ok(cenovniciZaprikaz);
        }

        // GET: api/Cenovniks/5
        [ResponseType(typeof(Cenovnik))]
        public IHttpActionResult GetCenovnik(int id)
        {
            Cenovnik cenovnik = db.Cenovnici.Find(id);
            if (cenovnik == null)
            {
                return NotFound();
            }

            return Ok(cenovnik);
        }

        // PUT: api/Cenovniks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCenovnik(int id, Cenovniks cenovnik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cenovnik.Id)
            {
                return BadRequest();
            }

            var stariCenovnik = db.Cenovnici.Find(id);
            var stariCenStavki = db.CenovnikStavke.Include(x=>x.Cenovnik).Where(x=>x.Cenovnik_Id == id).Include(x=>x.Stavka).ToList();

            Cenovnik noviCenovnik = new Cenovnik();
            noviCenovnik.Id = cenovnik.Id;
            noviCenovnik.VaziOd = cenovnik.VaziOd;
            noviCenovnik.VaziDo = cenovnik.VaziDo;
            noviCenovnik.Aktivan = cenovnik.Aktivan;

            CenovnikStavka noviCenStavki = new CenovnikStavka();

          
            foreach(var IDstavke in cenovnik.Stavke)
            {
                foreach (var cs in stariCenStavki)
                {
                    if (cs.Cenovnik_Id == stariCenovnik.Id && cs.Stavka_Id != IDstavke)
                    {

                        db.Entry(stariCenovnik).State = EntityState.Detached;
                        db.SaveChanges();

                        noviCenStavki.Id = cs.Id;
                        noviCenStavki.Cenovnik=noviCenovnik;
                        noviCenStavki.Stavka=db.Stavke.Find(IDstavke);
                        noviCenStavki.Cenovnik_Id = noviCenovnik.Id;
                        noviCenStavki.Stavka_Id = IDstavke;

                   
                        db.Entry(noviCenStavki).State = EntityState.Modified;
                       
                        db.SaveChanges();
                        break;
                    }
                }
            }


            db.Entry(noviCenovnik).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CenovnikExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Cenovniks
        public IHttpActionResult PostCenovnik(Cenovnik cenovnik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cenovnici.Add(cenovnik);
            db.SaveChanges();

            return Ok();
        }

        // POST: api/Cenovniks
        [Route("DodajCenovnik")]
        [ResponseType(typeof(Cenovnik))]
        public IHttpActionResult DodajCenovnik(DateTime VaziOd, DateTime VaziDo, bool aktivan, double cenaVremenske, double cenaDnevne, double cenaMesecne, double cenaGodisnje)
        {
            Cenovnik noviCenovnik = new Cenovnik();

            noviCenovnik.VaziOd = VaziOd;
            noviCenovnik.VaziDo = VaziDo;
            noviCenovnik.Aktivan = aktivan;

            db.Cenovnici.Add(noviCenovnik);
            db.SaveChanges();

            Stavka vremenskaKarta = new Stavka()
            {
                Naziv = "Vremenska karta"
            };

            db.Stavke.Add(vremenskaKarta);
            db.SaveChanges();

            Stavka dnevnaKarta = new Stavka()
            {
                Naziv = "Dnevna karta"
            };

            db.Stavke.Add(dnevnaKarta);
            db.SaveChanges();

            Stavka mesecnaKarta = new Stavka()
            {
                Naziv = "Mesecna karta"
            };

            db.Stavke.Add(mesecnaKarta);
            db.SaveChanges();

            Stavka godisnjaKarta = new Stavka()
            {
                Naziv = "Godisnja karta"
            };

            db.Stavke.Add(godisnjaKarta);
            db.SaveChanges();


            var cenovnik = db.Cenovnici.Where(x => x.Aktivan).First();


            CenovnikStavka cs = new CenovnikStavka();

            foreach (var stavka in db.Stavke.ToList())
            {
                if (stavka.Naziv == "Vremenska karta")
                {
                    cs = new CenovnikStavka()
                    {
                        Cenovnik_Id = cenovnik.Id,
                        Stavka_Id = stavka.Id,
                        Cena = cenaVremenske
                    };

                    db.CenovnikStavke.Add(cs);
                    db.SaveChanges();
                }
                else if (stavka.Naziv == "Dnevna karta")
                {
                    cs = new CenovnikStavka()
                    {
                        Cenovnik_Id = cenovnik.Id,
                        Stavka_Id = stavka.Id,
                        Cena = cenaDnevne
                    };

                    db.CenovnikStavke.Add(cs);
                    db.SaveChanges();
                }
                else if (stavka.Naziv == "Mesecna karta")
                {
                    cs = new CenovnikStavka()
                    {
                        Cenovnik_Id = cenovnik.Id,
                        Stavka_Id = stavka.Id,
                        Cena = cenaMesecne
                    };

                    db.CenovnikStavke.Add(cs);
                    db.SaveChanges();
                }
                else
                {
                    cs = new CenovnikStavka()
                    {
                        Cenovnik_Id = cenovnik.Id,
                        Stavka_Id = stavka.Id,
                        Cena = cenaGodisnje
                    };

                    db.CenovnikStavke.Add(cs);
                    db.SaveChanges();
                }

            }

            return Ok(0);
        }

        // DELETE: api/Cenovniks/5
        [ResponseType(typeof(Cenovnik))]
        public IHttpActionResult DeleteCenovnik(int id)
        {
            Cenovnik cenovnik = db.Cenovnici.Find(id);
            if (cenovnik == null)
            {
                return NotFound();
            }

            db.Cenovnici.Remove(cenovnik);
            db.SaveChanges();

            return Ok(cenovnik);
        }

        [HttpGet]
        [Route("ObrisiCenovnik")]
        public IHttpActionResult ObrisiCenovnik(int id)
        {
            var cenovnik = db.Cenovnici.Find(id);

            if (cenovnik == null)
                return BadRequest("Cenovnik sa prosledjenim id ne postoji!");

            cenovnik.Aktivan = false;

            db.Entry(cenovnik).State = EntityState.Modified;
            db.SaveChanges();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CenovnikExists(int id)
        {
            return db.Cenovnici.Count(e => e.Id == id) > 0;
        }
    }

    
    public class StavkaP
    {
        public int Id { get; set; }
        public string Naziv { get; set; }

        public double Cena { get; set; }

    }

    public class CenovnikBindingModel
    {
        public DateTime VaziOd { get; set; }
        public DateTime VaziDo { get; set; }
        //public List<int> Stavke { get; set; }
        public bool Aktivan { get; set; }
    }

    public class CenovnikPrikaz
    {
        public int Id { get; set; }
        public DateTime VaziOd { get; set; }
        public DateTime VaziDo { get; set; }
        public bool Aktivan { get; set; }

        public List<StavkaP> Stavke { get; set; }

    }

    public class Cenovniks
    {
        public int Id { get; set; }
        public DateTime VaziOd { get; set; }
        public DateTime VaziDo { get; set; }
        public bool Aktivan { get; set; }

        public List<int> Stavke { get; set; }

    }
}