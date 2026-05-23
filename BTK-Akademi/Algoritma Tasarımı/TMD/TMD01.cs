using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMD
{
    public static class TMD01
    {
        public static void AnaKod()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            //if (Sayi.TekMi(n))
            //    Console.WriteLine("Girilen sayı = {0} tektir", n);

            if (Sayi.CiftMi(n))
                Console.WriteLine("Girilen sayı = {0} çifttir", n);
        }
    }
}
