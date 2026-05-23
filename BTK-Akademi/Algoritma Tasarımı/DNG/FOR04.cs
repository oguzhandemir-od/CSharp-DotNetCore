using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNG
{
    public static class FOR04
    {
        public static void AnaKod()
        {
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 0; j <= 10; j++)
                {
                    Console.WriteLine("{0,5} \t x {1,5} \t = {2,5}", i, j, i * j);
                }
                Console.WriteLine("\n\n ------------ \n\n");

            }
        }
    }
}
