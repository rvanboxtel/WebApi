using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataModelDB;
namespace WebApi.Controllers
{
    public class SoortCursusController : ApiController
    {
        public IEnumerable<soortcursu> Get()
        {
            using(dewaaiEntities entities = new dewaaiEntities())
            {
                return entities.soortcursus.ToList();
            }
        }
        public soortcursu Get(int id)
        {
            using (dewaaiEntities entities = new dewaaiEntities())
            {
                return entities.soortcursus.FirstOrDefault(e => e.SOORTCODE == id);
            }
        }
    }
}
