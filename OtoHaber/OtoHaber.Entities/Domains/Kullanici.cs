using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoHaber.Entities.Domains
{
    public class Kullanici
    {
        public int Id{ get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Eposta { get; set; }
        public string Sifre { get; set; }
        public int RolId { get; set; }
    }
}
