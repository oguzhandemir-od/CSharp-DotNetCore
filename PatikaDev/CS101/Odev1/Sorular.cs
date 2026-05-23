using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev1
{
    public class Sorular
    {
        public static void Soru1()
        {
            Console.WriteLine("Pozitif bir sayı giriniz: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n{0} adet pozitif sayı giriniz: ", n);
            int[] sayilar = new int[n];
            for (int i = 0; i < n; i++)
            {
                sayilar[i] = Convert.ToInt32(Console.ReadLine());

            }

            Console.WriteLine("\nÇift Sayılar");
            for (int i = 0; i < n; i++)
            {
                if (sayilar[i] % 2 == 0)
                {
                    Console.WriteLine(sayilar[i]);
                }
            }
        }

        public static void Soru2()
        {
            Console.WriteLine("Pozitif bir sayı giriniz: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nPozitif bir sayı daha giriniz: ");
            int m = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\n{0} adet pozitif sayı giriniz: ", n);
            int[] sayilar = new int[n];
            for (int i = 0; i < n; i++)
            {
                sayilar[i] = Convert.ToInt32(Console.ReadLine());

            }

            Console.WriteLine("\n{0} ile tam bölünen sayılar: ", m);
            for (int i = 0; i < n; i++)
            {
                if (sayilar[i] % m == 0)
                {
                    Console.WriteLine(sayilar[i]);
                }
            }
        }

        public static void Soru3()
        {
            Console.WriteLine("Pozitif bir sayı giriniz: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n{0} adet kelime giriniz: ", n);
            string[] kelimeler = new string[n];

            for (int i = 0; i < n; i++)
            {
                kelimeler[i] = Console.ReadLine();
            }

            Console.WriteLine("\nKelimelerin sondan başa doğru sıralanışı: ");
            for (int i = n - 1; i >= 0; i--)
            {
                Console.WriteLine(kelimeler[i]);
            }
        }

        public static void Soru4()
        {
            Console.WriteLine("Bir cümle yazınız: ");
            string cumle = Console.ReadLine();

            string[] kelimeler = cumle.Split(' ');
            int toplamHarf = 0;

            for (int i = 0; i < kelimeler.Length; i++)
            {
                for (int j = 0; j < kelimeler[i].Length; j++)
                {
                    if (kelimeler[i][j]=='.'|| kelimeler[i][j] ==',')
                    {
                        continue;
                    }
                    else
                        toplamHarf++;
                }
            }

            Console.WriteLine("Cümlenizde toplam {0} kelime ve {1} harf vardır.", kelimeler.Length, toplamHarf);
        }
    }
}
