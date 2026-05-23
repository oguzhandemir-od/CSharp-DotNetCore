using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Fow42
{
    internal class Calismalar
    {
        public static void Calisma1()
        {
            bool kontrol = true;
            double sayi1 = 0, sayi2 = 0, sonuc;
            while (kontrol)
            {
                Console.WriteLine("Bir işlem seçiniz");
                Console.WriteLine("1-Toplama");
                Console.WriteLine("2-Çıkarma");
                Console.WriteLine("3-Çarpma");
                Console.WriteLine("4-Bölme");
                Console.WriteLine("5-Çıkış");
                Console.WriteLine();
                Console.Write("Seçim: ");
                string secim = Console.ReadLine();
                if (!SayiMi(secim))
                {
                    Console.WriteLine("Geçersiz giriş. Tekrar deneyin.");
                    continue;
                }
                if (secim != "5")
                {
                    while (true)
                    {
                        Console.Write("Birinci sayıyı giriniz: ");
                        string giris1 = Console.ReadLine();
                        if (SayiMi(giris1))
                        {
                            sayi1 = int.Parse(giris1);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Geçersiz giriş. Tekrar deneyin.");
                            continue;
                        }
                    }

                    while (true)
                    {
                        Console.Write("İkinci sayıyı giriniz: ");
                        string giris2 = Console.ReadLine();
                        if (SayiMi(giris2))
                        {
                            sayi2 = int.Parse(giris2);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Geçersiz giriş. Tekrar deneyin.");
                            continue;
                        }
                    }
                    if (secim == "1")
                    {
                        sonuc = sayi1 + sayi2;
                        Console.WriteLine($"Toplama işlemi sonucu: {sonuc}");
                    }
                    else if (secim == "2")
                    {
                        sonuc = sayi1 - sayi2;
                        Console.WriteLine($"Çıkarma işlemi sonucu: {sonuc}");
                    }
                    else if (secim == "3")
                    {
                        sonuc = sayi1 * sayi2;
                        Console.WriteLine($"Çarpma işlemi sonucu: {sonuc}");
                    }
                    else if (secim == "4")
                    {
                        if (sayi2 != 0)
                        {
                            sonuc = sayi1 / sayi2;
                            Console.WriteLine($"Bölme işlemi sonucu: {sonuc}");
                        }
                        else
                        {
                            Console.WriteLine("Bölen sayı sıfır olamaz!");
                            continue;
                        }
                    }

                }
                else if (secim == "5")
                {
                    kontrol = false;
                    Console.WriteLine("Program sonlandırıldı.");
                }
            }
        }
        public static void Calisma2()
        {
            double bakiye = 1000;
            bool kontrol = true;
            while (kontrol)
            {
                Console.WriteLine("ATM Menüsü");
                Console.WriteLine("**********");
                Console.WriteLine("1-Para Çek");
                Console.WriteLine("2-Para Yatır");
                Console.WriteLine("3-Bakiye Öğren");
                Console.WriteLine("4-Çıkış");
                Console.WriteLine("Yapmak istediğiniz işlemi seçiniz.");
                Console.Write("Seçim: ");
                string secim = Console.ReadLine();
                switch (secim)
                {
                    case "1":
                        Console.WriteLine("PARA ÇEKME");
                        Console.Write("Çekmek istediğiniz para miktarı: ");
                        double paraCek = double.Parse(Console.ReadLine());
                        if (!(paraCek > bakiye))
                        {
                            bakiye -= paraCek;
                            Console.WriteLine($"Çekilen para: {paraCek}");
                            Console.WriteLine($"Kalan para: {bakiye}");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Bakiyeniz yetersiz!");
                            Console.WriteLine();
                        }
                        break;
                    case "2":
                        Console.WriteLine("PARA YATIRMA");
                        Console.Write("Yatırmak istediğiniz para miktarı: ");
                        double paraYatir = double.Parse(Console.ReadLine());
                        if (paraYatir < 0)
                        {
                            Console.WriteLine("Yatırılan miktar pozitif olmalıdır!");
                            Console.WriteLine();
                        }
                        else
                        {
                            bakiye += paraYatir;
                            Console.WriteLine($"Yatırılan para: {paraYatir}");
                            Console.WriteLine($"Mevcut para: {bakiye}");
                            Console.WriteLine();
                        }
                        break;
                    case "3":
                        Console.WriteLine("BAKİYE ÖĞRENME");
                        Console.WriteLine($"Mevcut Bakiyeniz: {bakiye}");
                        Console.WriteLine();
                        break;
                    case "4":
                        kontrol = false;
                        Console.WriteLine("Program sonlandırıldı.");
                        Thread.Sleep(1000);
                        break;
                    default:
                        Console.WriteLine("Geçersiz giriş. Tekrar deneyin.");
                        Console.WriteLine();
                        break;
                }

            }
        }
        public static void Calisma3()
        {
            int toplam = 0;
            for (int i = 0; i < 10; i++)
            {
                Console.Write($"{i + 1}. sayıyı girin: ");
                toplam += int.Parse(Console.ReadLine());

            }
        }
        public static void Calisma4()
        {
            Console.Write($"1. sayıyı girin: ");
            int sayi = int.Parse(Console.ReadLine());
            int toplam = 0;
            int enKucuk = sayi;
            int enBuyuk = sayi;
            for (int i = 1; i < 5; i++)
            {
                Console.Write($"{i + 1}. sayıyı girin: ");
                sayi = int.Parse(Console.ReadLine());

                if (sayi < enKucuk)
                {
                    enKucuk = sayi;
                }
                if (sayi > enBuyuk)
                {
                    enBuyuk = sayi;
                }
                toplam += sayi;

            }
            Console.WriteLine($"En küçük sayı: {enKucuk}");
            Console.WriteLine($"En büyük sayı: {enBuyuk}");
            Console.WriteLine($"Sayıların toplamı: {toplam}");
        }
        public static void Calisma5()
        {
            Console.Write("Bir sayı giriniz: ");
            int sayi = int.Parse(Console.ReadLine());
            int carpim = 1;
            if (sayi > 0)
            {
                for (int i = 1; i <= sayi; i++)
                {
                    carpim *= i;
                }
                Console.WriteLine($"{sayi} sayısının faktöriyeli: {carpim}");
            }
            else if (sayi == 0)
            {
                carpim = 1;
                Console.WriteLine($"{sayi} sayısının faktöriyeli: {carpim}");
            }
            else if (sayi < 0)
            {
                Console.WriteLine("Sayı 0'dan küçük olamaz!");
            }
        }
        public static void Calisma6()
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
                else if (sayi == rastgeleSayi)
                {
                    Console.WriteLine($"Sayı bulundu. Sayı: {rastgeleSayi}");
                    break;
                }
                sayac--;
            }
            Console.WriteLine("Tahmin işlemi bitti.");
        }
        public static bool SayiMi(string sayi)
        {

            if (!(int.TryParse(sayi, out int number)))
            {
                return false;
            }
            return true;
        }
    }
}
