using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNG
{
    public static class FOR02
    {
        public static void AnaKod()
        {
            int tekToplam = 0, ciftToplam = 0;
            Console.WriteLine("Limit giriniz: ");
            int limit = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Tek sayılar");
            for (int i = 1; i <= limit; i += 2)
            {
                Console.Write("{0,5}", i);
                tekToplam += i;
            }

            Console.WriteLine("\n\nÇift sayılar");
            for (int i = 2; i <= limit; i += 2)
            {
                Console.Write("{0,5}", i);
                ciftToplam += i;
            }

            Console.WriteLine("\n\nTek Toplam: {0,5} \n Çift Toplam: {1,5}", tekToplam, ciftToplam);
        }
    }
}
