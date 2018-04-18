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
        public async Task<IHttpActionResult> Getcursist(string id)
        {
            cursist cursist = await db.cursist.FindAsync(id);
            if (cursist == null)
            {
                return NotFound();
            }

            return Ok(cursist);
        }

        // PUT: api/cursists/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putcursist(string id, cursist cursist)
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
                await db.SaveChangesAsync();
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
        public async Task<IHttpActionResult> Postcursist(cursist cursist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.cursist.Add(cursist);

            try
            {
                await db.SaveChangesAsync();
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
        public async Task<IHttpActionResult> Deletecursist(string id)
        {
            cursist cursist = await db.cursist.FindAsync(id);
            if (cursist == null)
            {
                return NotFound();
            }

            db.cursist.Remove(cursist);
            await db.SaveChangesAsync();

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