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
    [RoutePrefix("api/karte")]
    public class KartasController : ApiController
    {
        public static ApplicationDbContext db = new ApplicationDbContext();
        private IUnitOfWork unitOfWork= new DemoUnitOfWork(db);

        //public KartasController(IUnitOfWork unitOfWork)
        //{
        //    this.unitOfWork = unitOfWork;
        //}
        // GET: api/Kartas
        //public IQueryable<Karta> GetKartas()
        //{
        //    return db.Kartas;
        //}

        //// GET: api/Kartas/5
        //[ResponseType(typeof(Karta))]
        //public IHttpActionResult GetKarta(int id)
        //{
        //    Karta karta = db.Kartas.Find(id);
        //    if (karta == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(karta);
        //}

        //// PUT: api/Kartas/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutKarta(int id, Karta karta)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != karta.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(karta).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!KartaExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST: api/Kartas
        [HttpPost, Route("kupi")]
        [ResponseType(typeof(Karta))]
        public IHttpActionResult PostKarta(Email email)
        {

            var emailAddress = email.Name;
            Random rand = new Random();
            Karta karta = new Karta(rand.Next(0,1000).ToString(), DateTime.Now,DateTime.Now.AddHours(1));
          
            unitOfWork.Karte.Add(karta);
            unitOfWork.Complete();


            ServiceController serviceController = new ServiceController(unitOfWork);
           string subject= "JGSP NS online kupovina karta";
            string body = $"Postovani,\n\nKupili ste vremensku kartu sa Rednim brojem: {karta.Id} za gradski prevoz u roku vazenja od {karta.VremeOd.ToString()} do {karta.VremeDo.ToString()}.\nUzivajte u voznji.\n\nVas JGSP Novi Sad.";
            if (!serviceController.SendMail(emailAddress, subject, body))
            {
                return BadRequest();
            }

            return Ok("Uspesno ste kupili vremensku kartu za gradski prevoz.");

            
        }

        [HttpPost, Route("prikaziCenovnik")]
        [ResponseType(typeof(Cenovnik))]
        public IHttpActionResult PrikazCenovnika([FromBody]string tipKarte,[FromBody]string tipPutnika)
        {
            VrstaKarte vrstaKarte;
            if (tipKarte == "DNEVNA_KARTA")
                vrstaKarte = VrstaKarte.DNEVNA_KARTA;

            else if (tipKarte == "GODISNJA_KARTA")
                vrstaKarte = VrstaKarte.GODISNJA_KARTA;
            

            else if (tipKarte == "MESECNA_KARTA")
                vrstaKarte = VrstaKarte.MESECNA_KARTA;

            else if (tipKarte == "VREMENSKA_KARTA")
                vrstaKarte = VrstaKarte.VREMENSKA_KARTA;

            TipPutnika putnik;
            if (tipPutnika == "DJAK")
                putnik = TipPutnika.DJAK;

            else if (tipPutnika == "PENZIONER")
                putnik = TipPutnika.PENZIONER;

            else if (tipPutnika == "REGULARNI_PUTNIK")
                putnik = TipPutnika.REGULARNI_PUTNIK;




            return BadRequest();
        }

            // DELETE: api/Kartas/5
            //[ResponseType(typeof(Karta))]
            //public IHttpActionResult DeleteKarta(int id)
            //{
            //    Karta karta = db.Kartas.Find(id);
            //    if (karta == null)
            //    {
            //        return NotFound();
            //    }

            //    db.Kartas.Remove(karta);
            //    db.SaveChanges();

            //    return Ok(karta);
            //}

            //protected override void Dispose(bool disposing)
            //{
            //    if (disposing)
            //    {
            //        db.Dispose();
            //    }
            //    base.Dispose(disposing);
            //}

            //private bool KartaExists(int id)
            //{
            //    return db.Kartas.Count(e => e.Id == id) > 0;
            //}
        }
}