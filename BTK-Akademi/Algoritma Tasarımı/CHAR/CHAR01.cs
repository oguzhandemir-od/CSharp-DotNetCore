using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHAR
{
    public static class CHAR01
    {
        public static void AnaKod()
        {
            for (int i = 32; i <= 300; i++)
            {
                Console.Write("{0,5}", (char)i);
                if (i % 5 == 0)
                    Console.WriteLine("");
            }
        }
    }
}
