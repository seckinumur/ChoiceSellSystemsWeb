using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceSellSystems.Entity.Models
{
   public class Kullanici
    {
        public int KullaniciID { get; set; }
        public string Adi { get; set; }
        public string Sifre { get; set; }
        public bool Master { get; set; }
    }
}
