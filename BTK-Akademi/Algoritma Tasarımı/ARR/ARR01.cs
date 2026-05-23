using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARR
{
    public static class ARR01
    {
        public static void AnaKod()
        {
            int[] dizi = new int[5];

            int n = dizi.Length;

            for (int i = 0; i < n; i++)
            {
                dizi[i] = new Random().Next(0, 100);
                Console.WriteLine(dizi[i]);
            }
        }
    }
}
