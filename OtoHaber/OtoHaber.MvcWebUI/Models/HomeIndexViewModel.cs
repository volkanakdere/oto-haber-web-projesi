using OtoHaber.Entities.Domains;
using OtoHaber.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OtoHaber.MvcWebUI.Models
{
    public class HomeIndexViewModel
    {
        public HomeIndexViewModel()
        {
            HaberDetayDtos = new List<HaberDetayDto>();
            Kategoriler = new List<Kategori>();
        }
        public List<HaberDetayDto> HaberDetayDtos { get; set; }
        public List<Kategori> Kategoriler { get; set; }
    }
}