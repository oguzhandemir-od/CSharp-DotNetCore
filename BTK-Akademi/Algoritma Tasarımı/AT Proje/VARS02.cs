using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT_Proje
{
    public static class VARS02
    {
        public static void AnaKod()
        {
            int maks, min;
            maks = System.Int16.MaxValue;
            min = System.Int16.MinValue;

            int maks32 = System.Int32.MaxValue;
            int min32 = System.Int32.MinValue;

            byte minByte = System.Byte.MinValue;
            byte maksByte = System.Byte.MaxValue;

            int sayi = 23;
            sayi = sayi * 2;
            //Console.WriteLine(sayi);

            Console.WriteLine("Int16 Min: {0} \t Maks: {1}", min, maks);
            Console.WriteLine("Int32 Min: {0} \t Maks: {1}", min32, maks32);
            Console.WriteLine("Byte Min: {0} \t Maks: {1}", minByte, maksByte);
        }
    }
}
