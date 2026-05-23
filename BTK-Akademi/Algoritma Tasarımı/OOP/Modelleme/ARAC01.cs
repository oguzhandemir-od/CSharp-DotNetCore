using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Modelleme
{
    public class ARAC01
    {
        public static void AnaKod()
        {
            Arac benimAracim = new Arac
            {

                Marka = "Skoda",
                Model = "SuperB",
                Yil = 2020,
                Motor = Motor.Benzin.ToString(),
                Hacim = 1.6,
                Renk = Renk.Gri.ToString()
            };

            Arac seninAracin = new Arac
            {
                Marka = "Skoda",
                Model = "Octavia",
                Renk = Renk.Beyaz.ToString(),
                Yil = 2019,
                Motor = Motor.Benzin.ToString(),
                Hacim = 1.5
            };


            benimAracim.ToString();
            seninAracin.ToString();

            benimAracim.Temizle();
        }
    }
}
