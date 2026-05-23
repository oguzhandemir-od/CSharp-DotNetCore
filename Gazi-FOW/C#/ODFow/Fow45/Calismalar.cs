using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fow45
{
    internal class Calismalar
    {
        public static void Calisma1()
        {
            while (true)
            {
                Ucgen ucgen = new Ucgen();
                Console.WriteLine("ÜÇGEN OLUŞTURMA");
                Console.WriteLine("---------------");
                Console.Write("Birinci kenar uzunluğunu giriniz: ");
                ucgen.BirinciKenar = double.Parse(Console.ReadLine());
                Console.Write("İkinci kenar uzunluğunu giriniz: ");
                ucgen.IkinciKenar = double.Parse(Console.ReadLine());
                Console.Write("Üçüncü kenar uzunluğunu giriniz: ");
                ucgen.UcuncuKenar = double.Parse(Console.ReadLine());

                Console.WriteLine();
                double cevre = ucgen.CevreHesapla();
                Console.WriteLine($"Üçgenin çevre uzunluğu: {cevre}");
                Console.WriteLine();

                if (ucgen.IkizkenarKontrol())
                {
                    Console.WriteLine("Üçgen ikizkenar üçgendir.");
                    Console.WriteLine();
                }
            }
        }
        public static void Calisma2()
        {
            bool kontrol = true;
            List<University> Universities = new List<University>();
            University uni = new University();

            while (kontrol)
            {
                Menu();
                int secim = int.Parse(Console.ReadLine());

                switch (secim)
                {
                    case 1:
                        uni.UniversiteEkle(Universities);
                        break;
                    case 2:
                        uni.UniversiteSil(Universities);
                        break;
                    case 3:
                        Console.Write("Aranan üniversite adı: ");
                        University.UniversiteAra(Universities);
                        break;
                    case 4:
                        University.UniversiteListele(Universities);
                        break;
                    case 5:
                        kontrol = false;
                        break;
                    default:
                        Console.WriteLine("Geçersiz giriş.");
                        break;
                }
                Console.WriteLine();
            }
        }
        public static void Menu()
        {
            Console.WriteLine("ÜNİVERSİTE YÖNETİMİ");
            Console.WriteLine("-------------------");
            Console.WriteLine("1-Üniversite Ekle");
            Console.WriteLine("2-Üniversite Sil");
            Console.WriteLine("3-Üniversite Ara");
            Console.WriteLine("4-Üniversiteleri Listele");
            Console.WriteLine("5-Çıkış");
            Console.Write("Seçim: ");
        }
    }
}
