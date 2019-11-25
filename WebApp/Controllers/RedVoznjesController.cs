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
    [RoutePrefix("api/RedVoznjes")]
    public class RedVoznjesController : ApiController
    {
        public ApplicationDbContext db = new ApplicationDbContext();
     

      
        // GET: api/RedVoznjes
        public IQueryable<RedVoznje> GetRedVoznje()
        {
            return db.RedVoznje.Where(redVoznje=>redVoznje.Aktivan);
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
        public IHttpActionResult PostRedVoznje(RedVoznjeBindingModel redVoznje)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            RedVoznje rv = new RedVoznje();

            if (redVoznje.TipRedaVoznje == 0)
                rv.IzabraniRedVoznje = TipRedaVoznje.Gradski.ToString();

            else
            {
                rv.IzabraniRedVoznje = TipRedaVoznje.Prigradski.ToString();
            }

           
            rv.IzabranTipDana = redVoznje.TipDana;
            rv.LinijaId = redVoznje.LinijaId;
            rv.Aktivan = true;

            
            db.RedVoznje.Add(rv);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = rv.Id }, rv);
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

        [HttpGet]
        [Route("getLinije")]
        public IHttpActionResult GetLinije(int tipLinije)
        {
            var linije = db.Linije.Where(x => x.TipLinije == (TipLinije)tipLinije && x.Aktivna);

            if(linije!=null)
            {
                return Ok(linije);
            }

            return Ok(new List<Linija>(0));
        }

        [HttpPost]
        [Route("getPolasci")]
        public IHttpActionResult GetPolasci(PolazakRequestModel polazak)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var polasci = db.Polasci.Where(x => x.LinijaId == polazak.LinijaId && x.TipDana == polazak.TipDana && x.Active);

            if (polasci != null)
            {
                return Ok(polasci);
            }

            return Ok(new List<Polazak>(0));
        }

        [HttpGet]
        [Route("ObrisiRedVoznje")]
        public IHttpActionResult ObrisiRedVoznje(int id)
        {
            var redVoznje = db.RedVoznje.Find(id);

            if (redVoznje == null)
                return BadRequest("Red voznje sa prosledjenim id ne postoji!");

            redVoznje.Aktivan = false;

            db.Entry(redVoznje).State = EntityState.Modified;
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

        private bool RedVoznjeExists(int id)
        {
            return db.RedVoznje.Count(e => e.Id == id) > 0;
        }
    }

    public class RedVoznjeBindingModel
    {
        public int LinijaId { get; set; }
        public int TipRedaVoznje { get; set; }
        public string TipDana { get; set; }
      
    }

    public class PolazakRequestModel
    {
        public string TipDana { get; set; }
        public int LinijaId { get; set; }
    }
}