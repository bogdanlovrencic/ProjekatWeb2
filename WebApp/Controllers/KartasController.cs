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
        public IHttpActionResult GetKarta(int id)
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
        public IHttpActionResult PutKarta(int id, Karta karta)
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

        [HttpGet]
        [Route("IzracunajCenu")]
        [ResponseType(typeof(double))]
        public IHttpActionResult GetCena(string tipKarte,TipPutnika tipPutnika)
        {
            int cenovnikId = db.Cenovnici.Where(x => x.Aktivan).Select(c => c.Id).First();
            int stavkaId = db.Stavke.Where(x => x.Naziv == tipKarte).Select(c => c.Id).First();
            double cena = db.CenovnikStavke.Where(x => x.Cenovnik_Id == cenovnikId && x.Stavka_Id == stavkaId).Select(c => c.Cena).First();
            double koef = db.Koeficijenti.Where(x => x.TipPutnika == tipPutnika).Select(c => c.Koef).First();

            double cenaSaPopustom = Math.Round(cena * koef, 2);

            return Ok(cenaSaPopustom);
        }
   

        [Route("kupiKartu")]
        [ResponseType(typeof(Karta))]
        public IHttpActionResult PostKarta(double cena,string tipKarte,string korisnikEmail,string email)
        {
            int cenovnikId = db.Cenovnici.Where(x => x.Aktivan).Select(c => c.Id).First();
            int stavkaId = db.Stavke.Where(x => x.Naziv == tipKarte).Select(c => c.Id).First();
            int cenovnikStavkaId = db.CenovnikStavke.Where(x => x.Cenovnik_Id == cenovnikId && x.Stavka_Id == stavkaId).Select(c => c.Id).First();
            
         
            Karta karta = new Karta
            {
                VremeVazenja=DateTime.Now,
                IdCenovnikStavka = cenovnikStavkaId,       
                IdKorisnika=null,
                Cena=cena,
                Validna = true

            };

            if(korisnikEmail != null)
            {
                karta.IdKorisnika = db.Korisnici.Where(x => x.Email == korisnikEmail).Select(c => c.Email).First();
            }

            db.Karte.Add(karta);
            db.SaveChanges();

            if(korisnikEmail == null)
            {
                EmailHelper.SendMail(email, "Online kupovina karte", "Uspesno ste kupili " + tipKarte.ToString() +"\n ID:" + karta.Id.ToString() + ",\n Cena: " + karta.Cena.ToString()+",\n Vreme vazenja: "+karta.VremeVazenja.AddHours(1).ToString());
            }
                 
            return Ok(karta);
        }

        // DELETE: api/Kartas/5
        [ResponseType(typeof(Karta))]
        public IHttpActionResult DeleteKarta(int id)
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

        private bool KartaExists(int id)
        {
            return db.Karte.Count(e => e.Id == id) > 0;
        }
    }
}