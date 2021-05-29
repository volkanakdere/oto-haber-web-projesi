using OtoHaber.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OtoHaber.MvcWebUI.Areas.Admin.Models
{
    public class HaberIndexViewModel
    {
        public HaberIndexViewModel()
        {
            HaberDetayDtoList = new List<HaberDetayDto>();
        }
        public List<HaberDetayDto> HaberDetayDtoList { get; set; }
    }
}