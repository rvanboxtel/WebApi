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
    public class schipsController : ApiController
    {
        private dewaaiEntities db = new dewaaiEntities();

        // GET: api/schips
        public IQueryable<schip> Getschip()
        {
            return db.schip;
        }

        // GET: api/schips/5
        [ResponseType(typeof(schip))]
        public IHttpActionResult Getschip(int id)
        {
            schip schip = db.schip.Find(id);
            if (schip == null)
            {
                return NotFound();
            }

            return Ok(schip);
        }

        // PUT: api/schips/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putschip(int id, schip schip)
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
                db.SaveChanges();
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
        public IHttpActionResult Postschip(schip schip)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.schip.Add(schip);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (schipExists(schip.NUMMER))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = schip.NUMMER }, schip);
        }

        // DELETE: api/schips/5
        [ResponseType(typeof(schip))]
        public IHttpActionResult Deleteschip(int id)
        {
            schip schip = db.schip.Find(id);
            if (schip == null)
            {
                return NotFound();
            }

            db.schip.Remove(schip);
            db.SaveChanges();

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