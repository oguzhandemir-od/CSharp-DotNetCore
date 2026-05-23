using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanHesaplama
{
    internal class Kontrol
    {
        public static bool PozitifKontrol(double deger)
        {
            if (!(deger > 0))
            {
                Console.WriteLine("Girilen değerler pozitif olmalıdır.");
                return false;
            }
            return true;
        }
        public static bool SayiMiKontrol(string giris)
        {
            if (!double.TryParse(giris, out double sayi))
            {
                Console.WriteLine("Hatalı giriş. Lütfen tekrar deneyin.");
                return false;
            }
            else
                return true;

        }
    }
}
