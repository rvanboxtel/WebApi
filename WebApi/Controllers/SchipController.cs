using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class SchipController : ApiController
    {
        public IEnumerable<schip> GetSchips()
        {
            using(dewaaiEntities entities = new dewaaiEntities())
            {
                return entities.schip.ToList();
            }
        }
    }
}
