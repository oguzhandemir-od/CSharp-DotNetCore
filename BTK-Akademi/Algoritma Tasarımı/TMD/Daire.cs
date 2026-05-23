using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMD
{
    public static class Daire
    {
        public const double pi= 3.14;
        /// <summary>
        /// Dairenin alanını hesaplar.
        /// </summary>
        /// <param name="r">Yarıçap</param>
        /// <returns>Alan değeridir.</returns>
        public static double AlaniHesapla(double r)
        {
            return pi * r * r;
        }

        /// <summary>
        /// Dairenin alının hesaplar.
        /// </summary>
        /// <param name="r">Yarıçap</param>
        /// <param name="aci">Gördüğü açı</param>
        /// <returns>Alan değeridir.</returns>
        public static double AlaniHesapla(double r,double aci)
        {
            return pi * r * r * aci / 360;
        }
    }
}
