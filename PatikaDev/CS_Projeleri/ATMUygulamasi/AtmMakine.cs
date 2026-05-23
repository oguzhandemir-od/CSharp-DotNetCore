using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMUygulamasi
{
    public class AtmMakine:Banka
    {
        #region Alanlar
        private int _atmKodu;
        private string _atmKonumu;
        #endregion

        #region Kapsülleme
        public int AtmKodu { get => _atmKodu; set => _atmKodu = value; }
        public string AtmKonumu { get => _atmKonumu; set => _atmKonumu = value; }
        #endregion

        #region ATM İşlemleri
        public void HesaptanCikis()
        {
            Console.WriteLine("Hesaptan çıkış yapılıyor.");
            Console.WriteLine("3...");
            Thread.Sleep(1000);
            Console.WriteLine("2...");
            Thread.Sleep(1000); 
            Console.WriteLine("1...");
            Thread.Sleep(1000);
        }

        public void SiradakiIslem(AtmMakine atm,Musteri girisYapan)
        {
            bool kontrol = true;
            while (kontrol)
            {
                Console.WriteLine("Ana ekrana dönmek için 'm' tuşuna basınız.");
                string secim = Console.ReadLine();

                if (secim.ToLower() == "m")
                {
                    kontrol = false;
                    Console.Clear();
                    Menu.Giris(atm);
                    //Menu.UstBilgi(atm, girisYapan);
                    Menu.AtmMenu(girisYapan);
                }
                else
                {
                    Console.WriteLine("Geçersiz giriş.");
                    kontrol = true;
                }
            }

        }
        #endregion
    }
}
