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
    public class CenovnikStavkasController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/CenovnikStavkas
        public IQueryable<CenovnikStavka> GetCenovnikStavke()
        {
            return db.CenovnikStavke.Include(x=>x.Cenovnik).Include(x=>x.Stavka);
        }

        // GET: api/CenovnikStavkas/5
        [ResponseType(typeof(CenovnikStavka))]
        public IHttpActionResult GetCenovnikStavka(int id)
        {
            CenovnikStavka cenovnikStavka = db.CenovnikStavke.Find(id);
          
            if (cenovnikStavka == null)
            {
                return NotFound();
            }

            return Ok(cenovnikStavka);
        }

        [Route("StavkeCenovnika")]
        [HttpGet]
        [ResponseType(typeof(Stavka))]
        public IHttpActionResult GetAllStavkeCenovnika(int cenovnikId)
        {
            List<Stavka> stavke = new List<Stavka>();
            List<CenovnikStavka> cenovnikStavke= db.CenovnikStavke.Include(x => x.Cenovnik).Include(x => x.Stavka).ToList();

            foreach(var cs in cenovnikStavke)
            {
               if(cs.Cenovnik_Id == cenovnikId)
                {
                    stavke.Add(cs.Stavka);
                }
            }
            return Ok(stavke);
        }

        // PUT: api/CenovnikStavkas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCenovnikStavka(int id, CenovnikStavka cenovnikStavka)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cenovnikStavka.Id)
            {
                return BadRequest();
            }

            db.Entry(cenovnikStavka).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CenovnikStavkaExists(id))
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

        // POST: api/CenovnikStavkas
        [ResponseType(typeof(CenovnikStavka))]
        public IHttpActionResult PostCenovnikStavka(CenovnikStavka cenovnikStavka)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CenovnikStavke.Add(cenovnikStavka);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cenovnikStavka.Id }, cenovnikStavka);
        }

        // DELETE: api/CenovnikStavkas/5
        [ResponseType(typeof(CenovnikStavka))]
        public IHttpActionResult DeleteCenovnikStavka(int id)
        {
            CenovnikStavka cenovnikStavka = db.CenovnikStavke.Find(id);
            if (cenovnikStavka == null)
            {
                return NotFound();
            }

            db.CenovnikStavke.Remove(cenovnikStavka);
            db.SaveChanges();

            return Ok(cenovnikStavka);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CenovnikStavkaExists(int id)
        {
            return db.CenovnikStavke.Count(e => e.Id == id) > 0;
        }

        public class CenovnikStavkaBindingModel
        {
            public int Id;
            public Cenovnik Cenovnik;
            public Stavka Stavka;
        }
    }
}