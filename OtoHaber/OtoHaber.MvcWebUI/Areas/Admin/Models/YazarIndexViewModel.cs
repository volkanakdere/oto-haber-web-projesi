using OtoHaber.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OtoHaber.MvcWebUI.Areas.Admin.Models
{
    public class YazarIndexViewModel
    {
        public YazarIndexViewModel()
        {
            Yazarlar = new List<Yazar>();
        }
        public List<Yazar> Yazarlar { get; set; }
    }
}