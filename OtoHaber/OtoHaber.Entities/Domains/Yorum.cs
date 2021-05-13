using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoHaber.Entities.Domains
{
    public class Yorum
    {
        public int Id { get; set; }
        public int HaberId { get; set; }
        public int KullaniciId { get; set; }
        public string YorumMetni { get; set; }
        public bool OnaylandiMi { get; set; }
        public DateTime YorumTarihi { get; set; }
    }
}
