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

            var stariRedVoznje = db.RedVoznje.Where(x => x.Aktivan && x.Id == id).First();

            if (stariRedVoznje == null) //red voznje obrisan od strane admina
                return Ok(202);
            
            if(stariRedVoznje.Version == redVoznje.Version)
            {
                redVoznje.Version += 1;

                db.Entry(stariRedVoznje).State = EntityState.Detached;
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

                return Ok(200);
            }
            else
            {
                return Ok(204);
            }
        }

        // POST: api/RedVoznjes
        [ResponseType(typeof(RedVoznje))]
        public IHttpActionResult PostRedVoznje(RedVoznje redVoznje)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            redVoznje.Aktivan = true;

            
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

        [HttpGet]
        [Route("getRedVoznje")]
        public IHttpActionResult GetRedVoznje(string tipRedaVoznje,string tipDana,int linijaId)
        {
            var redVoznje = db.RedVoznje.Include(x=>x.Linija).Where(x => x.IzabraniRedVoznje == tipRedaVoznje && x.IzabranTipDana == tipDana && x.LinijaId == linijaId).FirstOrDefault();

            if(redVoznje == null)
            {
                return Ok(201);
            }

           // List<string> polasci = new List<string>();

            //polasci = redVoznje.Polasci.Split(',').ToList();

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

      

        [HttpGet]
        [Route("ObrisiRedVoznje")]
        public IHttpActionResult ObrisiRedVoznje(int id)
        {
            var redVoznje = db.RedVoznje.Find(id);

            if (!redVoznje.Aktivan)
                return Ok(204);

            redVoznje.Aktivan = false;

            db.Entry(redVoznje).State = EntityState.Modified;
            db.SaveChanges();

            return Ok(200);
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
        public string TipRedaVoznje { get; set; }
        public string TipDana { get; set; }
      
    }

    public class PolazakRequestModel
    {
        public string TipDana { get; set; }
        public int LinijaId { get; set; }
    }
}