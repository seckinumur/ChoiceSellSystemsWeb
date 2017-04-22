using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceSellSystems.Entity.ViewModels
{
   public class KullaniciIslemleri
    {
        public int KullaniciID { get; set; }
        public string Gorev { get; set; }
        public string KatAdi { get; set; }
        public string KatSifre { get; set; }

        //ompany repo

        public string Adres { get; set; }
        public string Telefon { get; set; }
        public string MobilTelefon { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Whatsapp { get; set; }
        public string Instagram { get; set; }
    }
}
