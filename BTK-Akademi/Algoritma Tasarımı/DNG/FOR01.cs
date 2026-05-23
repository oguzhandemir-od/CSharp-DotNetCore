using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNG
{
    public static class FOR01
    {
        public static void AnaKod()
        {
            //for (int i = 1; i <= 100; i++)
            //{
            //    Console.WriteLine("{0} -> {1}", i, i * i);
            //}
            //for (int i = 5; i <= 100; i+=5)
            //{
            //    Console.WriteLine("{0,5} -> {1,5}", i, i * i);
            //}
            for (int i = 100; i > 0; i -= 5)
            {
                Console.WriteLine("{0,5} -> {1,5}", i, i * i);
            }
        }
    }
}
