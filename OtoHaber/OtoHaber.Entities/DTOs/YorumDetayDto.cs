using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoHaber.Entities.DTOs
{
    public class YorumDetayDto
    {
        public int Id { get; set; }
        public int KullaniciId { get; set; }
        public string KullaniciAdSoyad { get; set; }
        public string YorumMetni { get; set; }
        public bool OnaylandiMi { get; set; }
        public DateTime YorumTarihi { get; set; }
    }
}
