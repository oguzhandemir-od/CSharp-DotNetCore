using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberi
{
    internal class Kontrol
    {
        #region Kontrol İşlevleri
        public static bool HepsiHarfMi(string veri)
        {
            foreach (char c in veri)
            {
                if (!char.IsLetter(c))
                    return false;
            }
            return true;
        }
        public static bool HepsiNumaraMi(string numara)
        {
            foreach (char c in numara)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }
        public static bool NumaraHane(string numara)
        {
            bool kontrol = true;
            if (numara.Length != 11)
            {
                kontrol = false;
            }
            return kontrol;
        }
        public static bool BulunamadiSecim()
        {
            bool kontrol = true;
            Console.WriteLine("İşlemi sonlandırmak için  : (1)");
            Console.WriteLine("Yeniden denemek için      : (2)");
            string s = Console.ReadLine();
            switch (s)
            {
                case "1":
                    return false;
                case "2":
                    return true;
                default:
                    Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
                    return BulunamadiSecim();
            }
            return kontrol;
        }
        public static bool YazimKontrol()
        {
            bool kontrol = true;
            Kisi kisi = Kisi.Basla();
            while (true)
            {
                if (!HepsiHarfMi(kisi.Isim))
                {
                    Console.WriteLine("İsim ve soyisim bilgileri yalnızca harflerden oluşmalıdır!");
                    kontrol = false;
                    return kontrol;
                }
                if (!HepsiHarfMi(kisi.Soyisim))
                {
                    Console.WriteLine("İsim ve soyisim bilgileri yalnızca harflerden oluşmalıdır!");
                    kontrol = false;
                    return kontrol;
                }
                if (!HepsiNumaraMi(kisi.Numara))
                {
                    Console.WriteLine("Telefon numarası yalnızca rakamlardan oluşmalıdır!");
                    kontrol = false;
                    return kontrol;
                }
                if (!NumaraHane(kisi.Numara))
                {
                    Console.WriteLine("Telefon numarasını kontrol ediniz!");
                    kontrol = false;
                    return kontrol;
                }
                return kontrol;
            }
        }
        public static bool AramaKontrol(string bilgi)
        {
            bool kontrol = true;
            while (true)
            {
                if (!HepsiHarfMi(bilgi))
                {
                    Console.WriteLine("İsim ve soyisim bilgileri yalnızca harflerden oluşmalıdır!");
                    kontrol=false;
                    return kontrol;
                }
                return kontrol;
            }
        }
        #endregion
    }
}
