using ChoiceSellSystems.Entity.DBContext;
using ChoiceSellSystems.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceSellSysytems.DAL.Repository
{
   public class KullaniciRepo
    {
        public static int GirisID (WMKullanici Kullanici)
        {
            using (DataDb db = new DataDb())
            {
                int ID;
                try
                {
                    var Bul = db.Kullanici.Where(p => p.Adi == Kullanici.Adi && p.Sifre == Kullanici.Sifre && p.Silindimi == false).FirstOrDefault();
                    return ID = Bul.KullaniciID;
                }
                catch
                {
                    return 0;
                }
            }
        }
    }
}