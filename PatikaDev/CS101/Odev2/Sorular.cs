using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev2
{
    internal class Sorular
    {
        public static void Soru1()
        {
            ArrayList asalSayilar = new ArrayList();
            ArrayList asalOlmayanSayilar = new ArrayList();

            int asalToplam = 0;
            int asalOlmayanToplam = 0;
            int asalSayac = 0;
            int asalOlmayanSayac = 0;

            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine($"Lütfen {i + 1}. pozitif sayıyı girin: ");


                if (int.TryParse(Console.ReadLine(), out int sayi) && sayi > 0)
                {
                    bool asalMi = true;
                    for (int j = 2; j < sayi; j++)
                    {
                        if (sayi % j == 0)
                        {
                            asalMi = false;
                            break;
                        }
                    }
                    if (asalMi)
                    {
                        asalSayilar.Add(sayi);
                        asalToplam += sayi;
                        asalSayac++;
                    }
                    else
                    {
                        asalOlmayanSayilar.Add(sayi);
                        asalOlmayanToplam += sayi;
                        asalOlmayanSayac++;
                    }
                }
                else
                {
                    Console.WriteLine("Geçersiz giriş! Pozitif bir sayı giriniz.");
                    i--;
                }
            }

            asalSayilar.Sort();
            asalSayilar.Reverse();
            asalOlmayanSayilar.Sort();
            asalOlmayanSayilar.Reverse();

            Console.WriteLine("Asal Sayılar");
            foreach (int i in asalSayilar)
            {
                Console.WriteLine(i);
            }


            Console.WriteLine("Asal Olmayan Sayılar");
            foreach (var i in asalOlmayanSayilar)
            {
                Console.WriteLine(i);
            }

            if (asalSayac > 0)
            {
                double asalOrtalama = (double)asalToplam / asalSayac;
                Console.WriteLine($"\nAsal Sayıların Toplamı: {asalToplam}");
                Console.WriteLine($"Asal Sayıların Ortalaması: {asalOrtalama:F2}");
            }
            else
            {
                Console.WriteLine("\nAsal sayı bulunamadı.");
            }

            if (asalOlmayanSayac > 0)
            {
                double asalOlmayanOrtalama = (double)asalOlmayanToplam / asalOlmayanSayac;
                Console.WriteLine($"\nAsal Olmayan Sayıların Toplamı: {asalOlmayanToplam}");
                Console.WriteLine($"Asal Olmayan Sayıların Ortalaması: {asalOlmayanOrtalama:F2}");
            }
            else
            {
                Console.WriteLine("\nAsal olmayan sayı bulunamadı.");
            }
        }
        public static void Soru2()
        {
            int[] sayilar = new int[20];
            double buyukToplam = 0;
            double kucukToplam = 0;


            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine($"{i + 1}. sayıyı giriniz: ");
                sayilar[i] = Convert.ToInt32(Console.ReadLine());

            }

            Array.Sort(sayilar);
            Console.WriteLine("\nEn küçük 3 sayı:");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(sayilar[i]);
                kucukToplam += sayilar[i];
            }

            Array.Reverse(sayilar);
            Console.WriteLine("\nEn büyük 3 sayı:");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(sayilar[i]);
                buyukToplam += sayilar[i];
            }

            Console.WriteLine($"En büyük 3 sayının ortalaması: {buyukToplam / 3:F2}");
            Console.WriteLine($"En küçük 3 sayının ortalaması: {kucukToplam / 3:F2}");
            Console.WriteLine($"Ortalama toplamları: {(buyukToplam / 3) + (kucukToplam / 3):F2}");
        }
        public static void Soru3()
        {
            Console.Write("Bir cümle yazınız: ");
            string s = Console.ReadLine();
            List<char> sesliHarf = new List<char>();

            for (int i = 0; i < s.Length; i++)
            {
                char.ToLower(s[i]);
                if (s[i] == 'a' || s[i] == 'e' ||
                    s[i] == 'ı' || s[i] == 'i' ||
                    s[i] == 'o' || s[i] == 'ö' ||
                    s[i] == 'u' || s[i] == 'ü')
                {
                    sesliHarf.Add(s[i]);
                }
            }
            sesliHarf.Sort();
            Console.WriteLine("\nSesli harfler");
            foreach (char c in sesliHarf)
            {
                Console.WriteLine(c);
            }
        }
    }
}
