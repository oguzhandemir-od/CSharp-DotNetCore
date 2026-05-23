using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingUygulamasi
{
    internal class Islemler
    {
        
        public static void OylamaKategorileriYaz(Kategori film, Kategori dizi, Kategori kitap, Kategori tech, Kategori spor)
        {
            Console.WriteLine("Oylama Kategorileri");
            Console.WriteLine("*******************");
            Console.WriteLine($"(1) {film.KategoriAdi}");
            Console.WriteLine($"(2) {dizi.KategoriAdi}");
            Console.WriteLine($"(3) {kitap.KategoriAdi}");
            Console.WriteLine($"(4) {tech.KategoriAdi}");
            Console.WriteLine($"(5) {spor.KategoriAdi}");
        }
        public static void OySayisiYazdir(Kategori ktg)
        {
            Console.WriteLine($"{ktg.KategoriAdi} 'ne oy verdiniz.");
            Console.WriteLine($"{ktg.KategoriAdi} oy sayısı: {ktg.OySayisi}");
        }
        public static double OyYuzdesiHesapla(double yuzdeT, Kategori ktg)
        {
            double oyYuzdesi = ktg.OySayisi / yuzdeT * 100;
            return oyYuzdesi;
        }
        public static void OyYuzdesiYazdir(double yuzdeToplam, Kategori film, Kategori dizi, Kategori kitap, Kategori tech, Kategori spor)
        {
            film.OyYuzdesi = OyYuzdesiHesapla(yuzdeToplam, film);
            dizi.OyYuzdesi = OyYuzdesiHesapla(yuzdeToplam, dizi);
            kitap.OyYuzdesi = OyYuzdesiHesapla(yuzdeToplam, kitap);
            tech.OyYuzdesi = OyYuzdesiHesapla(yuzdeToplam, tech);
            spor.OyYuzdesi = OyYuzdesiHesapla(yuzdeToplam, spor);
            Console.WriteLine("Oy yüzdeleri");
            Console.WriteLine($"Film: %{film.OyYuzdesi:F3} Dizi: %{dizi.OyYuzdesi:F3} Kitap: %{kitap.OyYuzdesi:F3} Tech Stack: %{tech.OyYuzdesi:F3} Spor: %{spor.OyYuzdesi:F3}");

        }
        public static void SecimiUygula(double yuzdeToplam, Kategori film, Kategori dizi, Kategori kitap, Kategori tech, Kategori spor, Kullanici kullanici)
        {
            Console.Write("Seçim: ");
            string secim = Console.ReadLine();
            switch (secim)
            {
                case "1":
                    film.OySayisi++;
                    yuzdeToplam++;
                    kullanici.VerdigiOy = 1;
                    kullanici.OyVerdiMi = true;
                    OySayisiYazdir(film);
                    OyYuzdesiYazdir(yuzdeToplam, film, dizi, kitap, tech, spor);


                    break;
                case "2":
                    dizi.OySayisi++;
                    yuzdeToplam++;
                    kullanici.VerdigiOy = 2;
                    kullanici.OyVerdiMi = true;

                    OySayisiYazdir(dizi);
                    OyYuzdesiYazdir(yuzdeToplam, film, dizi, kitap, tech, spor);

                    break;
                case "3":
                    kitap.OySayisi++;
                    yuzdeToplam++;
                    kullanici.VerdigiOy = 3;
                    kullanici.OyVerdiMi = true;

                    OySayisiYazdir(kitap);
                    OyYuzdesiYazdir(yuzdeToplam, film, dizi, kitap, tech, spor);

                    break;
                case "4":
                    tech.OySayisi++;
                    yuzdeToplam++;
                    kullanici.VerdigiOy = 4;
                    kullanici.OyVerdiMi = true;

                    OySayisiYazdir(tech);
                    OyYuzdesiYazdir(yuzdeToplam, film, dizi, kitap, tech, spor);

                    break;
                case "5":
                    spor.OySayisi++;
                    yuzdeToplam++;
                    kullanici.VerdigiOy = 5;
                    kullanici.OyVerdiMi = true;

                    OySayisiYazdir(spor);
                    OyYuzdesiYazdir(yuzdeToplam, film, dizi, kitap, tech, spor);

                    break;
                default:
                    break;
            }
        }
        public static void GeriSayim()
        {
            Console.WriteLine("Oylama ekranına geçiliyor...");
            for (int i = 3; i >= 1; i--)
            {
                Console.WriteLine($"{i}...");
                Thread.Sleep(1000);
            }
            Console.Clear();
        }
    }
}
