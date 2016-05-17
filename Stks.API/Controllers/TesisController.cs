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
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            List<Tesisler> tesisler = db.Tesisler.Where(x => x.sporTuru == searchModel.sporTuru &&
                                                             x.il == searchModel.il &&
                                                             x.ilce == searchModel.ilce &&
                                                             x.servis == searchModel.servis).ToList();

            List<Tesisler> bosListe = new List<Tesisler>();

            foreach (var item in tesisler) //hatalı; saat araasında sadece 1 dolu olsa bile tüm saat aralığını dolu gösteriyor
            {
                List<TesisKiralama> sa = db.TesisKiralama.Where(x => x.tesisId == item.Id &&
                                                x.tarih >= searchModel.tarih1 &&
                                                x.tarih <= searchModel.tarih2 &&
                                                x.baslangicSaati >= searchModel.saat1 &&
                                                x.bitisSaati <= searchModel.saat2).ToList();
                Tesisler tesis = new Tesisler();
                tesis.acilisSaati = item.acilisSaati;
                tesis.adres = item.adres;
                tesis.Id = item.Id;
                tesis.il = item.il;
                tesis.ilce = item.ilce;
                tesis.kapanisSaati = item.kapanisSaati;
                tesis.resim = item.resim;
                tesis.saatDilimi = item.saatDilimi;
                tesis.sahaAdi = item.sahaAdi;
                tesis.servis = item.servis;
                tesis.sporTuru = item.sporTuru;
                tesis.telNo = item.telNo;
                tesis.tesisAdi = item.tesisAdi;
                tesis.ucret = item.ucret;
                if (sa.Count == 0)
                {
                    bosListe.Add(tesis);
                }
            }
            return Ok(bosListe);
        }

        //[Route("Sa")]
        //public IHttpActionResult sa()
        //{
        //    List<int> NumberList = new List<int>();
        //    NumberList.AddRange(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
        //    int totalNumber = 0;
        //    foreach (var item in NumberList)
        //    {
        //        totalNumber += item;
        //        if (item == 2)
        //        {
        //            NumberList.RemoveRange(0, item);
        //        }
        //    }

        //    return Ok(totalNumber);
        //}


        private bool TesislerExists(int key)
        {
            return db.Tesisler.Count(e => e.Id == key) > 0;
        }
    }
}
