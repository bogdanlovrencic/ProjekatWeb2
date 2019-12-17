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
    [RoutePrefix("api/Kartas")]
    public class KartasController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Kartas
        public IQueryable<Karta> GetKarte()
        {
            return db.Karte;
        }

        // GET: api/Kartas/5
        [ResponseType(typeof(Karta))]
        public IHttpActionResult GetKarta(string id)
        {
            Karta karta = db.Karte.Find(id);
            if (karta == null)
            {
                return NotFound();
            }

            return Ok(karta);
        }

        // PUT: api/Kartas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKarta(string id, Karta karta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != karta.Id)
            {
                return BadRequest();
            }

            db.Entry(karta).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KartaExists(id))
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

        // POST: api/Kartas
        [ResponseType(typeof(Karta))]
        public IHttpActionResult PostKarta(Karta karta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Karte.Add(karta);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (KartaExists(karta.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = karta.Id }, karta);
        }

        // DELETE: api/Kartas/5
        [ResponseType(typeof(Karta))]
        public IHttpActionResult DeleteKarta(string id)
        {
            Karta karta = db.Karte.Find(id);
            if (karta == null)
            {
                return NotFound();
            }

            db.Karte.Remove(karta);
            db.SaveChanges();

            return Ok(karta);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KartaExists(string id)
        {
            return db.Karte.Count(e => e.Id == id) > 0;
        }
    }
}