using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHAR
{
    public static class Stringler
    {
        /// <summary>
        /// Desen oluşturucu.
        /// </summary>
        /// <param name="c">Karakter tanımı.</param>
        /// <param name="n">Tekrar sayısı.</param>
        public static void Desen1(char c='*',int n=5)
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("{0,10}", new string(c, i));
            }
        }

        /// <summary>
        /// Desen oluşturucu.
        /// </summary>
        /// <param name="c">Karakter</param>
        /// <param name="n">Döngü Sayısı</param>
        /// <returns></returns>
        public static void Desen2(char c='-',int n=4)
        {
            for (int i = n; i >=0; i--)
            {
                Console.WriteLine("{0}", new string(c, i));
            }
        }

        public static void KarakterSeti(int baslangicIndisi=65,int bitisIndisi=90,int satirKarakterSayisi=5)
        {
            for (int i = baslangicIndisi; i <= bitisIndisi; i++)
            {
                Console.Write("{0,5}", (char)i);
                if (i % satirKarakterSayisi == 0)
                    Console.WriteLine("");
            }
        }
    }
}
