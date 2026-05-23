using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Modelleme
{
    public class Tasit
    {
        public string Motor { get; set; }
        public double Hacim { get; set; }

        public void Temizle() => Console.WriteLine("Taşıt temizlendi.");

    }

    public enum Motor
    {
        Dizel,Benzin,LPG,Elektrik,Jet
    }

    public enum Renk
    {
        Beyaz, Siyah, Gri, Kirmizi, Yesil, Mavi
    }
}
