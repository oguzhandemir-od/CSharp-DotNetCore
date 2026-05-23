using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFEL
{
    public static class SWTC01
    {
        public enum Renkler { Kirmizi, Yesil, Mavi }
        public static void AnaKod()
        {
            Renkler r = (Renkler)new Random().Next(0, 3);

            switch (r)
            {
                case Renkler.Kirmizi:
                    Console.WriteLine("Renk kırmızıdır");
                    break;
                case Renkler.Yesil:
                    Console.WriteLine("Renk yeşildir");
                    break;
                case Renkler.Mavi:
                    Console.WriteLine("Renk mavidir");
                    break;
                default:
                    Console.WriteLine("Renk bilinmiyor");
                    break;
            }
        }
    }
}
