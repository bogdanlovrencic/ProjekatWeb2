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
    [RoutePrefix("api/Korisnik")]
    public class KorisniksController : ApiController
    {
       
        //private ApplicationDbContext db = new ApplicationDbContext();
        //private IUnitOfWork unitOfWork;//
        

        //// GET: api/Korisniks

        //public KorisniksController (IUnitOfWork unitOfWork)
        //{
        //    this.unitOfWork = unitOfWork;
        //}
        //public IQueryable<Korisnik> GetKorisniks()
        //{
        //    return db.Korisniks;
        //}

        //// GET: api/Korisniks/5
        //[ResponseType(typeof(Korisnik))]
        //public IHttpActionResult GetKorisnik(int id)
        //{
        //    Korisnik korisnik = db.Korisniks.Find(id);
        //    if (korisnik == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(korisnik);
        //}

        //// PUT: api/Korisniks/5
        //[ResponseType(typeof(void))]
        //[Route("PutKorisnik")]
        //public IHttpActionResult PutKorisnik(int id, Korisnik korisnik)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != korisnik.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(korisnik).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!KorisnikExists(id))
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

        //// POST: api/Korisniks
        //[ResponseType(typeof(Korisnik))]
        //public IHttpActionResult PostKorisnik(Korisnik korisnik)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Korisniks.Add(korisnik);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = korisnik.Id }, korisnik);
        //}

        //// DELETE: api/Korisniks/5
        //[ResponseType(typeof(Korisnik))]
        //public IHttpActionResult DeleteKorisnik(int id)
        //{
        //    Korisnik korisnik = db.Korisniks.Find(id);
        //    if (korisnik == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Korisniks.Remove(korisnik);
        //    db.SaveChanges();

        //    return Ok(korisnik);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool KorisnikExists(int id)
        //{
        //    return db.Korisniks.Count(e => e.Id == id) > 0;
        //}
    }
}