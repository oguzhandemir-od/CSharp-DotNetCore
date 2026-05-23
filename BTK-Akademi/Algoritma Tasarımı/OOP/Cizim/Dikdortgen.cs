using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Cizim
{
    public class Dikdortgen:Sekil
    {
        public Dikdortgen()
        {
            Console.WriteLine("Derived class -> Constructor");
        }

        public Dikdortgen(int genislik, int yukseklik, int x, int y) : base(genislik, yukseklik, x, y)
        {
            Console.WriteLine("Derived class -> ctor - 4p");
        }

        public override void Ciz() => Console.WriteLine($"Dikdörtgen {Poz} - {Boy}");

        public override void Tasi(Pozisyon yeniPozisyon)
        {
            Console.Write("");
            Console.Write("Dikdörtgen ");
            base.Tasi(yeniPozisyon);
        }

        public override void YenidenBoyutlandir(int genislik, int yukseklik)
        {
            Boy.Genislik = genislik;
            Boy.Yukseklik = yukseklik;
        }

    }
}
