using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Fow42
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int rastgeleSayi = rnd.Next(0, 1001);
            int sayac = 10;
            while (sayac > 0)
            {
                Console.Write("Bir sayı giriniz: ");
                int sayi = int.Parse(Console.ReadLine());

                if (sayi < rastgeleSayi)
                {
                    Console.WriteLine("Daha büyük bir sayı giriniz.");
                }
                else if (sayi > rastgeleSayi)
                {
                    Console.WriteLine("Daha küçük bir sayı giriniz.");
                }
                else if(sayi==rastgeleSayi)
                {
                    Console.WriteLine($"Sayı bulundu. Sayı: {rastgeleSayi}");
                    break;
                }
                sayac--;
            }
            Console.WriteLine("Tahmin işlemi bitti.");
            Console.ReadKey();
        }
    }
}
