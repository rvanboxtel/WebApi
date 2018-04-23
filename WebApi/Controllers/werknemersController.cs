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
    public class werknemersController : ApiController
    {
        private WebApiContext db = new WebApiContext();

        // GET: api/werknemers
        public IQueryable<werknemers> Getwerknemers()
        {
            return db.werknemers;
        }

        // GET: api/werknemers/5
        [ResponseType(typeof(werknemers))]
        public async Task<IHttpActionResult> Getwerknemers(string id)
        {
            werknemers werknemers = await db.werknemers.FindAsync(id);
            if (werknemers == null)
            {
                return Ok("gebruiker bestaat niet");
            }

            return Ok(werknemers);
        }

        //// PUT: api/werknemers/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> Putwerknemers(int id, werknemers werknemers)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != werknemers.WERKNEMERID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(werknemers).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!werknemersExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/werknemers
        //[ResponseType(typeof(werknemers))]
        //public async Task<IHttpActionResult> Postwerknemers(werknemers werknemers)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.werknemers.Add(werknemers);
        //    await db.SaveChangesAsync();

        //    return CreatedAtRoute("DefaultApi", new { id = werknemers.WERKNEMERID }, werknemers);
        //}

        //// DELETE: api/werknemers/5
        //[ResponseType(typeof(werknemers))]
        //public async Task<IHttpActionResult> Deletewerknemers(int id)
        //{
        //    werknemers werknemers = await db.werknemers.FindAsync(id);
        //    if (werknemers == null)
        //    {
        //        return NotFound();
        //    }

        //    db.werknemers.Remove(werknemers);
        //    await db.SaveChangesAsync();

        //    return Ok(werknemers);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool werknemersExists(string id)
        {
            return db.werknemers.Count(e => e.GEBRUIKERSNAAM == id) > 0;
        }
    }
}