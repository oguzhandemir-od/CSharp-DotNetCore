using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMD2
{
    public class Matematik
    {
        /// <summary>
        /// Parametre olarak aldığı taban ve kuvvet bilgisine bağlı olarka bir üs alma işlemi gerçekleştirir.
        /// </summary>
        /// <param name="taban">Taban</param>
        /// <param name="kuvvet">Kuvvet</param>
        /// <returns>Sonuç</returns>
        public static double UsAlma(double taban, double kuvvet)
        {
            double s = 1;
            for (int i = 1; i <= kuvvet; i++)
            {
                s *= taban;
            }
            return s;
        }

        /// <summary>
        /// Bir sayının asal çarpanlarını verir.
        /// </summary>
        /// <param name="n">Sayı</param>
        /// <returns>Çarpanlar dizisi</returns>
        public static int[] AsalCarpanlar(int n)
        {
            string carpanListesi = "";
            int i = 2;

            while (n>1)
            {
                if (n % i == 0)
                {
                    n = n / i;
                    carpanListesi += i.ToString() + ",";

                }
                else
                    i++;
            }
            carpanListesi = carpanListesi.Substring(0, carpanListesi.Length - 1);
            string[] carpanlar = carpanListesi.Split(',');

            string s = carpanlar[0];
            string y = s;

            for (i = 0; i < carpanlar.Length; i++)
            {
                if (!(s==carpanlar[i]))
                {
                    y = y + "," + carpanlar[i];
                    s = carpanlar[i];
                }
            }
            carpanlar = y.Split(',');
            int[] asalCarpanlar = new int[carpanlar.Length];
            for ( i = 0; i < asalCarpanlar.Length; i++)
            {
                asalCarpanlar[i] = Convert.ToInt32(carpanlar[i]);
            }
            return asalCarpanlar;

        }

        /// <summary>
        /// Bir sayının asal çarpanlarının toplamını verir
        /// </summary>
        /// <param name="n">Sayı</param>
        /// <returns>Toplam</returns>
        public static int AsalCarpanlarToplami(int n)
        {
            int[] asalCarpanlar = Matematik.AsalCarpanlar(60);
            int t = 0;
            for (int i = 0; i < asalCarpanlar.Length; i++)
            {
                t += asalCarpanlar[i];
            }
            return t;
        }

        /// <summary>
        /// Bir sayının asal çarpanlarının çarpımını hesaplar.
        /// </summary>
        /// <param name="n">Sayı</param>
        /// <returns>Çarpım</returns>
        public static int AsalCarpanlarCarpimi(int n)
        {
            int c = 1;
            int[] asalCarpanlar = AsalCarpanlar(n);
            for (int i = 0; i < asalCarpanlar.Length; i++)
            {
                c *= asalCarpanlar[i];

            }
            return c;
        }

        public static int OKEK(int s1,int s2)
        {
            int s = 1;
            while(s1!=1 &&s2!=1)
            {
                int bol = 2;
                for (int i = 0; i <= (s1>s2?s1:s2); i++)
                {
                    if (s1 % bol == 0 || s2 % bol == 0)
                    {
                        s *= bol;
                        if (s1 % bol == 0)
                            s1 /= bol;
                        if (s2 % bol == 0)
                            s2 /= bol;

                    }
                    else
                        bol++;
                }
            }
            return s;
        }

        public static int OBEB(int s1,int s2)
        {
            int s = 1;
            int bolen = 2;
            while(s1!=1&&s2!=1)
            {
                for(int i=2;i<(s1>s2 ? s1: s2);i++)
                {
                    if (s1 % bolen == 0 || s2 % bolen == 0)
                    {
                        if (s1 % bolen == 0 && s2 % bolen == 0)
                        {
                            s *= bolen;
                        }
                        if (s1 % bolen == 0)
                        {
                            s1 /= bolen;
                        }
                        if (s2 % bolen == 0)
                        {
                            s2 /= bolen;
                        }
                    }
                    else
                        bolen++;
                }
            }
            return s;
        }

        /// <summary>
        /// Faktöriyel hesabı.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int Faktoriyel(int n)
        {
            if (n <= 1)
                return 1;

            int f = 1;
            for (int i = 2; i <=n; i++)
            {
                f *= i;
            }
            return f;
        }

        public static int IkilikTabanOnlukTabanGec(string ikilikTaban)
        {
            // İkilik sayının okunması
            string ikilikSayi = Console.ReadLine();

        // Uzunluğu belirle
        int n = ikilikSayi.Length;

        // Her bir basamağın dizide tutulması
        int[] basamaklar = new int[n];

        // Onluk karşılığı
        int sayi = 0;

        bool kontrol = true;
            for (int i = 0; i<n; i++)
            {
                if (!(ikilikSayi[i]=='0'||ikilikSayi[i]=='1'))
                {
                    Console.WriteLine("\aHatalı Giriş!");
                    kontrol = false;
                    break;
                }

    basamaklar[i] = (int)(ikilikSayi[i] - '0');
            }

            // 2'lik sistemden 10'luk sisteme geçiş
            if (kontrol)
            {
                for (int i = 0; i<n; i++)
                {
                    sayi += (int)Math.Pow(2, n - 1 - i) * basamaklar[i];
                }
                Console.WriteLine("{0} ikilik sayı = {1}", ikilikSayi, sayi);
            }
            return sayi;
        }
    }
}
