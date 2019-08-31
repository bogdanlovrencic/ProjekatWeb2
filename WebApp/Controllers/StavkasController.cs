﻿using System;
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
    [RoutePrefix("api/Stavkas")]
    public class StavkasController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Stavkas
        public IQueryable<Stavka> GetStavke()
        {
            return db.Stavke;
        }

        [Route("Stavke")]
        [HttpGet]
        [ResponseType(typeof(Stavka))]
        public IHttpActionResult GetAllForType(string naziv)
        {
          
            return Ok(db.Stavke.Where(x=>x.Naziv == naziv).ToList());
        }

        // GET: api/Stavkas/5
        [ResponseType(typeof(Stavka))]
        public IHttpActionResult GetStavka(string naziv)
        {
            Stavka stavka = db.Stavke.Find(naziv);
            if (stavka == null)
            {
                return NotFound();
            }

            return Ok(stavka);
        }

        // PUT: api/Stavkas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStavka(int id, Stavka stavka)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stavka.Id)
            {
                return BadRequest();
            }

            db.Entry(stavka).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StavkaExists(id))
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

        // POST: api/Stavkas
        public IHttpActionResult PostStavka(StavkaBindingModel stavka)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Stavka s = new Stavka();

            s.Naziv = stavka.Naziv;
            s.Cena = stavka.Cena;

            db.Stavke.Add(s);
            db.SaveChanges();

            return Ok();
        }

        // DELETE: api/Stavkas/5
        [ResponseType(typeof(Stavka))]
        public IHttpActionResult DeleteStavka(int id)
        {
            Stavka stavka = db.Stavke.Find(id);
            if (stavka == null)
            {
                return NotFound();
            }

            db.Stavke.Remove(stavka);
            db.SaveChanges();

            return Ok(stavka);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StavkaExists(int id)
        {
            return db.Stavke.Count(e => e.Id == id) > 0;
        }
    }

    public class StavkaBindingModel
    {
        public string Naziv { get; set; }
        public double Cena { get; set; }
    }
}