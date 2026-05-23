using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMD
{
    public static class TMD10
    {
        public static void AnaKod()
        {
            double r = Convert.ToDouble(Console.ReadLine());
            //double aci = Convert.ToDouble(Console.ReadLine());
            //Console.WriteLine("Alan = {0:F2}", Daire.AlaniHesapla(r));
            Console.WriteLine("Alan = {0:F2}", Daire.AlaniHesapla(r, 60));
        }
    }
}
