using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceSellSystems.Entity.Models
{
   public class UrunKategori
    {
        public int UrunKategoriID { get; set; }
        public string UrunKategoriAdı { get; set; }
        public bool Silindimi { get; set; }
        public int KategoriID { get; set; }
    }
}
