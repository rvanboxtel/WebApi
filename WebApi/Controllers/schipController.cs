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
    public class schipController : ApiController
    {
        private WebApiContext db = new WebApiContext();

        // GET: api/schips
        public IQueryable<schip> Getschips()
        {
            return db.schip;
        }

        // GET: api/schips/5
        [ResponseType(typeof(schip))]
        public async Task<IHttpActionResult> Getschip(int id)
        {
            schip schip = await db.schip.FindAsync(id);
            if (schip == null)
            {
                return NotFound();
            }

            return Ok(schip);
        }

        // PUT: api/schips/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putschip(int id, schip schip)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != schip.NUMMER)
            {
                return BadRequest();
            }

            db.Entry(schip).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!schipExists(id))
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

        // POST: api/schips
        [ResponseType(typeof(schip))]
        public async Task<IHttpActionResult> Postschip(schip schip)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.schip.Add(schip);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = schip.NUMMER }, schip);
        }

        // DELETE: api/schips/5
        [ResponseType(typeof(schip))]
        public async Task<IHttpActionResult> Deleteschip(int id)
        {
            schip schip = await db.schip.FindAsync(id);
            if (schip == null)
            {
                return NotFound();
            }

            db.schip.Remove(schip);
            await db.SaveChangesAsync();

            return Ok(schip);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool schipExists(int id)
        {
            return db.schip.Count(e => e.NUMMER == id) > 0;
        }
    }
}