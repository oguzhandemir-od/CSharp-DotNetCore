using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNG
{
    public static class FOR03
    {
        public static void AnaKod()
        {
            int sayac = 0;
            for (int i = 1000; i >= 0; i -= 5)
            {
                Console.WriteLine("{0,5}", i);
                sayac++;
            }
            Console.WriteLine("\n\nEleman sayısı: {0}", sayac);
        }
    }
}
