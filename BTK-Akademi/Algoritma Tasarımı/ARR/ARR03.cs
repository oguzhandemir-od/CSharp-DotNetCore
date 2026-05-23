using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARR
{
    class ARR03
    {
        public static void AnaKod()
        {
            Console.Write("n değerini giriniz: ");
            int limit = Convert.ToInt32(Console.ReadLine());

            int[] sayilar = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                sayilar[i] = new Random().Next(1, 100);
                Console.Write("{0,5}", sayilar[i]);
            }

            Console.WriteLine("\n Dizinin en büyük elemanı: {0}", EnBuyuk(sayilar));
            Console.WriteLine("\n Dizinin en küçük elemanı: {0}", EnKucuk(sayilar));
        }
        public static int EnBuyuk(int[] dizi)
        {
            int eb = dizi[0];
            for (int i = 0; i < dizi.Length; i++)
            {
                if (dizi[i] > eb)
                    eb = dizi[i];
            }
            return eb;
        }

        public static int EnKucuk(int[] dizi)
        {
            int ek = dizi[0];
            for (int i = 0; i < dizi.Length; i++)
            {
                if (dizi[i] < ek)
                    ek = dizi[i];
            }
            return ek;
        }
    }
}
