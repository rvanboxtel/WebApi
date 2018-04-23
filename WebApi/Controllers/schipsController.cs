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
using WebApi.Dao;

namespace WebApi.Controllers
{
    public class schipsController : ApiController
    {
        private WebApiContext db = new WebApiContext();
        public const string DatabaseConnectionString = "Data Source=tcp:zeilschooldewaai20180416022428dbserver.database.windows.net,1433;Initial Catalog=dewaai;User ID=development;Password=Gian_2002;Timeout=60;";

        // Create a new db context (db connection)
        private readonly Dao.DbContext _context = new Dao.DbContext(DatabaseConnectionString);
        // GET: api/schips
        public IQueryable<schips> Getschip()
        {
            return db.schip;
        }

        //// GET: api/schips/5
        //[ResponseType(typeof(schips))]
        //public async Task<IHttpActionResult> Getschips(int id)
        //{
        //    schips schips = await db.schip.FindAsync(id);
        //    if (schips == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(schips);
        //}
        [HttpGet]
        public async Task<schips> Get(int id)
        {
            return await new Query<schips>(_context).Read(id);
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
        //[ResponseType(typeof(schips))]
        //[HttpPost]
        //public async Task<IHttpActionResult> Postschips(schips schips)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.schip.Add(schips);
        //    await db.SaveChangesAsync();

        //    return CreatedAtRoute("DefaultApi", new { id = schips.NUMMER }, schips);
        //}
        // POST api/values
        [HttpPost]
        public async Task Post([FromBody]schips value)
        {
            db.schip.Add(value);
            await db.SaveChangesAsync();

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