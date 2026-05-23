using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanHesaplama
{
    internal class Dikdortgen : Sekil
    {
        #region Alanlar
        private double _kisaKenar;
        private double _uzunKenar;
        private double _prizmaYukseklik;
        #endregion

        #region Kapsülleme
        public double KisaKenar { get => _kisaKenar; set => _kisaKenar = value; }
        public double UzunKenar { get => _uzunKenar; set => _uzunKenar = value; }
        public double PrizmaYukseklik { get => _prizmaYukseklik; set => _prizmaYukseklik = value; }
        #endregion

        #region Hesaplamalar
        public override double AlanHesapla()
        {
            double alan = KisaKenar * UzunKenar;
            return alan;
        }

        public override double CevreHesapla()
        {
            double cevre = 2 * (KisaKenar + UzunKenar);
            return cevre;
        }

        public override double HacimHesapla()
        {
            double hacim = AlanHesapla() * PrizmaYukseklik;
            return hacim;
        }

        
        #endregion

        #region Bilgi Alma
        public void KenarBilgisi()
        {
            while (true)
            {
                Console.Write("Dikdörtgenin kısa kenarını giriniz: ");
                string giris= Console.ReadLine();
                double kisaKenar;

                if(!Kontrol.SayiMiKontrol(giris))
                    continue;
                else
                    kisaKenar=double.Parse(giris);

                if (!Kontrol.PozitifKontrol(kisaKenar))
                    continue;
                else
                    KisaKenar = kisaKenar;
                break;
            }
            while (true)
            {
                Console.Write("Dikdörtgenin uzun kenarını giriniz: ");
                string giris=Console.ReadLine();
                double uzunKenar;

                if (!Kontrol.SayiMiKontrol(giris))
                    continue;
                else
                    uzunKenar = double.Parse(giris);

                if (!Kontrol.PozitifKontrol(uzunKenar))
                    continue;
                else
                    UzunKenar = uzunKenar;
                break;
            }
        }
        public override void Prizma()
        {
            while (true)
            {
                Console.Write("Dikdörtgen prizma için yükseklik giriniz: ");
                string giris = Console.ReadLine();
                double prizmaYukseklik;

                if (!Kontrol.SayiMiKontrol(giris))
                    continue;
                else
                    prizmaYukseklik = double.Parse(giris);

                if (!Kontrol.PozitifKontrol(prizmaYukseklik))
                    continue;
                else
                    PrizmaYukseklik = prizmaYukseklik;
                break;
            }
            
        }
        #endregion
    }
}
