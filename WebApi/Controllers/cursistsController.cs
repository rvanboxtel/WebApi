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
    public class cursistsController : ApiController
    {
        private DBmodels db = new DBmodels();

        // GET: api/cursists
        public IQueryable<cursist> Getcursist()
        {
            return db.cursist;
        }

        // GET: api/cursists/5
        [ResponseType(typeof(cursist))]
        public IHttpActionResult Getcursist(string id)
        {
            cursist cursist = db.cursist.Find(id);
            if (cursist == null)
            {
                return NotFound();
            }

            return Ok(cursist);
        }

        // PUT: api/cursists/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putcursist(string id, cursist cursist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cursist.EMAILADRES)
            {
                return BadRequest();
            }

            db.Entry(cursist).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!cursistExists(id))
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

        // POST: api/cursists
        [ResponseType(typeof(cursist))]
        public IHttpActionResult Postcursist(cursist cursist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.cursist.Add(cursist);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (cursistExists(cursist.EMAILADRES))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cursist.EMAILADRES }, cursist);
        }

        // DELETE: api/cursists/5
        [ResponseType(typeof(cursist))]
        public IHttpActionResult Deletecursist(string id)
        {
            cursist cursist = db.cursist.Find(id);
            if (cursist == null)
            {
                return NotFound();
            }

            db.cursist.Remove(cursist);
            db.SaveChanges();

            return Ok(cursist);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool cursistExists(string id)
        {
            return db.cursist.Count(e => e.EMAILADRES == id) > 0;
        }
    }
}