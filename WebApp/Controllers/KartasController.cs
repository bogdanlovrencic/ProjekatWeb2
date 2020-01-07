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
                IdApplicationUser=null,
                Cena=cena,
                Validna = true

            };

            if(korisnikEmail != null)
            {
                karta.IdApplicationUser = db.Users.Where(x => x.Email == korisnikEmail).Select(c => c.Id).First();
            }

            db.Karte.Add(karta);
            db.SaveChanges();

            if(korisnikEmail == null)
            {
                EmailHelper.SendMail(email, "Online kupovina karte", "Uspesno ste kupili " + tipKarte.ToString() +"\n ID:" + karta.Id.ToString() + ",\n Cena: " + karta.Cena.ToString()+",\n Vreme vazenja: "+karta.VremeVazenja.AddHours(1).ToString());
            }
                 
            return Ok(karta);
        }


        [HttpPost]
        [Route("KupiKartuPayPal")]
        public IHttpActionResult KupiKartuPrekoPayPal(bool loggedIn,string email,string transactionId,string payer_email,string payer_id,double cena,string tipKarte,TipPutnika tipPutnika)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string userId = null;

            if(loggedIn)
            {
                userId = db.Users.Where(x => x.Email == email).Select(c => c.Id).First();
            }

            int cenovnikId = db.Cenovnici.Where(x => x.Aktivan).Select(c=>c.Id).First();
            int stavkaId = db.Stavke.Where(x => x.Naziv == tipKarte).Select(c=>c.Id).First();
            int cenovnikStavkaId = db.CenovnikStavke.Where(x => x.Cenovnik_Id == cenovnikId && x.Stavka_Id == stavkaId).Select(c => c.Id).First();


            Karta karta = new Karta()
            {
                VremeVazenja = DateTime.Now,
                IdCenovnikStavka=cenovnikStavkaId,
                Cena=cena,
                Validna=true             
            };

            if (userId != null)
                karta.IdApplicationUser = userId;

            else
                karta.ApplicationUser = null;

            db.Karte.Add(karta);
            db.SaveChanges();

            db.PayPal.Add(new PayPal() { IdKarte = karta.Id, PayerEmail = payer_email, PayerId = payer_id, TransactionId = transactionId });
            db.SaveChanges();

            if (!loggedIn)
                EmailHelper.SendMail(email, "Online kupovina karte", "Uspesno ste kupili " + tipKarte + " preko PayPal-a sa ID: " + karta.Id.ToString() + ",\n Cena: " + cena + " RSD,\n Vreme vazenja: " + karta.VremeVazenja.AddHours(1).ToString());

            return Ok(200);
        }

        [HttpGet]
        [Route("ValidirajKartu")]
        [ResponseType(typeof(IHttpActionResult))]
        public IHttpActionResult ValidirajKartu(int id)
        {

            try
            {
                if(CheckTicket(id))
                {
                    db.SaveChanges();
                    return Ok(200);   //karta validna
                }
                else
                {
                    db.SaveChanges();
                    return Ok(202);  //karta nevalidna
                }
                                  
            }
            catch
            {
                return Ok(204);    //karta sa zadatim id-em ne postoji
            }
        }

        [HttpGet]
        [Route("GetKupljeneKarte")]      
        public IHttpActionResult GetKupljeneKarte(string email)
        {
            List<Karta> karte = new List<Karta>();

            var korisnik = db.Users.Where(x => x.Email == email).FirstOrDefault();

            karte = db.Karte.Where(x => x.IdApplicationUser == korisnik.Id).Include(x=>x.CenovnikStavka).Include(x=>x.CenovnikStavka.Stavka).ToList();

            return Ok(karte);
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

        public bool CheckTicket(int id)
        {
            Karta karta = db.Karte.Where(x => x.Id == id).First();
            CenovnikStavka cenovnikStavka = db.CenovnikStavke.Where(x => x.Id == karta.IdCenovnikStavka).First();
            string tipKarte = db.Stavke.Where(x => x.Id == cenovnikStavka.Stavka_Id).Select(s => s.Naziv).First();
            long ticks = DateTime.Now.Ticks;

            if(tipKarte == "Vremenska karta")
            {
                if((ticks-karta.VremeVazenja.Ticks) < 36000000000)
                {
                    return true;
                }
                else
                {
                    karta.Validna = false;
                    return false;
                }
            }
            else if (tipKarte == "Dnevna karta")
            {
                if (karta.VremeVazenja.Year == DateTime.Now.Year && karta.VremeVazenja.Month == DateTime.Now.Month && karta.VremeVazenja.Day == DateTime.Now.Day)
                {
                    return true;
                }
                else
                {
                    karta.Validna = false;
                    return false;
                }
            }
            else if (tipKarte == "Mesecna karta")
            {
                if (karta.VremeVazenja.Year == DateTime.Now.Year && karta.VremeVazenja.Month == DateTime.Now.Month)
                {
                    return true;
                }
                else
                {
                    karta.Validna = false;
                    return false;
                }
            }
            else if (tipKarte == "Godisnja karta")
            {
                if (karta.VremeVazenja.Year == DateTime.Now.Year)
                {
                    return true;
                }
                else
                {
                    karta.Validna = false;
                    return false;
                }
            }

            return false;
        }
    }
}