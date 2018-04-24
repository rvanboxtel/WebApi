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
    public class schipsController : ApiController
    {
        private WebApiContext db = new WebApiContext();

        // GET: api/schips
        public IQueryable<schips> Getschip()
        {
            return db.schip;
        }

        // GET: api/schips/5
        [ResponseType(typeof(schips))]
        public async Task<IHttpActionResult> Getschips(int id)
        {
            schips schips = await db.schip.FindAsync(id);
            if (schips == null)
            {
                return NotFound();
            }

            return Ok(schips);
        }

        // PUT: api/schips/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putschips(int id, schips schips)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != schips.NUMMER)
            {
                return BadRequest();
            }

            db.Entry(schips).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!schipsExists(id))
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
        [ResponseType(typeof(schips))]
        public async Task<IHttpActionResult> PostBook(schips schip)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.schip.Add(schip);
            await db.SaveChangesAsync();

            // Load schips name
            db.Entry(schip).Reference(x => x.NAAM).Load();

            var dto = new schips()
            {
                NUMMER = schip.NUMMER,
                KLASSE = schip.KLASSE,
                NAAM = schip.NAAM,
                AVERIJ = schip.AVERIJ,
                SOORTCODE = schip.SOORTCODE
            };

            return CreatedAtRoute("DefaultApi", new { id = schip.NUMMER }, dto);
        }

        // DELETE: api/schips/5
        [ResponseType(typeof(schips))]
        public async Task<IHttpActionResult> Deleteschips(int id)
        {
            schips schips = await db.schip.FindAsync(id);
            if (schips == null)
            {
                return NotFound();
            }

            db.schip.Remove(schips);
            await db.SaveChangesAsync();

            return Ok(schips);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool schipsExists(int id)
        {
            return db.schip.Count(e => e.NUMMER == id) > 0;
        }
    }
}