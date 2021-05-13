using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoHaber.Entities.Domains
{
    public class HaberResim
    {
        public int Id { get; set; }
        public string ResimDosyaYolu { get; set; }
        public int HaberId { get; set; }
    }
}
