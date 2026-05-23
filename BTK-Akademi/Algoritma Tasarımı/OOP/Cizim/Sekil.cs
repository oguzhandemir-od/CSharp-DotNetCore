using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Cizim
{

    public sealed class Pozisyon
    {
        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString() => $"X: {X}, Y: {Y}";
        
    }
    public sealed class Boyut
    {
        public int Genislik { get; set; }
        public int Yukseklik { get; set; }

        public override string ToString()=> $"Genişlik: {Genislik}, Yükseklik: {Yukseklik}";
        
    }
    public abstract class Sekil
    {
        public Pozisyon Poz { get; set; } = new Pozisyon();
        public Boyut Boy { get; set; } = new Boyut();

        public Sekil()
        {
            Console.WriteLine("Base class -> Constructor");
        }
        public Sekil(int genislik,int yukseklik,int x,int y)
        {
            Boy = new Boyut { Genislik = genislik, Yukseklik = yukseklik };
            Poz = new Pozisyon { X = x, Y = y };
        }
        public virtual void Ciz() => Console.WriteLine($"Şekil {Poz} - {Boy}");

        public virtual void Tasi(Pozisyon yeniPozisyon)
        {
            Poz.X = yeniPozisyon.X;
            Poz.Y = yeniPozisyon.Y;
            Console.WriteLine($"Taşındı: {Poz}");
        }

        public abstract void YenidenBoyutlandir(int genislik, int yukseklik);
        
    }
}
