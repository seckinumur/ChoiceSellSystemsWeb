using ChoiceSellSystems.Entity.DBContext;
using ChoiceSellSystems.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceSellSysytems.DAL.Repository
{
   public class KategorizeEt
    {
        public static List<WMKategoriler> KatogorileriListele()
        {
            using (DataDb db = new DataDb())
            {
                var Kategorisec = db.Kategori.Select(p => new WMKategoriler { KategoriAdi = p.KategoriAdi, KategoriID= p.KategoriID }).ToList();
                return Kategorisec;
            }
        }
        public static List<WMKategoriler> KategorilerinHepsi()
        {
            using (DataDb db = new DataDb())
            {
                
                var Kategorisec = db.Kategori.Select(p =>  new WMKategoriler {  KategoriID = p.KategoriID, KategoriAdi=p.KategoriAdi,UrunVarmi=false }).ToList();
                foreach (var item in Kategorisec)
                {
                    bool varmiymis = db.Urun.Any(p => p.KategoriID == item.KategoriID );
                    item.UrunVarmi = varmiymis;
                }
                
                return Kategorisec;
            }
        }
        public static List<WMUrunKategorileri> UrunKategorilerinHepsi()
        {
            using (DataDb db = new DataDb())
            {

                var Kategorisec = db.UrunKategori.Select(p => new WMUrunKategorileri { UrunKategoriID = p.UrunKategoriID, UrunKategoriAdı = p.UrunKategoriAdı, UrunVarmi = false }).ToList();
                foreach (var item in Kategorisec)
                {
                    bool varmiymis = db.Urun.Any(p => p.UrunKategoriID == item.UrunKategoriID );
                    item.UrunVarmi = varmiymis;
                }

                return Kategorisec;
            }
        }
        public static List<WMUrunCinsleri> UrunCinslerininHepsi()
        {
            using (DataDb db = new DataDb())
            {

                var Kategorisec = db.Uruncinsi.Select(p => new WMUrunCinsleri { UrunCinsiID = p.UruncinsiID, Cinsi = p.Cinsi, UrunVarmi = false }).ToList();
                foreach (var item in Kategorisec)
                {
                    bool varmiymis = db.Urun.Any(p => p.UruncinsiID == item.UrunCinsiID );
                    item.UrunVarmi = varmiymis;
                }

                return Kategorisec;
            }
        }
        public static List<WMMArka> Markalar()
        {
            using (DataDb db = new DataDb())
            {
                var marrrr = db.Marka.Select(p => new WMMArka { MarkaID = p.MarkaID, MarkaAdi = p.MarkaAdi}).ToList();
                return marrrr;
            }
        }
    }
}
