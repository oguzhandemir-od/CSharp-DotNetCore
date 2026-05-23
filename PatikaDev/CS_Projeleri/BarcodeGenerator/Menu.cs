using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeGenerator
{
    internal class Menu
    {
        public static void AnaMenu()
        {
            Console.WriteLine("İşlem Seçiniz");
            Console.WriteLine();
            Console.WriteLine("(1) Barkod Oluştur");
            Console.WriteLine("(2) Barkod Oku");
            Console.WriteLine("(3) Çıkış Yap");
            Console.Write("Seçim: ");
        }

        public static void AnaMenuyeDon()
        {
            bool kontrol = true;
            while (kontrol)
            {
                Console.WriteLine("Ana menüye dönmek için m tuşuna basınız.");
                string donus = Console.ReadLine();
                if (donus == "m")
                {
                    Console.Clear();
                    kontrol = false;
                }
                else
                {
                    Console.WriteLine("Geçersiz giriş.");
                    kontrol = true;
                }
            }
        }
    }
}
