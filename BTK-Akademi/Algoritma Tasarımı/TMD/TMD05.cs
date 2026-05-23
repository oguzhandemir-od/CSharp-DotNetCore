using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMD
{
    public static class TMD05
    {
        public static void AnaKod()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("1'den {0}'e kadar olan sayıların toplamı = {1,5}", n, Sayi.NKadarSayilarToplami(n));
            Console.WriteLine("1'den {0}'e kadar olan sayıların toplamı = {1,5}", n, Sayi.NKadarSayilarFormulToplami(n));
        }
    }
}
