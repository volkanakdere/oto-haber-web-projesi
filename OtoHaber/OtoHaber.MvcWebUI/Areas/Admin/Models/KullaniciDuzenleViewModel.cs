using OtoHaber.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OtoHaber.MvcWebUI.Areas.Admin.Models
{
    public class KullaniciDuzenleViewModel
    {
        public KullaniciDuzenleViewModel()
        {
            Roller = new List<SelectListItem>();
        }
        public Kullanici Kullanici { get; set; }
        public List<SelectListItem> Roller { get; set; }
    }
}