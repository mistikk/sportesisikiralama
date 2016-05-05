using AngularJSAuthentication.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AngularJSAuthentication.API.Controllers
{
    [RoutePrefix("api/get")]
    public class ServicesController : ApiController
    {

        private SportesisiEntities db = new SportesisiEntities();

        [Route("il")]
        [HttpGet]
        public IHttpActionResult il()
        {
            List<iller> iller = new List<iller>();
            iller = db.iller.ToList();
            return Ok(iller);
        }

        [Route("getilce")]
        [HttpPost]
        public IHttpActionResult ilce(int ilId)
        {
            List<ilceler> ilceler = new List<ilceler>();
            ilceler = db.ilceler.Where(x => x.sehir == ilId).ToList();
            return Ok(ilceler);
        }
    }
}
