using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT_Proje
{
    public static class VARS03
    {
        public static void AnaKod()
        {
            // Kutulama - Boxing
            int i = 23;
            object o = i;
            // object o = (object)i; Explicit Boxing

            // Kutudan Çıkarma - Unboxing
            i *= 2; // i = i * 2
            i = (int)o; // Cast

            Console.WriteLine("Değer türü: {0}", i);
            Console.WriteLine("Referans türü: {0}", o);
        }
    }
}
