using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberi
{
    internal class Menu
    {
        #region Menüler
        public static void Menuler()
        {
            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz:");
            Console.WriteLine("*******************************************");
            Console.WriteLine("(1) Yeni Numara Kaydetmek");
            Console.WriteLine("(2) Varolan Numarayı Silmek");
            Console.WriteLine("(3) Varolan Numarayı Güncellemek");
            Console.WriteLine("(4) Rehberi Listelemek");
            Console.WriteLine("(5) Rehberde Arama Yapmak");
            Console.Write("Seçim: ");
        }
        public static void SecimiUygula(string secim)
        {
            switch (secim)
            {
                case "1":
                    Console.Clear();
                    Islemler.KisiKaydet();
                    AnaMenuyeDon();
                    break;
                case "2":
                    Console.Clear();
                    Islemler.KisiSil();
                    AnaMenuyeDon();
                    break;
                case "3":
                    Console.Clear();
                    Islemler.KisiGuncelle();
                    AnaMenuyeDon();
                    break;
                case "4":
                    Console.Clear();
                    Islemler.KisiListele();
                    AnaMenuyeDon();
                    break;
                case "5":
                    Console.Clear();
                    Islemler.KisiAra();
                    AnaMenuyeDon();
                    break;
                default:
                    Console.WriteLine("Geçersiz giriş. Lütfen tekrar deneyin.");
                    Console.WriteLine();
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

                if(s=="M")
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
