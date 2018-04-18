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
using WebApi.Models;

namespace WebApi.Controllers
{
    public class werknemersController : ApiController
    {
        private DBmodels db = new DBmodels();

        // GET: api/werknemers
        public IQueryable<werknemers> Getwerknemers()
        {
            return db.werknemers;
        }

        // GET: api/werknemers/5
        [ResponseType(typeof(werknemers))]
        public IHttpActionResult Getwerknemers(int id)
        {
            werknemers werknemers = db.werknemers.Find(id);
            if (werknemers == null)
            {
                return NotFound();
            }

            return Ok(werknemers);
        }

        // PUT: api/werknemers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putwerknemers(int id, werknemers werknemers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != werknemers.WERKNEMERID)
            {
                return BadRequest();
            }

            db.Entry(werknemers).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!werknemersExists(id))
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

        // POST: api/werknemers
        [ResponseType(typeof(werknemers))]
        public IHttpActionResult Postwerknemers(werknemers werknemers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.werknemers.Add(werknemers);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = werknemers.WERKNEMERID }, werknemers);
        }

        // DELETE: api/werknemers/5
        [ResponseType(typeof(werknemers))]
        public IHttpActionResult Deletewerknemers(int id)
        {
            werknemers werknemers = db.werknemers.Find(id);
            if (werknemers == null)
            {
                return NotFound();
            }

            db.werknemers.Remove(werknemers);
            db.SaveChanges();

            return Ok(werknemers);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool werknemersExists(int id)
        {
            return db.werknemers.Count(e => e.WERKNEMERID == id) > 0;
        }
    }
}