using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanHesaplama
{
    internal class Menu
    {
        #region Menü İçerikleri
        public static void AnaMenu()
        {
            Console.WriteLine("İşlem yapmak istediğiniz şekli seçiniz.");
            Console.WriteLine("(1) Daire");
            Console.WriteLine("(2) Üçgen");
            Console.WriteLine("(3) Kare");
            Console.WriteLine("(4) Dikdörtgen");
            Console.Write("Seçim: ");
        }
        public static void HesapMenu()
        {
            Console.WriteLine("Hesaplama yapmak istediğiniz türü seçiniz.");
            Console.WriteLine("(1) Çevre");
            Console.WriteLine("(2) Alan");
            Console.WriteLine("(3) Hacim");
            Console.Write("Seçim: ");
        }
        #endregion

        #region Menü İşlevleri
        public static void AnaMenuyeDon()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Ana menüye dönmek için m harfine basınız.");
                string s = Console.ReadLine().ToUpper();

                if (s == "M")
                {
                    Console.Clear();
                    return;
                }
                else
                {
                    Console.WriteLine("Geçersiz giriş. Lütfen tekrar deneyiniz.");
                }
            }
        }
        public static void SecimiUygula()
        {
            while (true)
            {
                string secim = Console.ReadLine();
                switch (secim)
                {
                    case "1":
                        Daire daire = new Daire();
                        HesapMenu();
                        while (true)
                        {
                            string ikinciSecim = Console.ReadLine();
                            switch (ikinciSecim)
                            {
                                case "1":
                                    Console.Clear();
                                    Console.WriteLine("Daire Çevre Hesaplama");
                                    Console.WriteLine("*********************");
                                    daire.DaireBilgisi();
                                    Console.WriteLine($"Dairenin çevresi: {daire.CevreHesapla():F3} br");
                                    break;
                                case "2":
                                    Console.Clear();
                                    Console.WriteLine("Daire Alan Hesaplama");
                                    Console.WriteLine("*********************");
                                    daire.DaireBilgisi();
                                    Console.WriteLine($"Dairenin alanı: {daire.AlanHesapla():F3} br2");
                                    break;
                                case "3":
                                    Console.Clear();
                                    Console.WriteLine("Küre Hacim Hesaplama");
                                    Console.WriteLine("*********************");
                                    daire.DaireBilgisi();
                                    Console.WriteLine($"Kürenin hacmi: {daire.HacimHesapla():F3} br3");
                                    break;
                                default:
                                    Console.WriteLine("Hatalı giriş. Lütfen tekrar deneyin.");
                                    Console.Write("Seçim: ");
                                    continue;
                            }
                            break;
                        }
                        AnaMenuyeDon();
                        break;
                    case "2":
                        Ucgen ucgen = new Ucgen();
                        HesapMenu();
                        while (true)
                        {
                            string ikinciSecim = Console.ReadLine();
                            switch (ikinciSecim)
                            {
                                case "1":
                                    Console.Clear();
                                    Console.WriteLine("Üçgen Çevre Hesaplama");
                                    Console.WriteLine("*********************");
                                    ucgen.UcKenar();
                                    Console.WriteLine($"Üçgenin çevresi: {ucgen.CevreHesapla():F3} br");
                                    break;
                                case "2":
                                    Console.Clear();
                                    Console.WriteLine("Üçgen Alan Hesaplama");
                                    Console.WriteLine("*********************");
                                    ucgen.TabanYukseklik();
                                    Console.WriteLine($"Üçgenin alanı: {ucgen.AlanHesapla():F3} br2");
                                    break;
                                case "3":
                                    Console.Clear();
                                    Console.WriteLine("Üçgen Prizma Hacim Hesaplama");
                                    Console.WriteLine("*********************");
                                    ucgen.TabanYukseklik();
                                    ucgen.Prizma();
                                    Console.WriteLine($"Kürenin hacmi: {ucgen.HacimHesapla():F3} br3");
                                    break;
                                default:
                                    Console.WriteLine("Hatalı giriş. Lütfen tekrar deneyin.");
                                    Console.Write("Seçim: ");
                                    continue;
                            }
                            break;
                        }
                        AnaMenuyeDon();
                        break;
                    case "3":
                        Kare kare = new Kare();
                        HesapMenu();
                        while (true)
                        {
                            string ikinciSecim = Console.ReadLine();
                            switch (ikinciSecim)
                            {
                                case "1":
                                    Console.Clear();
                                    Console.WriteLine("Kare Çevre Hesaplama");
                                    Console.WriteLine("*********************");
                                    kare.KenarBilgisi();
                                    Console.WriteLine($"Dairenin çevresi: {kare.CevreHesapla():F3} br");
                                    break;
                                case "2":
                                    Console.Clear();
                                    Console.WriteLine("Kare Alan Hesaplama");
                                    Console.WriteLine("*********************");
                                    kare.KenarBilgisi();
                                    Console.WriteLine($"Karenin alanı: {kare.AlanHesapla():F3} br2");
                                    break;
                                case "3":
                                    Console.Clear();
                                    Console.WriteLine("Küp Hacim Hesaplama");
                                    Console.WriteLine("*********************");
                                    kare.KenarBilgisi();
                                    Console.WriteLine($"Küpün hacmi: {kare.HacimHesapla():F3} br3");
                                    break;
                                default:
                                    Console.WriteLine("Hatalı giriş. Lütfen tekrar deneyin.");
                                    Console.Write("Seçim: ");
                                    continue;
                            }
                            break;
                        }
                        AnaMenuyeDon();
                        break;
                    case "4":
                        Dikdortgen dikdortgen = new Dikdortgen();
                        HesapMenu();
                        while (true)
                        {
                            string ikinciSecim = Console.ReadLine();
                            switch (ikinciSecim)
                            {
                                case "1":
                                    Console.Clear();
                                    Console.WriteLine("Dikdörtgen Çevre Hesaplama");
                                    Console.WriteLine("*********************");
                                    dikdortgen.KenarBilgisi();
                                    Console.WriteLine($"Dikdörtgenin çevresi: {dikdortgen.CevreHesapla():F3} br");
                                    break;
                                case "2":
                                    Console.Clear();
                                    Console.WriteLine("Dikdörtgen Alan Hesaplama");
                                    Console.WriteLine("*********************");
                                    dikdortgen.KenarBilgisi();
                                    Console.WriteLine($"Dikdörtgenin alanı: {dikdortgen.AlanHesapla():F3} br2");
                                    break;
                                case "3":
                                    Console.Clear();
                                    Console.WriteLine("Dikdörtgen Prizma Hacim Hesaplama");
                                    Console.WriteLine("*********************");
                                    dikdortgen.KenarBilgisi();
                                    dikdortgen.Prizma();
                                    Console.WriteLine($"Dikdörtgen prizmanın hacmi: {dikdortgen.HacimHesapla():F3} br3");
                                    break;
                                default:
                                    Console.WriteLine("Hatalı giriş. Lütfen tekrar deneyin.");
                                    Console.Write("Seçim: ");
                                    continue;
                            }
                            break;
                        }
                        AnaMenuyeDon();
                        break;
                    default:
                        Console.WriteLine("Hatalı giriş. Lütfen tekrar deneyin.");
                        Console.Write("Seçim: ");
                        continue;
                }
                break;
            }
        }
        #endregion
    }
}
