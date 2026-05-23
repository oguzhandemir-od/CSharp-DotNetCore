using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoUygulama
{
    internal class Kontrol
    {
        #region Kontrol İşlevleri
        public static bool IDKontrol(int atananKisiID)
        {
            while (true)
            {
                if (atananKisiID == 110 || atananKisiID == 120 || atananKisiID == 130 || atananKisiID == 140 || atananKisiID == 150)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Geçersiz ID! Lütfen tekrar deneyin.");
                    return false;
                }
            }
        }
        public static bool BulunamadiSecim()
        {
            bool kontrol = true;
            Console.WriteLine("İşlemi sonlandırmak için  : (1)");
            Console.WriteLine("Yeniden denemek için      : (2)");
            string s = Console.ReadLine();
            switch (s)
            {
                case "1":
                    return false;
                case "2":
                    return true;
                default:
                    Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
                    return BulunamadiSecim();
            }
        }
        #endregion
    }
}
