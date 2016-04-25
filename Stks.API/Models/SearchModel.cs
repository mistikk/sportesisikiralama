using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJSAuthentication.API.Models
{
    public class SearchModel
    {
        public string sporTuru { get; set; }
        public string il { get; set; }
        public string ilce { get; set; }
        public DateTime tarih1 { get; set; }
        public DateTime tarih2 { get; set; }
        public int saat1 { get; set; }
        public int saat2 { get; set; }
        public bool servis { get; set; }
    }
}