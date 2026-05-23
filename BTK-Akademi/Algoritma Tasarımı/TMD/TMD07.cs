using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMD
{
    public static class TMD07
    {
        public static void AnaKod()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("{0}", Sayi.NKadarCiftSayilarToplami(n));
            Console.WriteLine("{0}", Sayi.NKadarCiftSayilarAlternatifToplami(n));
            Console.WriteLine("{0}", Sayi.NKadarCiftSayilarFormulToplami(n));
        }
    }
}
