using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceSellSystems.Entity.Models
{
   public class Urun
    {
        public int UrunID { get; set; }
        public string UrunAdi { get; set; }
        public string UrunFiyati { get; set; }
        public string Indirim { get; set; }
        public bool IndirimVarmi { get; set; }
        public string Gramaj { get; set; }
        public string UrunAciklama { get; set; }
        public string Yorum { get; set; }
        public bool Silindimi { get; set; }
        public string Image { get; set; }
        public int KategoriID { get; set; }
        public int UrunKategoriID { get; set; }
        public int UruncinsiID { get; set; }
        public int MarkaID { get; set; }

        public virtual Kategori Kategori { get; set; }
        public virtual UrunKategori UrunKategori { get; set; }
        public virtual Uruncinsi Uruncinsi { get; set; }
        public virtual Marka Marka { get; set; }
    }
}
