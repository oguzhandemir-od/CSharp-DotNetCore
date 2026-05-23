using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fow44
{
    internal class Calismalar
    {
        public static void Calisma1()
        {
            bool kontrol = true;
            int sayi1, sayi2;
            while (kontrol)
            {
                Menu();
                int secim = int.Parse(Console.ReadLine());
                switch (secim)
                {
                    case 1:
                        Console.Write("Birinci sayıyı giriniz: ");
                        sayi1 = int.Parse(Console.ReadLine());
                        Console.Write("İkinci sayıyı giriniz: ");
                        sayi2 = int.Parse(Console.ReadLine());
                        Topla(sayi1, sayi2);
                        break;
                    case 2:
                        Console.Write("Birinci sayıyı giriniz: ");
                        sayi1 = int.Parse(Console.ReadLine());
                        Console.Write("İkinci sayıyı giriniz: ");
                        sayi2 = int.Parse(Console.ReadLine());
                        Console.WriteLine($"Sayıların farkı: {Cikar(sayi1, sayi2)}");
                        break;
                    case 3:
                        Console.Write("Birinci sayıyı giriniz: ");
                        sayi1 = int.Parse(Console.ReadLine());
                        Console.Write("İkinci sayıyı giriniz: ");
                        sayi2 = int.Parse(Console.ReadLine());
                        Console.WriteLine($"Sayıların çarpımı: {Carp(sayi1, sayi2)}");
                        break;
                    case 4:
                        Console.Write("Birinci sayıyı giriniz: ");
                        sayi1 = int.Parse(Console.ReadLine());
                        Console.Write("İkinci sayıyı giriniz: ");
                        sayi2 = int.Parse(Console.ReadLine());
                        Console.WriteLine($"Sayıların bölümü: {Bol((double)sayi1, (double)sayi2):F2}");
                        break;
                    default:
                        Console.WriteLine("Geçersiz giriş!");
                        break;
                }
                Console.WriteLine();
            }
        }
        public static void Calisma2()
        {
            List<string> liste = new List<string>();
            bool kontrol = true;
            string ifade;
            while (kontrol)
            {
                ListeMenu();
                int secim = int.Parse(Console.ReadLine());
                switch (secim)
                {
                    case 1:
                        Console.Write("Eklemek istediğiniz ifade: ");
                        ifade = Console.ReadLine();
                        ElemanEkle(liste, ifade);
                        break;
                    case 2:
                        Console.Write("Çıkarmak istediğiniz ifade: ");
                        ifade = Console.ReadLine();
                        ElemanCikar(liste, ifade);
                        break;
                    case 3:
                        Console.WriteLine();
                        Console.WriteLine("Elemanlar");
                        ElemanlariListele(liste);
                        break;
                    default:
                        Console.WriteLine("Geçersiz giriş!");
                        break;
                }
                Console.WriteLine();
            }
        }

        static void Topla(int sayi1, int sayi2)
        {
            double toplam = sayi1 + sayi2;
            Console.WriteLine($"Sayıların Toplamı: {toplam}");
        }

        static int Cikar(int sayi1, int sayi2)
        {
            return sayi1 - sayi2;
        }

        static string Carp(double sayi1, double sayi2)
        {
            double carpim = sayi1 * sayi2;
            return carpim.ToString();
        }

        static double Bol(double sayi1, double sayi2)
        {
            return sayi1 / sayi2;


        }
        static void Menu()
        {
            Console.WriteLine("İşlemler");
            Console.WriteLine("1-Toplama");
            Console.WriteLine("2-Çıkarma");
            Console.WriteLine("3-Çarpma");
            Console.WriteLine("4-Bölme");
            Console.Write("Seçim: ");
        }

        static void ElemanEkle(List<string> liste, string ifade)
        {
            liste.Add(ifade);
        }

        static void ElemanCikar(List<string> liste, string ifade)
        {
            liste.Remove(ifade);
        }
        static void ElemanlariListele(List<string> liste)
        {
            foreach (var s in liste)
            {
                Console.WriteLine(s);
            }
        }
        static void ListeMenu()
        {
            Console.WriteLine("Seçenekler");
            Console.WriteLine("1-Eleman Ekle");
            Console.WriteLine("2-Eleman Çıkar");
            Console.WriteLine("3-Elemanları Listele");
            Console.Write("Seçim: ");
        }
    }
}
