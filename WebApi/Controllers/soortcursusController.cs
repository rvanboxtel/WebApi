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
    public class soortcursusController : ApiController
    {
        private dewaaiEntities db = new dewaaiEntities();

        // GET: api/soortcursus
        public IQueryable<soortcursus> Getsoortcursus()
        {
            return db.soortcursus;
        }

        // GET: api/soortcursus/5
        [ResponseType(typeof(soortcursus))]
        public IHttpActionResult Getsoortcursus(int id)
        {
            soortcursus soortcursus = db.soortcursus.Find(id);
            if (soortcursus == null)
            {
                return NotFound();
            }

            return Ok(soortcursus);
        }

        // PUT: api/soortcursus/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putsoortcursus(int id, soortcursus soortcursus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != soortcursus.SOORTCODE)
            {
                return BadRequest();
            }

            db.Entry(soortcursus).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!soortcursusExists(id))
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

        // POST: api/soortcursus
        [ResponseType(typeof(soortcursus))]
        public IHttpActionResult Postsoortcursus(soortcursus soortcursus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.soortcursus.Add(soortcursus);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (soortcursusExists(soortcursus.SOORTCODE))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = soortcursus.SOORTCODE }, soortcursus);
        }

        // DELETE: api/soortcursus/5
        [ResponseType(typeof(soortcursus))]
        public IHttpActionResult Deletesoortcursus(int id)
        {
            soortcursus soortcursus = db.soortcursus.Find(id);
            if (soortcursus == null)
            {
                return NotFound();
            }

            db.soortcursus.Remove(soortcursus);
            db.SaveChanges();

            return Ok(soortcursus);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool soortcursusExists(int id)
        {
            return db.soortcursus.Count(e => e.SOORTCODE == id) > 0;
        }
    }
}