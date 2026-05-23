using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT_Proje
{
    public class VARS04
    {
        public static void AnaKod()
        {
            // static ve const beraber kullanılamaz
            // static const int c = 45;

            // Sabitler, sabitlere katılabilir
            // int sayi = 5;
            // const int c1 = 3 + 5;

            // Sabitlere oluşturulduğu yerde değeri verilmelidir
            //const int c2;
            //c2 = 5;
        }

        readonly int c3;
        public VARS04()
        {
            c3 = 3;
        }
    }
}
