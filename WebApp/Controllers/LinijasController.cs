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
    [RoutePrefix("api/Linijas")]
    public class LinijasController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Linijas
        public IQueryable<Linija> GetLinije()
        {
            return db.Linije.Where(linija=>linija.Aktivna);
        }

        // GET: api/Linijas/5
        [ResponseType(typeof(Linija))]
        public IHttpActionResult GetLinija(string naziv)
        {
            Linija linija= db.Linije.Include(x => x.Stanice).FirstOrDefault(x => x.Naziv.ToLower().Equals(naziv.ToLower()));
            var staniceAktivne = linija.Stanice.FindAll(s => s.Aktivna);
            linija.Stanice = staniceAktivne;

            if (linija == null)
            {
                return NotFound();
            }
            

            return Ok(linija);
        }

        // PUT: api/Linijas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLinija(int id, Linija linija)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != linija.Id)
            {
                return BadRequest();
            }

   
           
            foreach(Stanica s in linija.Stanice)
            {
                if(!s.Aktivna)
                {
                    s.Aktivna = true;
                    s.Linije = new List<Linija>();    
                    db.Entry(s).State = EntityState.Added;
                    db.SaveChanges();

                }
                else
                {
                    db.Entry(s).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }

           
   
            db.Entry(linija).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LinijaExists(id))
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

        // POST: api/Linijas
        [ResponseType(typeof(Linija))]
        public IHttpActionResult PostLinija(Linija linija)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var line = db.Linije.Any(lin => lin.Aktivna && lin.Naziv == linija.Naziv);

            if (line == true)
                return BadRequest(ModelState);
           

            linija.Aktivna = true;
            foreach(var stanica in linija.Stanice)
            {
                stanica.Aktivna = true;
            }

            db.Linije.Add(linija);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = linija.Id }, linija);
           
        }

        // DELETE: api/Linijas/5
        [ResponseType(typeof(Linija))]
        public IHttpActionResult DeleteLinija(int id)
        {
            Linija linija = db.Linije.Find(id);
            if (linija == null)
            {
                return NotFound();
            }

            db.Linije.Remove(linija);
            db.SaveChanges();

            return Ok(linija);
        }

        [HttpGet]
        [Route("ObrisiLiniju")]
        public IHttpActionResult ObrisiLiniju(string naziv)
        {
            Linija linija = db.Linije.FirstOrDefault(l=>l.Naziv == naziv);

            if (linija == null)
                return BadRequest("Linija sa prosledjenim id ne postoji!");

            linija.Aktivna = false;

            db.Entry(linija).State = EntityState.Modified;
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

        private bool LinijaExists(int id)
        {
            return db.Linije.Count(e => e.Id == id) > 0;
        }
    }

    public class StanicaLinija
    {
        public int Stanica_Id;
        public int Linija_Id;

        public StanicaLinija(int stanicaId,int linijaId)
        {
            Stanica_Id = stanicaId;
            Linija_Id = linijaId;
        }
    }
}