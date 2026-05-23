using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMD
{
    public static class TMD06
    {
        public static void AnaKod()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("{0}", Sayi.NKadarTekSayilarToplami(n));
            Console.WriteLine("{0}", Sayi.NKadarTekSayilarAlternatifToplami(n));
            Console.WriteLine("{0}", Sayi.NKadarTekSayilarFormulToplami(n));
        }
    }
}
