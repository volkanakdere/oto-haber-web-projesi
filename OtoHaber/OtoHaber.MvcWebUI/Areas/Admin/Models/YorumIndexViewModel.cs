using OtoHaber.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OtoHaber.MvcWebUI.Areas.Admin.Models
{
    public class YorumIndexViewModel
    {
        public YorumIndexViewModel()
        {
            YorumDetayDtoList = new List<YorumDetayDto>();
        }
        public List<YorumDetayDto> YorumDetayDtoList { get; set; }
    }
}