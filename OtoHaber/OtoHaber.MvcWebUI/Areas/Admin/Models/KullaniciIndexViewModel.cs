using OtoHaber.Entities.Domains;
using OtoHaber.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OtoHaber.MvcWebUI.Areas.Admin.Models
{
    public class KullaniciIndexViewModel
    {
        public KullaniciIndexViewModel()
        {
            Kullanicilar = new List<KullaniciDetayDto>();
        }
        public List<KullaniciDetayDto> Kullanicilar { get; set; }
    }
}