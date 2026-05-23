using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanHesaplama
{
    internal class Ucgen : Sekil
    {
        #region Alanlar
        private double _birinciKenar;
        private double _ikinciKenar;
        private double _ucuncuKenar;
        private double _taban;
        private double _yukseklik;
        private double _prizmaYukseklik;
        #endregion

        #region Kapsülleme
        public double BirinciKenar { get => _birinciKenar; set => _birinciKenar = value; }
        public double IkinciKenar { get => _ikinciKenar; set => _ikinciKenar = value; }
        public double UcuncuKenar { get => _ucuncuKenar; set => _ucuncuKenar = value; }
        public double Taban { get => _taban; set => _taban = value; }
        public double Yukseklik { get => _yukseklik; set => _yukseklik = value; }
        public double PrizmaYukseklik { get => _prizmaYukseklik; set => _prizmaYukseklik = value; }
        #endregion

        #region Hesaplamalar
        public override double AlanHesapla()
        {
            double alan = Taban * Yukseklik / 2;
            return alan;
        }

        public override double CevreHesapla()
        {
            double cevre = BirinciKenar + IkinciKenar + UcuncuKenar;
            return cevre;
        }

        public override double HacimHesapla()
        {
            double hacim = AlanHesapla() * PrizmaYukseklik;
            return hacim;
        }

        
        #endregion

        #region Bilgi Alma
        public void UcKenar()
        {
            while (true)
            {
                while (true)
                {
                    Console.Write("Üçgenin birinci kenarını giriniz: ");
                    string giris=Console.ReadLine();
                    double birinciKenar;

                    if (!Kontrol.SayiMiKontrol(giris))
                        continue;
                    else
                        birinciKenar=double.Parse(giris);

                    if (!Kontrol.PozitifKontrol(birinciKenar))
                        continue;
                    else
                        BirinciKenar = birinciKenar;
                    break;
                }
                while (true)
                {
                    Console.Write("Üçgenin ikinci kenarını giriniz: ");
                    string giris = Console.ReadLine();
                    double ikinciKenar;

                    if (!Kontrol.SayiMiKontrol(giris))
                        continue;
                    else
                        ikinciKenar = double.Parse(giris);

                    if (!Kontrol.PozitifKontrol(ikinciKenar))
                        continue;
                    else
                        IkinciKenar = ikinciKenar;
                    break;
                }
                while (true)
                {
                    Console.Write("Üçgenin üçüncü kenarını giriniz: ");
                    string giris = Console.ReadLine();
                    double ucuncuKenar;

                    if (!Kontrol.SayiMiKontrol(giris))
                        continue;
                    else
                        ucuncuKenar = double.Parse(giris);

                    if (!Kontrol.PozitifKontrol(ucuncuKenar))
                        continue;
                    else
                        UcuncuKenar = ucuncuKenar;
                    break;
                }

                double birIki = _birinciKenar + _ikinciKenar;
                double birUc = _birinciKenar + _ucuncuKenar;
                double ikiUc = _ikinciKenar + _ucuncuKenar;

                if (!(birIki >= _ucuncuKenar) || !(birUc >= _ikinciKenar) || !(ikiUc >= _birinciKenar))
                {
                    Console.WriteLine("Kenar uzunlukları üçgen eşitsizliğine uygun olmalıdır.");
                    Console.WriteLine("a + b >= c veya a + c >= b veya b + c >= a");
                    Console.WriteLine();
                    continue;
                }
                break;
            }
        }
        public void TabanYukseklik()
        {
            while (true)
            {
                Console.Write("Üçgenin tabanını giriniz: ");
                string giris = Console.ReadLine();
                double taban;

                if (!Kontrol.SayiMiKontrol(giris))
                    continue;
                else
                    taban = double.Parse(giris);

                if (!Kontrol.PozitifKontrol(taban))
                {
                    continue;
                }
                else
                    Taban = taban;
                break;
            }
            while (true)
            {
                Console.Write("Üçgenin yüksekliğini giriniz: ");
                string giris = Console.ReadLine();
                double yukseklik;

                if (!Kontrol.SayiMiKontrol(giris))
                    continue;
                else
                    yukseklik = double.Parse(giris);

                if (!Kontrol.PozitifKontrol(yukseklik))
                {
                    continue;
                }
                else
                    Yukseklik = yukseklik;
                break;
            }
            
        }
        public override void Prizma()
        {
            while (true)
            {
                Console.Write("Üçgen prizma için yükseklik giriniz: ");
                string giris = Console.ReadLine();
                double prizmaYukseklik;

                if (!Kontrol.SayiMiKontrol(giris))
                    continue;
                else
                    prizmaYukseklik = double.Parse(giris);

                if (!Kontrol.PozitifKontrol(_taban))
                {
                    continue;
                }
                else
                    PrizmaYukseklik = prizmaYukseklik;
                break;
                
            }
        }
        #endregion
    }
}
