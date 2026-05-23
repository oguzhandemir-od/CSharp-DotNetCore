using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanHesaplama
{
    internal class Kare : Sekil
    {
        #region Alanlar
        private double _kenar;
        #endregion

        #region Kapsülleme
        public double Kenar { get => _kenar; set => _kenar = value; }
        #endregion

        #region Hesaplamalar
        public override double AlanHesapla()
        {
            double alan = Kenar * Kenar;
            return alan;
        }
        public override double CevreHesapla()
        {
            double cevre = 4 * Kenar;
            return cevre;
        }
        public override double HacimHesapla()
        {
            double hacim=Kenar* Kenar* Kenar;
            return hacim;
        }
        public override void Prizma()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Bilgi Alma
        public void KenarBilgisi()
        {
            while (true)
            {
                Console.Write("Karenin kenarını giriniz: ");
                string giris=Console.ReadLine();
                double kenar;

                if (!Kontrol.SayiMiKontrol(giris))
                    continue;
                else
                    kenar=double.Parse(giris);
                
                if(!Kontrol.PozitifKontrol(kenar))
                    continue;
                else
                    Kenar = kenar;
                break;
            }
        }
        #endregion
    }
}
