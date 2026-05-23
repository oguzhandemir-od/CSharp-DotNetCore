using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fow41
{
    internal class Calismalar
    {
        public static void Calisma1()
        {
            Console.Write("Birinci sayıyı giriniz: ");
            int sayi1 = int.Parse(Console.ReadLine());
            Console.Write("İkinci sayıyı giriniz: ");
            int sayi2 = int.Parse(Console.ReadLine());
            int toplam = sayi1 + sayi2;
            Console.Write($"{sayi1} + {sayi2} = {toplam}");
        }
        public static void Calisma2() 
        {
            Console.Write("Birinci ifadeyi giriniz: ");
            string ifade1 = Console.ReadLine();
            Console.Write("İkinci ifadeyi giriniz: ");
            string ifade2 = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine($"Girilen birinci ifade: {ifade1}");
            Console.WriteLine($"Girilen ikinci ifade: {ifade2}");
        }
        public static void Calisma3() 
        {
            Console.Write("Bir sayı giriniz: ");
            int sayi = int.Parse(Console.ReadLine());
            int kalan = sayi % 7;
            Console.WriteLine($"Girdiğiniz sayının 7 ile bölümünden kalan: {kalan}");
        }
        public static void Calisma4()
        {
            Console.Write("Bir sayı giriniz: ");
            int sayi = int.Parse(Console.ReadLine());
            if (sayi < 5)
                Console.WriteLine("Girilen sayı 5'ten küçüktür.");
            else if (sayi == 5)
                Console.WriteLine("Girilen sayı 5'tir.");
            else
                Console.WriteLine("Girilen sayı 5'ten büyüktür.");
        }
    }
}
