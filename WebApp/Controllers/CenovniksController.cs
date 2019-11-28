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

            List<Stavka> stavke = db.Stavke.Where(s => s.Aktivna).ToList();

            List<CenovnikPrikaz> cenovniciZaprikaz = new List<CenovnikPrikaz>();
            CenovnikPrikaz cp = new CenovnikPrikaz();
            cp.Stavke = new List<Stavka>();


            foreach (var c in cenovnici)
            {         
                foreach (var s in stavke)
                {
                    foreach (var cst in cs)
                    {
                        if (cst.Cenovnik_Id == c.Id && cst.Stavka_Id == s.Id)
                        {                     
                            cp.Stavke.Add(s);
                            break;                         
                        }

                    }

                }

                cp.Id = c.Id;
                cp.VaziOd = c.VaziOd;
                cp.VaziDo = c.VaziDo;
                cp.Aktivan = c.Aktivan;
                cenovniciZaprikaz.Add(cp);
                cp = new CenovnikPrikaz();
                cp.Stavke = new List<Stavka>();
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
        public IHttpActionResult PutCenovnik(int id, CenovnikPrikaz cenovnik)
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
            var stariCenStavki = db.CenovnikStavke.Where(x=>x.Cenovnik_Id == id).ToList();

            Cenovnik noviCenovnik = new Cenovnik();
            noviCenovnik.Id = cenovnik.Id;
            noviCenovnik.VaziOd = cenovnik.VaziOd;
            noviCenovnik.VaziDo = cenovnik.VaziDo;
            noviCenovnik.Aktivan = cenovnik.Aktivan;

            CenovnikStavka noviCenStavki = new CenovnikStavka();

          
            foreach(var s in cenovnik.Stavke)
            {
                foreach (var cs in stariCenStavki)
                {
                    if (cs.Cenovnik_Id == stariCenovnik.Id && cs.Stavka_Id == s.Id)
                    {
                        noviCenStavki.Id = cs.Id;
                        noviCenStavki.Cenovnik_Id = noviCenovnik.Id;
                        noviCenStavki.Stavka_Id = s.Id;

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
        public IHttpActionResult PostCenovnik(CenovnikBindingModel cenovnik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Cenovnik noviCenovnik = new Cenovnik();

            noviCenovnik.VaziOd = cenovnik.VaziOd;
            noviCenovnik.VaziDo = cenovnik.VaziDo;
            noviCenovnik.Aktivan = cenovnik.Aktivan;
            //noviCenovnik.Stavke = new List<Stavka>();

          
            //foreach(int s in cenovnik.Stavke)
            //{
            //    noviCenovnik.Stavke.Add(db.Stavke.Find(s));
            //}

            db.Cenovnici.Add(noviCenovnik);

            db.SaveChanges();

            CenovnikStavka cs = new CenovnikStavka();

            cs.Cenovnik_Id = noviCenovnik.Id;


            foreach (var id in cenovnik.Stavke)
            {
                cs.Stavka_Id = id;
                db.CenovnikStavke.Add(cs);
                db.SaveChanges();
            }

            return Ok();
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

    public class CenovnikBindingModel
    {
        public DateTime VaziOd { get; set; }
        public DateTime VaziDo { get; set; }
        public List<int> Stavke { get; set; }
        public bool Aktivan { get; set; }
    }

    public class CenovnikPrikaz
    {
        public int Id { get; set; }
        public DateTime VaziOd { get; set; }
        public DateTime VaziDo { get; set; }
        public bool Aktivan { get; set; }

        public List<Stavka> Stavke { get; set; }

    }
}