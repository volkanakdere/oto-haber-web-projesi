using OtoHaber.Entities.Domains;
using OtoHaber.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OtoHaber.MvcWebUI.Models
{
    public class HaberDetayViewModel
    {
        public HaberDetayViewModel()
        {
            HaberYorumlar = new List<YorumDetayDto>();
        }
        public Haber Haber { get; set; }
        public HaberResim HaberResim { get; set; }
        public Yazar HaberYazar { get; set; }
        public List<YorumDetayDto> HaberYorumlar { get; set; }
    }
}