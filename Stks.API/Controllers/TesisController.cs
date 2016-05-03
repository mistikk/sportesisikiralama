using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AngularJSAuthentication.API.Models;
using System.Data.Entity.Infrastructure;

namespace AngularJSAuthentication.API.Controllers
{
    [RoutePrefix("api/tesis")]
    public class TesisController : ApiController
    {
        private SportesisiEntities db = new SportesisiEntities();
        // POST: odata/Tesis
        [Route("save")]
        public IHttpActionResult Save(Tesisler tesisler)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tesisler.Add(tesisler);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TesislerExists(tesisler.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Ok(tesisler);
        }
        [Route("Search")]
        public IHttpActionResult Search(SearchModel searchModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            List<Tesisler> tesisler = db.Tesisler.Where(x => x.sporTuru == searchModel.sporTuru &&
                                                             x.il == searchModel.il &&
                                                             x.ilce == searchModel.ilce &&
                                                             x.servis == searchModel.servis).ToList();

            List<Tesisler> bosListe = new List<Tesisler>();

            foreach (var item in tesisler)
            {
                List<TesisKiralama> sa = db.TesisKiralama.Where(x => x.tesisId == item.Id &&
                                                x.tarih >= searchModel.tarih1 &&
                                                x.tarih <= searchModel.tarih2 &&
                                                x.baslangicSaati >= searchModel.saat1 &&
                                                x.bitisSaati <= searchModel.saat2).ToList();
                if (sa.Count == 0)
                {
                    bosListe.Add(item);
                }
            }
            



            return Ok(bosListe);
        }

        private bool TesislerExists(int key)
        {
            return db.Tesisler.Count(e => e.Id == key) > 0;
        }
    }
}
