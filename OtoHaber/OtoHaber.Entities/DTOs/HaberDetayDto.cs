using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoHaber.Entities.DTOs
{
    public class HaberDetayDto
    {
        public int Id { get; set; }
        public int KategoriId { get; set; }
        public string Baslik { get; set; }
        public string HaberOzeti { get; set; }
        public DateTime Tarih { get; set; }
        public string YazarAdSoyad { get; set; }
        public string HaberResmi { get; set; }
        public int OkunmaSayisi { get; set; }
    }
}
