using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceSellSystems.Entity.Models
{
   public class Slider
    {
        public int SliderID { get; set; }
        public bool Aktifmi { get; set; }
        public int  UrunID { get; set; }

        public virtual Urun Urun { get; set; }
    }
}
