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
    public class schipklassesController : ApiController
    {
        private WebApiContext db = new WebApiContext();

        // GET: api/schipklasse
        public IQueryable<schipklasses> Getschipklasse()
        {
            return db.schipklasse;
        }

        // GET: api/schipklasse/5
        [ResponseType(typeof(schipklasses))]
        public async Task<IHttpActionResult> Getschipklasse(int id)
        {
            schipklasses schipklasse = await db.schipklasse.FindAsync(id);
            if (schipklasse == null)
            {
                return NotFound();
            }

            return Ok(schipklasse);
        }

        // PUT: api/schipklasse/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putschipklasse(int id, schipklasses schipklasse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != schipklasse.KLASSEID)
            {
                return BadRequest();
            }

            db.Entry(schipklasse).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!schipklasseExists(id))
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

        // POST: api/schipklasse
        [ResponseType(typeof(schipklasses))]
        public async Task<IHttpActionResult> Postschipklasse(schipklasses schipklasse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.schipklasse.Add(schipklasse);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = schipklasse.KLASSEID }, schipklasse);
        }

        // DELETE: api/schipklasse/5
        [ResponseType(typeof(schipklasses))]
        public async Task<IHttpActionResult> Deleteschipklasse(int id)
        {
            schipklasses schipklasse = await db.schipklasse.FindAsync(id);
            if (schipklasse == null)
            {
                return NotFound();
            }

            db.schipklasse.Remove(schipklasse);
            await db.SaveChangesAsync();

            return Ok(schipklasse);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool schipklasseExists(int id)
        {
            return db.schipklasse.Count(e => e.KLASSEID == id) > 0;
        }
    }
}