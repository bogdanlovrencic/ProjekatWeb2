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
    public class PolazaksController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Polazaks
        public IQueryable<Polazak> GetPolazaks()
        {
            return db.Polazaks;
        }

        // GET: api/Polazaks/5
        [ResponseType(typeof(Polazak))]
        public IHttpActionResult GetPolazak(int id)
        {
            Polazak polazak = db.Polazaks.Find(id);
            if (polazak == null)
            {
                return NotFound();
            }

            return Ok(polazak);
        }

        // PUT: api/Polazaks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPolazak(int id, Polazak polazak)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != polazak.Id)
            {
                return BadRequest();
            }

            db.Entry(polazak).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PolazakExists(id))
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

        // POST: api/Polazaks
        //[ResponseType(typeof(Polazak))]
        public IHttpActionResult PostPolazak(PolazakBindingModel polazak)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Polazak p = new Polazak();

            p.Vreme = polazak.Vreme;
            p.TipDana = polazak.TipDana;
            p.LinijaId = polazak.LinijaId;
            p.Active = true;

            db.Polazaks.Add(p);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = p.Id }, p);
        }

        // DELETE: api/Polazaks/5
        [ResponseType(typeof(Polazak))]
        public IHttpActionResult DeletePolazak(int id)
        {
            Polazak polazak = db.Polazaks.Find(id);
            if (polazak == null)
            {
                return NotFound();
            }

            db.Polazaks.Remove(polazak);
            db.SaveChanges();

            return Ok(polazak);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PolazakExists(int id)
        {
            return db.Polazaks.Count(e => e.Id == id) > 0;
        }
    }

    public class PolazakBindingModel
    {
        public string Vreme { get; set; }
        public string TipDana { get; set; }
        public int LinijaId { get; set; }
    }
}