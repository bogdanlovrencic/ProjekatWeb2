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
            return db.Cenovnici.Where(cen=>cen.Aktivan);
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
        public IHttpActionResult PutCenovnik(int id, Cenovnik cenovnik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cenovnik.Id)
            {
                return BadRequest();
            }

            db.Entry(cenovnik).State = EntityState.Modified;

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
            noviCenovnik.Stavke = new List<Stavka>();

          
            foreach(int s in cenovnik.Stavke)
            {
                noviCenovnik.Stavke.Add(db.Stavke.Find(s));
            }

            db.Cenovnici.Add(noviCenovnik);

            db.SaveChanges();

            CenovnikStavka cs = new CenovnikStavka();

            cs.Cenovnik_Id = noviCenovnik.Id;


            foreach (var stavka in noviCenovnik.Stavke)
            {
                cs.Stavka_Id = stavka.Id;
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

    }
}