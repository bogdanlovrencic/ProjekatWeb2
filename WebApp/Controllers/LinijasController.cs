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
    [RoutePrefix("api/Linijas")]
    public class LinijasController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Linijas
        public IQueryable<Linija> GetLinije()
        {
            return db.Linije.Include(x=>x.Stanice).Where(linija => linija.Aktivna && linija.Stanice.Any(s=>s.Aktivna));
        }

        // GET: api/Linijas/5
        [ResponseType(typeof(Linija))]
        public IHttpActionResult GetLinija(string naziv)
        {
            Linija linija= db.Linije.Include(x => x.Stanice).FirstOrDefault(x => x.Naziv.ToLower().Equals(naziv.ToLower()));
            var staniceAktivne = linija.Stanice.FindAll(s => s.Aktivna);
            linija.Stanice = staniceAktivne;

            if (linija == null)
            {
                return NotFound();
            }
            

            return Ok(linija);
        }

        // PUT: api/Linijas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLinija(int id, Linija linija)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var line = db.Linije.Where(x=>x.Id == id && x.Aktivna).First();

            if(line == null)//ako je null linija je obrisana od strane admina
            {
                return Ok(202);
            }


            var oldVersion = db.Linije.Where(x => x.Aktivna && x.Id == id).Select(c => c.Version).First();
            var stareStanice = db.Stanice.Where(x=>x.Linije.Any(l=>l.Id == id)).ToList();
           // var stareStaniceZaOdabranuLiniju = new List<Stanica>();


            Linija lin = db.Linije.Where(x=>x.Id == id && x.Aktivna).First();

            if (oldVersion == linija.Version)
            {
                foreach (Stanica s in linija.Stanice)
                {
                    foreach (var st in stareStanice)
                    {
                        if (s.Id == st.Id && !st.Aktivna)
                            return Ok(205);
                        if(st.Id == s.Id && !st.Equals(s))
                        {
                            if (st.Version == s.Version )
                            {
                                //if (!s.Aktivna)
                                //{
                                //    s.Version += 1;
                                //    s.Aktivna = true;
                                //    //s.Linije = new List<Linija>();
                                //    lin = db.Linije.Include(x => x.Stanice).FirstOrDefault(x => x.Id == id);
                                //    lin.Stanice.Add(s);
                                //    //db.Entry(lin).State = EntityState.Modified;
                                //    //db.SaveChanges();
                                //    //db.Stanice.Add(s);
                                //    //db.SaveChanges();
                                //}
                                //else
                                //{
                                    s.Version += 1;
                                    db.Entry(st).State = EntityState.Detached;
                                    db.Entry(s).State= EntityState.Modified;
                                    db.SaveChanges();
                                    //continue;
                                //}
                            }
                            else
                            {
                                return Ok(203);
                            }
                        }
                        //else if(st.Id == s.Id && st.Equals(s))
                        //{
                        //    return Ok(205);
                        //}

                       
                    }
                    if (!stareStanice.Any(x => x.Id == s.Id))
                    {

                        s.Aktivna = true;
                        //s.Linije = new List<Linija>();
                        lin = db.Linije.Include(x => x.Stanice).FirstOrDefault(x => x.Id == id);
                        lin.Stanice.Add(s);
                        break;
                    }

                }

                lin.Version += 1;

                db.Entry(lin).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LinijaExists(id))
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

        // POST: api/Linijas
        [ResponseType(typeof(Linija))]
        public IHttpActionResult PostLinija(Linija linija)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var line = db.Linije.Any(lin => lin.Aktivna && lin.Naziv == linija.Naziv);

            if (line == true)
                return BadRequest(ModelState);
           

            linija.Aktivna = true;
            foreach(var stanica in linija.Stanice)
            {
                stanica.Aktivna = true;
            }

            db.Linije.Add(linija);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = linija.Id }, linija);
           
        }

        // DELETE: api/Linijas/5
        [ResponseType(typeof(Linija))]
        public IHttpActionResult DeleteLinija(int id)
        {
            Linija linija = db.Linije.Find(id);
            if (linija == null)
            {
                return NotFound();
            }

            db.Linije.Remove(linija);
            db.SaveChanges();

            return Ok(linija);
        }

        [HttpGet]
        [Route("ObrisiLiniju")]
        [ResponseType(typeof(Linija))]
        public IHttpActionResult ObrisiLiniju(string naziv)
        {
            Linija linija = db.Linije.FirstOrDefault(l=>l.Naziv == naziv);

            if (!linija.Aktivna)
                return Ok(204); 

            linija.Aktivna = false;

            db.Entry(linija).State = EntityState.Modified;
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

        private bool LinijaExists(int id)
        {
            return db.Linije.Count(e => e.Id == id) > 0;
        }
    }

   
}