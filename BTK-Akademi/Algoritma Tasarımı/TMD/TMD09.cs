using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMD
{
    public static class TMD09
    {
        public static void AnaKod()
        {
            double r = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("2 * {0:F2} * {1:F2} = {2:F2}", Cember.pi, r, Cember.Cevre(r));
        }
    }
}
