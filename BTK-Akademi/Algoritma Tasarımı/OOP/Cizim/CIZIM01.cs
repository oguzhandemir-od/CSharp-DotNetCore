using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Cizim
{
    public class CIZIM01
    {
        public static void AnaKod()
        {
            var r = new Dikdortgen();
            r.Poz.X = 23;
            r.Poz.Y = 43;
            r.Boy.Genislik = 100;
            r.Boy.Yukseklik = 50;
            SekilCiz(r);

            //var r = new Elips();
            //r.Poz.X = 55;
            //r.Poz.Y = 25;
            //r.Boy.Genislik = 200;
            //r.Boy.Yukseklik = 100;
            //SekilCiz(r);
            //r.Tasi(new Pozisyon { X = 20, Y = 30 });
            //SekilCiz(r);

            //Sekil s1 = new Dikdortgen();
            //s1.Poz.X = 50;
            //s1.Poz.Y = 50;
            //s1.Boy.Genislik = 100;
            //s1.Boy.Yukseklik = 50;
            //SekilCiz(s1);
        }

        private static void SekilCiz(Dikdortgen r)
        {
            throw new NotImplementedException();
        }
    }
}
