using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceSellSystems.Entity.Models
{
   public class CompanyInfo
    {
        public int CompanyInfoID { get; set; }
        public bool Silindimi { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public string MobilTelefon { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Whatsapp { get; set; }
        public string Instagrm { get; set; }
    }
}
