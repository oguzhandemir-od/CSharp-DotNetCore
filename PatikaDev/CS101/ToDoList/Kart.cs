using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoUygulama;

namespace ToDoList
{
    internal class Kart
    {
        private string _baslik;
        private string _icerik;
        private int _atananKisiID;
        private string _buyukluk;
        private int _linetipi;
        private Dictionary<int, string> _atananKisiler;
        private static Kart _kart;

        public string Baslik { get => _baslik; set => _baslik = value; }
        public string Icerik { get => _icerik; set => _icerik = value; }
        public string Buyukluk { get => _buyukluk; set => _buyukluk = value; }
        public int AtananKisiID { get => _atananKisiID; set => _atananKisiID = value; }
        public int Linetipi { get => _linetipi; set => _linetipi = value; }
        public static Dictionary<int, string> AtananKisiler1 { get => AtananKisiler; set => AtananKisiler = value; }

        public static Kart Basla()
        {
            if (_kart == null)
                _kart = new Kart();


            return _kart;
        }
        public Kart()
        {
            
            
        }
        public Kart(string baslik, string icerik, string buyukluk, int atananKisi)
        {
            Baslik = baslik;
            Icerik = icerik;
            Buyukluk = buyukluk;
            AtananKisiID = atananKisi;
            Linetipi = 1;
        }

        private static Dictionary<int, string> AtananKisiler = new Dictionary<int, string>()
        {
            {110,"Burak Yılmaz" },
            {120,"Serkan Güven" },
            {130,"Aylin Güney" },
            {140,"Pelin Aydın" },
            {150,"Mehmet Yıldız" }
        };
        public static string KartBuyuklugu()
        {
            while (true)
            {
                string s = Console.ReadLine();
                switch (s)
                {
                    case "1":
                        return Boyut.XS.ToString();
                    case "2":
                        return Boyut.S.ToString();
                    case "3":
                        return Boyut.M.ToString();
                    case "4":
                        return Boyut.L.ToString();
                    case "5":
                        return Boyut.XL.ToString();
                    default:
                        Console.WriteLine("Geçersiz giriş. Lütfen tekrar deneyin.");
                        break;
                }
            }
        }
        public enum Boyut
        {
            XS = 1,
            S,
            M,
            L,
            XL
        }

    }
}
