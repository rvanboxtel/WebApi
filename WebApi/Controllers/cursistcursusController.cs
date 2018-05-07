using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class cursistcursusController : ApiController
    {
        private WebApiContext db = new WebApiContext();

        // GET: api/cursistcursus
        public IQueryable<cursistcursus> Getcursistcursus()
        {
            return db.cursistcursus;
        }

        // GET: api/cursistcursus/5
        [ResponseType(typeof(cursistcursus))]
        public async Task<IHttpActionResult> Getcursistcursus(int id)
        {
            cursistcursus cursistcursus = await db.cursistcursus.FindAsync(id);
            if (cursistcursus == null)
            {
                return NotFound();
            }

            return Ok(cursistcursus);
        }

        // PUT: api/cursistcursus/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putcursistcursus(int id, cursistcursus cursistcursus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cursistcursus.CURSUSCODE)
            {
                return BadRequest();
            }

            db.Entry(cursistcursus).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!cursistcursusExists(id))
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

        // POST: api/cursistcursus
        [ResponseType(typeof(cursistcursus))]
        public async Task<IHttpActionResult> Postcursistcursus(cursistcursus cursistcursus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.cursistcursus.Add(cursistcursus);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (cursistcursusExists(cursistcursus.CURSUSCODE))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cursistcursus.CURSUSCODE }, cursistcursus);
        }

        // DELETE: api/cursistcursus/5
        [ResponseType(typeof(cursistcursus))]
        public async Task<IHttpActionResult> Deletecursistcursus(int id)
        {
            cursistcursus cursistcursus = await db.cursistcursus.FindAsync(id);
            if (cursistcursus == null)
            {
                return NotFound();
            }

            db.cursistcursus.Remove(cursistcursus);
            await db.SaveChangesAsync();

            return Ok(cursistcursus);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool cursistcursusExists(int id)
        {
            return db.cursistcursus.Count(e => e.CURSUSCODE == id) > 0;
        }
    }
}