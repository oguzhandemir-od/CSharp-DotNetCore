using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMUygulamasi
{
    internal class Loglar
    {
        private string _logTuru;
        private string _zaman;
        private string _musteriNumarasi;
        private string _musteri;
        private string _islemTuru;

        public string LogTuru { get => _logTuru; set => _logTuru = value; }
        public string Zaman { get => _zaman; set => _zaman = value; }
        public string MusteriNumarasi { get => _musteriNumarasi; set => _musteriNumarasi = value; }
        public string Musteri { get => _musteri; set => _musteri = value; }
        public string IslemTuru { get => _islemTuru; set => _islemTuru = value; }

        #region Log İşlemleri
        //public void IslemiYaz(Musteri mst,string zaman,string secim)
        //{
        //    string tarih = DateTime.Now.Date.ToString("d");
        //    string yol = @$"C:\Users\oğuzhan\source\repos\oguzdemir95\patikadev\CS_Projeleri\ATMUygulamasi\GunSonu_{tarih}.txt";
        //    StreamWriter yaz = new StreamWriter(yol,true);
        //    yaz.WriteLine("------------");
        //    yaz.WriteLine("HESAP GİRİŞİ");
        //    yaz.WriteLine($"Saat: {zaman}");
        //    yaz.WriteLine($"Müşteri Numarası: {mst.MusteriNumarasi}");
        //    yaz.WriteLine($"Müşteri: {mst.MusteriAdi} {mst.MusteriSoyadi}");
        //    yaz.Write("İŞLEM: ");
        //    switch (secim)
        //    {
        //        case "1":
        //            yaz.WriteLine("Para Çekme");
        //            break;
        //        case "2":
        //            yaz.WriteLine("Para Yatırma");
        //            break;
        //            case "3":
        //            yaz.WriteLine("Para Gönderme");
        //            break;
        //        case "4":
        //            yaz.WriteLine("Borç Ödeme");
        //            break;
        //        default:
        //            break;
        //    }
        //    yaz.WriteLine();
        //    yaz.Close();
        //}
        //public void HatalıSifreYaz(List<Musteri> musteriler,string musterino, string zaman)
        //{
        //    string tarih = DateTime.Now.Date.ToString("d");
        //    string yol = @$"C:\Users\oğuzhan\source\repos\oguzdemir95\patikadev\CS_Projeleri\ATMUygulamasi\GunSonu_{tarih}.txt";
        //    StreamWriter yaz = new StreamWriter(yol, true);
        //    yaz.WriteLine("------------");
        //    yaz.WriteLine("HATALI GİRİŞ");
        //    yaz.WriteLine($"Saat: {zaman}");
        //    yaz.WriteLine($"Müşteri Numarası: {Musteri.MusteriBul(musteriler,musterino).MusteriNumarasi}");
        //    yaz.WriteLine($"Müşteri: {Musteri.MusteriBul(musteriler, musterino).MusteriAdi} " +
        //        $"{Musteri.MusteriBul(musteriler, musterino).MusteriSoyadi}");
        //    yaz.WriteLine("Hatalı Şifre");
        //    yaz.WriteLine();
        //    yaz.Close();
        //}
        //public void MusteriBulunamadiYaz(string musterino,string zaman)
        //{
        //    string tarih = DateTime.Now.Date.ToString("d");
        //    string yol = @$"C:\Users\oğuzhan\source\repos\oguzdemir95\patikadev\CS_Projeleri\ATMUygulamasi\GunSonu_{tarih}.txt";
        //    StreamWriter yaz = new StreamWriter(yol, true);
        //    yaz.WriteLine("-------------------");
        //    yaz.WriteLine("BULUNAMAYAN MÜŞTERİ");
        //    yaz.WriteLine($"Saat: {zaman}");
        //    yaz.WriteLine($"Girilen Müşteri Numarası: {musterino}");
        //    yaz.WriteLine();
        //    yaz.Close();
        //}
        #endregion

        public static void LogYazdir(List<Loglar> loglar)
        {
            string tarih = DateTime.Now.Date.ToString("d");
            string yol = @$"C:\Users\oğuzhan\source\repos\oguzdemir95\patikadev\CS_Projeleri\ATMUygulamasi\GunSonu_{tarih}.txt";
            StreamWriter yaz = new StreamWriter(yol, true);
            foreach (var l in loglar)
            {
                yaz.WriteLine("------------");
                yaz.WriteLine(l.LogTuru);
                yaz.WriteLine(l.Zaman);
                yaz.WriteLine(l.MusteriNumarasi);
                yaz.WriteLine(l.Musteri);
                yaz.WriteLine(l.IslemTuru);
                yaz.WriteLine();
            }
            yaz.Close();
            Console.Write($"İşlem kayıtları bilgisayarınız üzerine kaydedilmiştir. Kayıt yeri: {yol}");
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
