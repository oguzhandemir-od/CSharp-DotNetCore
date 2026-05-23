using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMD
{
    public static class TMD08
    {
        public static void AnaKod()
        {
            int t1 = Sayi.NKadarCiftSayilarFormulToplami(80);
            int t2 = Sayi.NKadarCiftSayilarToplami(48);
            Console.WriteLine("{0,5} - {1,5} = {2,5}", t1, t2, t1 - t2);
        }
    }
}
