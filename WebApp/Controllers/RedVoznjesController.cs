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
using JGSPNSWebApp.Persistence.UnitOfWork;

namespace JGSPNSWebApp.Controllers
{
    public class RedVoznjesController : ApiController
    {
        public ApplicationDbContext db = new ApplicationDbContext();
     

      
        // GET: api/RedVoznjes
        public IQueryable<RedVoznje> GetRedVoznje()
        {
            return db.RedVoznje;
        }
        
        // GET: api/RedVoznjes/5
        [ResponseType(typeof(RedVoznje))]
        public IHttpActionResult GetRedVoznje(int id)
        {
            RedVoznje redVoznje = db.RedVoznje.Find(id);
            if (redVoznje == null)
            {
                return NotFound();
            }

            return Ok(redVoznje);
        }

        // PUT: api/RedVoznjes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRedVoznje(int id, RedVoznje redVoznje)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != redVoznje.Id)
            {
                return BadRequest();
            }

            db.Entry(redVoznje).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RedVoznjeExists(id))
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

        // POST: api/RedVoznjes
        [ResponseType(typeof(RedVoznje))]
        public IHttpActionResult PostRedVoznje(RedVoznje redVoznje)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RedVoznje.Add(redVoznje);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = redVoznje.Id }, redVoznje);
        }

        // DELETE: api/RedVoznjes/5
        [ResponseType(typeof(RedVoznje))]
        public IHttpActionResult DeleteRedVoznje(int id)
        {
            RedVoznje redVoznje = db.RedVoznje.Find(id);
            if (redVoznje == null)
            {
                return NotFound();
            }

            db.RedVoznje.Remove(redVoznje);
            db.SaveChanges();

            return Ok(redVoznje);
        }

        [HttpGet, Route("ucitajLinije")]
        public IEnumerable<Linija> UcitajLinije()
        {
            List<Linija> linije = new List<Linija>();

            using (DemoUnitOfWork unitOfWork = new DemoUnitOfWork(db))
            {
                foreach (var linija in unitOfWork.Linije.GetAll())
                {
                    linije.Add(linija);
                }
            }

            return linije;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RedVoznjeExists(int id)
        {
            return db.RedVoznje.Count(e => e.Id == id) > 0;
        }
    }
}