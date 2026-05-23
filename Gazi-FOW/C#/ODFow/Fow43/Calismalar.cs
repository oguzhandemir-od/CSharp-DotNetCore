using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fow43
{
    internal class Calismalar
    {
        public static void Calisma1()
        {
            Console.WriteLine("Yeni dizi oluşturulacaktır.");
            int[] dizi = new int[10];
            for (int i = 0; i < dizi.Length; i++)
            {
                Console.Write($"{i + 1}. elemanı giriniz: ");
                dizi[i] = int.Parse(Console.ReadLine()); ;
            }
            Console.WriteLine();
            Console.WriteLine("DİZİ");

            for (int i = 0; i < dizi.Length; i++)
            {
                Console.WriteLine($"{i + 1}. eleman: {dizi[i]}");
            }
        }
        public static void Calisma2()
        {
            Random rnd = new Random();
            int[] dizi = new int[rnd.Next(0, 1001)];
            if (dizi.Length != 0)
            {
                int enKucuk = rnd.Next(0, 101);
                int enBuyuk = enKucuk;
                dizi[0] = enKucuk;
                Console.WriteLine($"Dizi uzunluğu: {dizi.Length}");
                for (int i = 1; i < dizi.Length; i++)
                {

                    dizi[i] = rnd.Next(0, 101);
                    if (dizi[i] < enKucuk)
                    {
                        enKucuk = dizi[i];
                    }
                    if (dizi[i] > enBuyuk)
                    {
                        enBuyuk = dizi[i];
                    }
                }
                Console.WriteLine($"En küçük sayı: {enKucuk}");
                Console.WriteLine($"En büyük sayı: {enBuyuk}");
            }
            else
            {
                Console.WriteLine("Dizi uzunluğu sıfırdır. Dizi oluşturulamaz.");
            }

        }
        public static void Calisma3()
        {
            bool kontrol = true;
            while (kontrol)
            {
                Console.Write("Bir sayı giriniz: ");
                int sayi = Convert.ToInt32(Console.ReadLine());
                if (sayi == 5)
                {
                    kontrol = false;
                }
            }
        }
        public static void Calisma4()
        {
            string[] dizi = { "a", "b", "c", "d", "e", "f" };
            string[] ters = new string[dizi.Length];

            for (int i = 0; i < dizi.Length; i++)
            {
                ters[i] = dizi[dizi.Length - 1 - i];

            }
            for (int i = 0; i < ters.Length; i++)
            {
                Console.WriteLine(ters[i]);
            }
        }
        public static void Calisma5()
        {
            int[] dizi = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            for (int i = 0; i < dizi.Length; i++)
            {

                if (i >= 2 && i <= 6)
                {
                    Console.WriteLine(99);
                    continue;
                }
                Console.WriteLine(dizi[i]);
            }
        }
        public static void Calisma6()
        {
            bool kontrol = true;
            List<string> liste = new List<string>();
            while (kontrol)
            {
                Console.WriteLine("Seçenekler");
                Console.WriteLine("1-Eleman Ekle");
                Console.WriteLine("2-Eleman Sil");
                Console.WriteLine("3-Elemanları Listele");
                Console.WriteLine("4-Çıkış");
                Console.Write("Seçim: ");
                int secim = int.Parse(Console.ReadLine());
                string ifade;
                Console.WriteLine();
                switch (secim)
                {
                    case 1:
                        Console.Write("İfade giriniz: ");
                        ifade = Console.ReadLine();
                        liste.Add(ifade);
                        Console.WriteLine("İşlem başarılı.");
                        break;
                    case 2:
                        Console.Write("İfade giriniz: ");
                        ifade = Console.ReadLine();
                        liste.Remove(ifade);
                        Console.WriteLine("İşlem başarılı.");
                        break;
                    case 3:
                        Console.WriteLine("Elemanlar");
                        foreach (var s in liste)
                        {
                            Console.WriteLine(s);
                        }
                        break;
                    case 4:
                        kontrol = false;
                        break;
                    default:
                        Console.WriteLine("Geçersiz giriş.");
                        break;
                }
                Console.WriteLine();
            }
        }
        public static void Calisma7()
        {
            List<string> liste = new List<string>();
            bool kontrol = true;
            while (kontrol)
            {
                Console.Write("Bir ifade giriniz: ");
                string ifade = Console.ReadLine();
                if (ifade == "x")
                    kontrol = false;
                else
                    liste.Add(ifade);
            }
            Console.WriteLine();
            Console.WriteLine("Girilen İfadeler");
            foreach (string s in liste)
            {
                Console.WriteLine(s);
            }
        }
        public static void Calisma8()
        {
            List<int> liste = new List<int> { 1, 34, 76, 385, 243, 199, 16, 900, 450 };
            int gecici = liste[0];

            for (int i = 0; i < liste.Count; i++)
            {
                for (int j = i + 1; j < liste.Count; j++)
                {
                    if (liste[j] < liste[i])
                    {
                        gecici = liste[i];
                        liste[i] = liste[j];
                        liste[j] = gecici;
                    }

                }
            }
            foreach (int i in liste)
            {
                Console.WriteLine(i);
            }
        }
    }
}
