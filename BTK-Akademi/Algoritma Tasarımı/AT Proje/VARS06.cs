using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT_Proje
{
    public static class VARS06
    {
        public static void AnaKod()
        {
            var x = 45; // Implicitly typed
            int y = 45; // Explicitly typed

            string[] meyveler = { "Elma", "Armut", "Muz", "Üzüm", "Şeftali" };
            var meyve = from m in meyveler
                        where m[0] == 'A'
                        select m;

            foreach (string m in meyve)
                Console.Write(m);
        }
    }
}
