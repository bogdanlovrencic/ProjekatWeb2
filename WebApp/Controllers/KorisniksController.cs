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
using JGSPNSWebApp.Persistence.UnitOfWork;

namespace JGSPNSWebApp.Controllers
{
    
    public class KorisniksController : ApiController
    {

        private ApplicationDbContext db = new ApplicationDbContext();
       
        // GET: api/Korisniks
        public IQueryable<Korisnik> GetKorisniks()
        {
            return db.Korisnici.Where(kor=>kor.Uloga == UlogaKorisnika.KONTROLOR.ToString() && kor.Aktivan==true);
        }


        // GET: api/Korisniks/5     
        [ResponseType(typeof(Korisnik))]       
        public IHttpActionResult GetKorisnik(string id)
        {
            Korisnik korisnik = db.Korisnici.Find(id);
            if (korisnik == null)
            {
                return NotFound();
            }

            return Ok(korisnik);
        }

        // PUT: api/Korisniks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKorisnik(string id, Korisnik korisnik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != korisnik.Email)
            {
                return BadRequest();
            }

            db.Entry(korisnik).State = EntityState.Modified;
           
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KorisnikExists(id))
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

        // POST: api/Korisniks
        [ResponseType(typeof(Korisnik))]
        public IHttpActionResult PostKorisnik(Korisnik korisnik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Korisnici.Add(korisnik);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (KorisnikExists(korisnik.Email))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = korisnik.Email }, korisnik);
        }

        // DELETE: api/Korisniks/5
        [ResponseType(typeof(Korisnik))]
        public IHttpActionResult DeleteKorisnik(string id)
        {
            Korisnik korisnik = db.Korisnici.Find(id);
            if (korisnik == null)
            {
                return NotFound();
            }

            var putnik = db.Putnici.Include(x => x.Korisnik).FirstOrDefault(x => x.Korisnik.Email.Equals(id));
            db.Putnici.Remove(putnik);

            db.Korisnici.Remove(korisnik);
            db.SaveChanges();

            return Ok(korisnik);
        }

        [HttpGet]
        [Route("ObrisiKontrolora")]
        public IHttpActionResult ObrisiKontrolora(string id)
        {
            var kontrolor = db.Korisnici.Find(id);

            if (kontrolor == null)
                return BadRequest("Kontrolor sa prosledjenim id ne postoji!");

           // kontrolor.Aktivan = false;

            db.Entry(kontrolor).State = EntityState.Modified;
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

        private bool KorisnikExists(string id)
        {
            return db.Korisnici.Count(e => e.Email == id) > 0;
        }
    }
}