using OtoHaber.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OtoHaber.MvcWebUI.Areas.Admin.Models
{
    public class KategoriIndexViewModel
    {
        public KategoriIndexViewModel()
        {
            Kategoriler = new List<Kategori>();
        }
        public List<Kategori> Kategoriler { get; set; }
    }
}