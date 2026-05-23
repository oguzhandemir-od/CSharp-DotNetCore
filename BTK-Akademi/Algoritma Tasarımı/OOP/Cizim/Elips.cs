using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Cizim
{
    public class Elips:Sekil
    {
        public override void Tasi(Pozisyon yeniPozisyon)
        {
            Console.Write("Elips ");
            base.Tasi(yeniPozisyon);
        }

        public override void YenidenBoyutlandir(int genislik, int yukseklik)
        {
            Boy.Genislik = genislik;
            Boy.Yukseklik = yukseklik;
        }
    }
}
