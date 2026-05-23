using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Modelleme
{
    public class ARAC02
    {
        public static void AnaKod()
        {
            List<Arac> filo = new List<Arac>();

            filo.Add(new Arac
            {
                Marka = "Skoda",
                Model = "Octavia",
                Renk = Renk.Beyaz.ToString(),
                Yil = 2018,
                Motor = Motor.Dizel.ToString(),
                Hacim = 1.6
            });

            filo.Add(new Arac
            {
                Marka = "Opel",
                Model = "Corsa",
                Renk = Renk.Beyaz.ToString(),
                Yil = 2014,
                Motor = Motor.Benzin.ToString(),
                Hacim = 1.4
            });

            filo.Add(new Arac
            {
                Marka = "Renault",
                Model = "Fluence",
                Renk = Renk.Siyah.ToString(),
                Yil = 2017,
                Motor = Motor.Dizel.ToString(),
                Hacim = 1.6
            });

            filo.RemoveAt(1);

            foreach (Arac item in filo)
            {
                item.ToString();
            }
        }
    }
}
