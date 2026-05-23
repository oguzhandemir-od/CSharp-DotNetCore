using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingUygulamasi
{
    internal class Kontrol
    {
        public static bool KullaniciVarMi(List<Kullanici> kullanicilar, string ad, string sifre)
        {
            bool kullaniciVarMi = kullanicilar.Any(k => k.KullaniciAdi == ad && k.KullaniciSifresi == sifre);
            return kullaniciVarMi;
        }
    }
}
