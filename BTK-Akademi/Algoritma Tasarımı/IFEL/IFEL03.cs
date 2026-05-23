using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFEL
{
    public static class IFEL03
    {
        /// <summary>
        /// If Else bloklarının And ve Or yapısıyla kullanımı
        /// </summary>
        public static void AnaKod()
        {
            int m = 9;
            int n = 7;
            int p = 5;

            if (m >= n && m >= p)
            {
                Console.WriteLine("En büyük değer m'dir");
            }

            if (m > n && !(p > m))
            {
                Console.WriteLine("En büyük değer m'dir");

            }

            if (m > n || m > p)
            {
                Console.WriteLine("m en küçük değer değildir");
            }

            m = 4;
            if (!(m >= n) || m >= p)
            {
                Console.WriteLine("m artık en küçük değerdir");
            }
        }
    }
}
