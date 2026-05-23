using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrtalamaHesaplama
{
    internal class Islemler
    {
        public static void SeriYazdir(int[] seri)
        {
            for (int i = 0; i < seri.Length; i++)
            {
                Console.Write(seri[i] + " ");
            }
        }
       
        public static bool DerinlikKontrol(int derinlik)
        {
            while(true)
            {
                if(derinlik<2)
                {
                    Console.WriteLine("Derinlik 2 veya daha büyük olmalıdır!");
                    return false;
                }
                return true;
            }
        }
    }
}
