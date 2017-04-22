using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceSellSystems.Entity.ViewModels
{
   public class WMUrun
    {
        public int UrunID { get; set; }
        public string UrunAdi { get; set; }
        public string UrunFiyati { get; set; }
        public string Indirim { get; set; }
        public bool IndirimVarmi { get; set; }
        public string Gramaj { get; set; }
        public string UrunAciklama { get; set; }
        public string Kategorisi { get; set; }
        public string UrunKategorisi { get; set; }
        public string UrunCinsi { get; set; }
        public string Image { get; set; }
        public string Yorum { get; set; }
        public string marka { get; set; }
    }
}