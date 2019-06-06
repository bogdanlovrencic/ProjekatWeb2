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
            Karta karta = new Karta(rand.Next(0,1000), DateTime.Now,DateTime.Now.AddHours(1));
          
            //unitOfWork.Karte.Add(karta);
            //unitOfWork.Complete();


            ServiceController serviceController = new ServiceController(unitOfWork);
            //if(serviceController.ServicesExists(123))
            //{
                if (serviceController.SendMail(emailAddress, "JGSP NS online kupovina karte", $"Postovani, kupili ste vremensku kartu sa Rednim brojem: {karta.Id.ToString()} za gradski prevoz u roku vazenja od {karta.VremeOd.ToString()} do {karta.VremeDo.ToString()}"))
                {

                }
            //}
            //return CreatedAtRoute("DefaultApi", new { id = karta.Id }, karta);
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