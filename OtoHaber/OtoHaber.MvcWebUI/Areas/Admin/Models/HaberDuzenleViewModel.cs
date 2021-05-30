using OtoHaber.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OtoHaber.MvcWebUI.Areas.Admin.Models
{
    public class HaberDuzenleViewModel
    {
        public HaberDuzenleViewModel()
        {
            Kategoriler = new List<SelectListItem>();
            Yazarlar = new List<SelectListItem>();
        }
        public Haber Haber { get; set; }
        public HaberResim HaberResim { get; set; }

        [AllowHtml]
        public string HaberIcerik { get; set; }
        public HttpPostedFileBase Resim { get; set; }
        public List<SelectListItem> Kategoriler { get; set; }
        public List<SelectListItem> Yazarlar { get; set; }
    }
}