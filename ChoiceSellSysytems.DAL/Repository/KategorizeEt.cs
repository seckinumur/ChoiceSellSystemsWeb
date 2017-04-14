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
                var Kategorisec = db.Kategori.Select(p => new WMKategoriler { KategoriAdi = p.KategoriAdi }).ToList();
                return Kategorisec;
            }
        }
    }
}
