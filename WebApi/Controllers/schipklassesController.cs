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
    public class schipklassesController : ApiController
    {
        private DBmodels db = new DBmodels();

        // GET: api/schipklasses
        public IQueryable<schipklasse> Getschipklasse()
        {
            return db.schipklasse;
        }

        // GET: api/schipklasses/5
        [ResponseType(typeof(schipklasse))]
        public IHttpActionResult Getschipklasse(int id)
        {
            schipklasse schipklasse = db.schipklasse.Find(id);
            if (schipklasse == null)
            {
                return NotFound();
            }

            return Ok(schipklasse);
        }

        // PUT: api/schipklasses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putschipklasse(int id, schipklasse schipklasse)
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
                db.SaveChanges();
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

        // POST: api/schipklasses
        [ResponseType(typeof(schipklasse))]
        public IHttpActionResult Postschipklasse(schipklasse schipklasse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.schipklasse.Add(schipklasse);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (schipklasseExists(schipklasse.KLASSEID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = schipklasse.KLASSEID }, schipklasse);
        }

        // DELETE: api/schipklasses/5
        [ResponseType(typeof(schipklasse))]
        public IHttpActionResult Deleteschipklasse(int id)
        {
            schipklasse schipklasse = db.schipklasse.Find(id);
            if (schipklasse == null)
            {
                return NotFound();
            }

            db.schipklasse.Remove(schipklasse);
            db.SaveChanges();

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