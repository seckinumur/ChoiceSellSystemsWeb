using ChoiceSellSystems.Entity.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceSellSysytems.DAL.Repository
{
   public class AdminCheckRepo
    {
        public static bool Check()
        {
            using (DataDb db = new DataDb())
            {
                bool Sonuc = db.Kullanici.Any();
                return Sonuc;
            }
        }
    }
}
