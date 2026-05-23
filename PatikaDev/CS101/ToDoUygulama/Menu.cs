using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoUygulama
{
    internal class Menu
    {
        #region Menü İşlevleri
        public static void Menuler()
        {
            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz:");
            Console.WriteLine("*****************************************");
            Console.WriteLine("(1) Kart Ekle");
            Console.WriteLine("(2) Kart Sil");
            Console.WriteLine("(3) Kart Güncelle");
            Console.WriteLine("(4) Kart Taşı");
            Console.WriteLine("(5) Board Listeleme");
            Console.Write("Seçim: ");
        }
        public static void SecimiUygula(string secim)
        {
            switch (secim)
            {
                case "1":
                    Console.Clear();
                    Islemler.KartEkle();
                    AnaMenuyeDon();
                    break;
                case "2":
                    Console.Clear();
                    Islemler.KartSil();
                    AnaMenuyeDon();
                    break;
                case "3":
                    Console.Clear();
                    Islemler.KartGuncelle();
                    AnaMenuyeDon();
                    break;
                case "4":
                    Console.Clear();
                    Islemler.KartTasi();
                    AnaMenuyeDon();
                    break;
                case "5":
                    Console.Clear();
                    Islemler.BoardListele();
                    AnaMenuyeDon();
                    break;
                default:
                    Console.WriteLine("Geçersiz giriş. Lütfen tekrar deneyin.");
                    break;
            }

        }
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
        #endregion
    }
}
