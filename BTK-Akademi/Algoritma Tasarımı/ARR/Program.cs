using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARR
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("n değerini giriniz: ");
            int n = Convert.ToInt32(Console.ReadLine());

            int[] x = new Dizi().Olustur(n);

            Dizi dizi = new Dizi();

            int[] tekSayilarDizisi = dizi.TekDiziOlustur(x);
            Dizi.Yazdir(tekSayilarDizisi);
            Console.WriteLine("Tek sayıların sayısı: {0,5}", dizi.TekSayilarinSayisi(x));

            int[] ciftSayilarDizisi = dizi.CiftDiziOlustur(x);
            Dizi.Yazdir(ciftSayilarDizisi);
            Console.WriteLine("Çift sayıların sayısı: {0,5}", dizi.CiftSayilarinSayisi(x));

            //Console.WriteLine("Dizinin aritmetik ortalaması: {0:F2}", Dizi.AritmetikOrtalama(x));
            //Console.WriteLine("Dizinin standart sapması: {0:F2}", Dizi.StandartSapma(x));


            //Console.WriteLine("\n Dizinin en büyük elemanı: {0}", Dizi.EnBuyuk(sayilar));
            //Console.WriteLine("\n Dizinin en küçük elemanı: {0}", Dizi.EnKucuk(sayilar));
            Console.ReadKey();
        }
        

    }
}
