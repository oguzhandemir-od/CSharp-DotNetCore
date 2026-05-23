using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMD
{
    public class Sayi
    {
        /// <summary>
        /// Parametre olarak aldığı sayının tek olup olmadığını kontrol eder.
        /// </summary>
        /// <param name="n">Girilen Sayı</param>
        /// <returns>Tek ise true, aksi durumda false şeklinde dönüş yapar.</returns>
        public static bool TekMi(int n)
        {            
            if (n % 2 == 1)
                return true;
            return false;
            
        }

        /// <summary>
        /// Parametre olarak aldığı sayının çift olup olmadığını kontrol eder. 
        /// </summary>
        /// <param name="n">Girilen Sayı</param>
        /// <returns>Çift ise true, aksi durumda false şeklinde dönüş yapar.</returns>
        public static bool CiftMi(int n)
        {
            if (n % 2 == 0)
                return true;
            return false;
        }

        /// <summary>
        /// Parametre olarak aldığı sayının mutlak değerini döndürür.
        /// </summary>
        /// <param name="n">Girilen Sayı</param>
        /// <returns>Girilen sayının mutlak değeri dönüş ifadesidir.</returns>
        public static int MutlakDeger(int n)
        {
            if (n > 0)
                return n;
            else if (n < 0)
                return -1 * n;
            else
                return 0;
        }

        /// <summary>
        /// Parametre olarak aldığı sayının asal sayı olup olmadığını bulur.
        /// </summary>
        /// <param name="n">Girilen Sayı</param>
        /// <returns>Girilen sayının asal sayı ise true değer döndürür.</returns>
        public static bool AsalMi(int n)
        {
            if (n<=1)
            {
                Console.WriteLine("En küçük asal sayı 2'dir");
                return false;
            }

            bool kontrol = true;
            for (int i = 2; i < n; i++)
            {
                if (n%i==0)
                {
                    kontrol = false;
                    break;
                }
            }
            return kontrol;
        }

        /// <summary>
        /// Parametre olarak aldığı sayının rakamları toplamını döndürür.
        /// </summary>
        /// <param name="n">Girilen Sayı</param>
        /// <returns>Rakamların toplamı.</returns>
        public static int RakamlarToplami(int n)
        {
            int toplam = 0, rakam = 0;
            while (n>0)
            {
                rakam = n % 10;
                toplam += rakam;
                n = n / 10;
            }
            return toplam;
        }

        public static int NKadarSayilarToplami(int n)
        {
            int t = 0;
            for (int i = 1; i <= n; i++)
            {
                t += i;
            }
            return t;
        }

        public static int NKadarSayilarFormulToplami(int n)
        {
            return n * (n + 1) / 2;
        }

        public static int NKadarTekSayilarToplami(int n)
        {
            int t = 0;
            for (int i = 1; i <= n; i++)
            {
                if (i%2==1)
                {
                    t += i;
                }
            }
            return t;
        }

        public static int NKadarTekSayilarAlternatifToplami(int n)
        {
            int t = 0;
            for (int i = 1; i <= n; i+=2)
            {
                t += i;
            }
            return t;
        }

        public static int NKadarTekSayilarFormulToplami(int n)
        {
            n++;
            n = n / 2;
            return n * n;
        }

        public static int NKadarCiftSayilarToplami(int n)
        {
            int t = 0;
            for (int i = 2; i <=n; i++)
            {
                if(i%2==0)
                {
                    t += i;
                }
            }
            return t;
        }

        public static int NKadarCiftSayilarAlternatifToplami(int n)
        {
            int t = 0;
            for (int i = 2; i <= n; i+=2)
            {
                t += i;
            }
            return t;
        }

        public static int NKadarCiftSayilarFormulToplami(int n)
        {
            n = n / 2;
            return n * (n + 1);
        }
    }
}
