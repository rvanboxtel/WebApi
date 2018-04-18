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
    public class cursusController : ApiController
    {
        private DBmodels db = new DBmodels();

        // GET: api/cursus
        public IQueryable<cursus> Getcursus()
        {
            return db.cursus;
        }

        // GET: api/cursus/5
        [ResponseType(typeof(cursus))]
        public IHttpActionResult Getcursus(int id)
        {
            cursus cursus = db.cursus.Find(id);
            if (cursus == null)
            {
                return NotFound();
            }

            return Ok(cursus);
        }

        // PUT: api/cursus/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putcursus(int id, cursus cursus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cursus.CURSUSCODE)
            {
                return BadRequest();
            }

            db.Entry(cursus).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!cursusExists(id))
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

        // POST: api/cursus
        [ResponseType(typeof(cursus))]
        public IHttpActionResult Postcursus(cursus cursus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.cursus.Add(cursus);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (cursusExists(cursus.CURSUSCODE))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cursus.CURSUSCODE }, cursus);
        }

        // DELETE: api/cursus/5
        [ResponseType(typeof(cursus))]
        public IHttpActionResult Deletecursus(int id)
        {
            cursus cursus = db.cursus.Find(id);
            if (cursus == null)
            {
                return NotFound();
            }

            db.cursus.Remove(cursus);
            db.SaveChanges();

            return Ok(cursus);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool cursusExists(int id)
        {
            return db.cursus.Count(e => e.CURSUSCODE == id) > 0;
        }
    }
}