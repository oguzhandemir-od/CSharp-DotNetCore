using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMUygulamasi
{
    public class Musteri
    {
        #region Alanlar
        private string _musteriNumarasi;
        private string _musteriSifresi;
        private string _musteriAdi;
        private string _musteriSoyadi;
        private double _bakiye;
        #endregion

        #region Kapsülleme
        public string MusteriNumarasi { get => _musteriNumarasi; set => _musteriNumarasi = value; }
        public string MusteriSifresi { get => _musteriSifresi; set => _musteriSifresi = value; }
        
        public string MusteriAdi { get => _musteriAdi; set => _musteriAdi = value; }
        public string MusteriSoyadi { get => _musteriSoyadi; set => _musteriSoyadi = value; }
        public double Bakiye { get => _bakiye; set => _bakiye = value; }
        #endregion

        #region Müşteri Kontrolleri
        public static bool MusteriVarMi(List<Musteri> musteriler, string musterino)
        {
            bool kontrol = musteriler.Any(m => m.MusteriNumarasi == musterino);
            return kontrol;
        }
        public static bool MusteriVarMi(List<Musteri> musteriler, string musterino, string musterisifre)
        {
            bool kontrol = musteriler.Any(m => m.MusteriNumarasi == musterino && m.MusteriSifresi == musterisifre);
            return kontrol;
        }
        public static bool SifreGecerliMi(Musteri mst,string musterisifre)
        {
            if (mst.MusteriSifresi == musterisifre)
            {
                return true;
            }
            else
                return false;
        }
        public static Musteri MusteriBul(List<Musteri> musteriler,string musterino)
        {
            Musteri bul = musteriler.FirstOrDefault(m => m.MusteriNumarasi == musterino);
            return bul;
        }
        #endregion

        #region Giriş Kontrolleri
        public static bool MusteriNumarasiKontrol(string musterino)
        {
            if (!(int.TryParse(musterino, out int sayi)))
            {
                Console.WriteLine("Geçersiz karakter bulundu.");
                return true;
            }
            if (musterino.Length != 8)
            {
                Console.WriteLine("Müşteri numarası 8 haneli olmalıdır.");
                return true;
            }
            else
                return false;
        }
        public static bool MusteriSifresiKontrol(string musterisifre)
        {
            if (!(int.TryParse(musterisifre, out int sayi)))
            {
                Console.WriteLine("Şifrede geçersiz karakter bulundu.");
                return true;
            }
            if (musterisifre.Length != 6)
            {
                Console.WriteLine("Müşteri şifresi 6 haneli olmalıdır.");
                return true;
            }
            else
                return false;
        }
        #endregion
    }
}
