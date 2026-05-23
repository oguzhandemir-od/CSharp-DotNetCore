using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMD2
{
    public class Dizi
    {
        /// <summary>
        /// Tek boyutlu dizi oluşturmak için kullanılan fonksiyondur.
        /// </summary>
        /// <param name="limit">Dizinin uzunluğunu belirtir.</param>
        /// <returns>Belirtilen uzunlukta rastgele sayılardan oluşmuş diziyi döndürür.</returns>
        public int[] Olustur(int limit)
        {
            int[] sayilar = new int[limit];
            Console.WriteLine("");
            for (int i = 0; i < limit; i++)
            {
                sayilar[i] = new Random().Next(1, 100);
                Console.Write("{0,3}", sayilar[i]);
            }
            return sayilar;
        }
        /// <summary>
        /// Parametre olarak aldığı dizideki en büyük elemanı döndürür.
        /// </summary>
        /// <param name="dizi">Dizi</param>
        /// <returns></returns>
        public static int EnBuyuk(int[] dizi)
        {
            int eb = dizi[0];
            for (int i = 0; i < dizi.Length; i++)
            {
                if (dizi[i] > eb)
                    eb = dizi[i];
            }
            return eb;
        }

        /// <summary>
        /// Parametre olarak aldığı dizideki en küçük elemanı döndürür.
        /// </summary>
        /// <param name="dizi">Dizi</param>
        /// <returns></returns>
        public static int EnKucuk(int[] dizi)
        {
            int ek = dizi[0];
            for (int i = 0; i < dizi.Length; i++)
            {
                if (dizi[i] < ek)
                    ek = dizi[i];
            }
            return ek;
        }

        /// <summary>
        /// Parametre olarak aldığı dizinin aritmetik ortalamasını hesaplar ve döndürür.
        /// </summary>
        /// <param name="x">Dizi</param>
        /// <returns>Aritmetik Ortalama</returns>
        public static double AritmetikOrtalama(int[] x)
        {
            double toplam = 0;
            for (int i = 0; i < x.Length; i++)
            {
                toplam += x[i];
            }
            return toplam/x.Length;
        }

        /// <summary>
        /// Parametre olarak aldığı dizinin standart sapmasını hesaplar.
        /// </summary>
        /// <param name="x">Dizi</param>
        /// <returns>Standart Sapma</returns>
        public static double StandartSapma(int[] x)
        {
            double aritmetikOrtalama = AritmetikOrtalama(x);
            double t = 0, f = 0;
            for (int i = 0; i < x.Length; i++)
            {
                f = x[i] - aritmetikOrtalama;
                t += Math.Pow(f, 2);
            }
                        
            return Math.Sqrt(t / (x.Length - 1)); ;
        }

        /// <summary>
        /// Bir dizideki tek sayıların sayısını döndürür.
        /// </summary>
        /// <param name="x">Dizi</param>
        /// <returns>Tek sayıların sayısı</returns>
        public int TekSayilarinSayisi(int[] x)
        {
            int tekSayilarinSayisi = 0;
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] % 2 == 1)
                    tekSayilarinSayisi++;
            }
            return tekSayilarinSayisi;
        }

        /// <summary>
        /// Bir dizideki çift sayıların sayısını döndürür.
        /// </summary>
        /// <param name="x">Dizi</param>
        /// <returns>Çift sayıların sayısı</returns>
        public int CiftSayilarinSayisi(int[] x)
        {
            int ciftSayilarinSayisi = 0;
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] % 2 == 0)
                    ciftSayilarinSayisi++;
            }
            return ciftSayilarinSayisi;
        }

        /// <summary>
        /// Bir dizideki tek sayılardan yeni bir dizi oluşturur.
        /// </summary>
        /// <param name="x">Dizi</param>
        /// <returns>Tek sayılardan oluşan dizi</returns>
        public int[] TekDiziOlustur(int[] x)
        {
            int[] tekDizi = new int[TekSayilarinSayisi(x)];
            int y = 0;
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] % 2 == 1)
                {
                    tekDizi[y] = x[i];
                    y++;
                }
            }
            return tekDizi;

        }

        /// <summary>
        /// Bir dizideki çift sayılardan yeni bir dizi oluşturur.
        /// </summary>
        /// <param name="x">Dizi</param>
        /// <returns>Çift sayılardan oluşan dizi</returns>
        public int[] CiftDiziOlustur(int[] x)
        {
            int[] ciftDizi = new int[CiftSayilarinSayisi(x)];
            int y = 0;
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] % 2 == 0)
                {
                    ciftDizi[y] = x[i];
                    y++;
                }
            }
            return ciftDizi;

        }

        /// <summary>
        /// Parametre olarak aldığı diziyi ekrana yazdırır.
        /// </summary>
        /// <param name="x">Dizi</param>
        public static void Yazdir(int[] x)
        {
            Console.WriteLine("");
            for (int i = 0; i < x.Length; i++)
            {
                Console.Write("{0,3}", x[i]);
            }
            Console.WriteLine("");
        }

        public int[] IfadeyiDiziyeCevir(string sozdizimi)
        {
            // Konsoldan ifadenin okunması
            string ifade = Console.ReadLine();

            string[] bolunmusIfade = ifade.Split(',');

            int n = bolunmusIfade.Length;

            // Sayısal Dizi
            int[] sayisalDizi = new int[n];

            // Ayrıştırma
            for (int i = 0; i < n; i++)
            {
                sayisalDizi[i] = Convert.ToInt32(bolunmusIfade[i]);
                Console.WriteLine("Dizi[{0}] = {1}", i + 1, sayisalDizi[i]);
            }

            return sayisalDizi;
        }

        /// <summary>
        /// Girilen ifadedeki sesli harf sayısını döndürür.
        /// </summary>
        /// <param name="sozdizimi"></param>
        /// <returns></returns>
        public int SesliHarfSayisi(string ifade)
        {
            

            // Sesli harf
            int sesliHarf = 0;

            for (int i = 0; i < ifade.Length; i++)
            {
                // Kontrol
                if (ifade[i] == 'a' || ifade[i] == 'A' ||
                    ifade[i] == 'e' || ifade[i] == 'E' ||
                    ifade[i] == 'ı' || ifade[i] == 'I' ||
                    ifade[i] == 'i' || ifade[i] == 'İ' ||
                    ifade[i] == 'o' || ifade[i] == 'O' ||
                    ifade[i] == 'ö' || ifade[i] == 'Ö' ||
                    ifade[i] == 'u' || ifade[i] == 'U' ||
                    ifade[i] == 'ü' || ifade[i] == 'Ü')
                {
                    sesliHarf++;
                }
            
            }
            return sesliHarf;
        }
    }
}
