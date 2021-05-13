using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoHaber.Entities.Domains
{
    public class Haber
    {
        public int Id { get; set; }
        public int KategoriId { get; set; }
        public string Baslik { get; set; }
        public string HaberOzeti { get; set; }
        public string Icerik { get; set; }
        public DateTime Tarih { get; set; }
        public int YazarId { get; set; }
        public int OkunmaSayisi { get; set; }

    }
}
