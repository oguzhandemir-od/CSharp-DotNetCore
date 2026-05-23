using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMUygulamasi
{
    public class Banka
    {
        #region Alanlar
        private string _bankaAdi;
        #endregion

        #region Kapsülleme
        public string BankaAdi { get => _bankaAdi; set => _bankaAdi = value; }
        #endregion

        #region Banka İşlemleri
        public void ParaCek(Musteri musteri)
        {
            Console.WriteLine();
            Console.WriteLine("PARA ÇEKME");
            Console.WriteLine("----------");

            Console.Write($"Mevcut bakiyeniz: {musteri.Bakiye}");
            Console.WriteLine();
            Console.Write("Çekmek istediğiniz miktar: ");
            double cekilen = double.Parse(Console.ReadLine());
            if (cekilen <= musteri.Bakiye)
            {
                musteri.Bakiye -= cekilen;
                Console.WriteLine();
                Console.WriteLine($"Çekilen miktar: {cekilen}");
                Console.WriteLine($"Bakiyeniz: {musteri.Bakiye}");
                Console.WriteLine("İşlem tamamlandı.");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Bakiyeniz yetersiz.");
            }
            
        }
        public void ParaYatir(Musteri musteri)
        {
            Console.WriteLine();
            Console.WriteLine("PARA YATIRMA");
            Console.WriteLine("------------");
            Console.Write($"Mevcut bakiyeniz: {musteri.Bakiye}");
            Console.WriteLine();
            Console.Write("Yatırmak istediğiniz miktar: ");
            double yatirilan = double.Parse(Console.ReadLine());
            musteri.Bakiye += yatirilan;
            Console.WriteLine();
            Console.WriteLine($"Yatırılan miktar: {yatirilan}");
            Console.WriteLine($"Bakiyeniz: {musteri.Bakiye}");
            Console.WriteLine("İşlem tamamlandı.");
            Console.WriteLine();
        }
        public void ParaGonder(List<Musteri> musteriler, Musteri musteri)
        {
            Console.WriteLine();
            Console.WriteLine("PARA GÖNDERME");
            Console.WriteLine("-------------");
            Console.Write($"Mevcut bakiyeniz: {musteri.Bakiye}");
            Console.WriteLine();
            Console.Write("Alıcı müşteri numarası giriniz: ");
            string aliciNo = Console.ReadLine();
            if (Musteri.MusteriVarMi(musteriler, aliciNo))
            {
                Musteri alici = Musteri.MusteriBul(musteriler, aliciNo);
                Console.WriteLine($"Alıcı müşteri numarası: {alici.MusteriNumarasi} Alıcı: {alici.MusteriAdi} {alici.MusteriSoyadi}");
                Console.Write("Göndermek istediğiniz miktar: ");
                double gonderilen = double.Parse(Console.ReadLine());
                if (gonderilen <= musteri.Bakiye)
                {
                    musteri.Bakiye -= gonderilen;
                    alici.Bakiye += gonderilen;
                    Console.WriteLine();
                    Console.WriteLine($"Gönderilen miktar: {gonderilen}");
                    Console.WriteLine($"Bakiyeniz: {musteri.Bakiye}");
                }
                else
                {
                    Console.WriteLine("Bakiyeniz yetersiz.");
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Alıcı bulunamadı.");
            }


        }
        public void OdemeYap(Musteri musteri)
        {
            Console.WriteLine("KREDİ KARTI BORÇ ÖDEMESİ");
            Console.WriteLine("------------------------");
            Console.Write($"Mevcut bakiyeniz: {musteri.Bakiye}");
            Console.WriteLine();
            Console.Write("Ödemek istediğiniz miktar: ");
            double odenen = double.Parse(Console.ReadLine());
            if (odenen <= musteri.Bakiye)
            {
                musteri.Bakiye -= odenen;
                Console.WriteLine();
                Console.WriteLine($"Ödenen miktar: {odenen}");
                Console.WriteLine($"Bakiyeniz: {musteri.Bakiye}");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Bakiyeniz yetersiz.");
            }
        }
        #endregion
    }
}
