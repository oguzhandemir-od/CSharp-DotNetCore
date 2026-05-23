using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberi
{
    internal class Rehber
    {
        #region Alanlar
        private static Rehber _rehber;
        private List<Kisi> _kayitlar;
        #endregion

        #region Kapsülleme
        public List<Kisi> Kayitlar { get => _kayitlar; set => _kayitlar = value; }
        #endregion

        #region Kurucular ve Başlatmalar
        public static Rehber Basla()
        {
            if (_rehber == null)
                _rehber = new Rehber();
            return _rehber;
        }
        private Rehber()
        {
            Kayitlar = new List<Kisi>();
            Kisi kisi1 = new Kisi { Isim = "Burak", Soyisim = "Yılmaz", Numara = "05111234567" };
            Kisi kisi2 = new Kisi { Isim = "Serkan", Soyisim = "Güven", Numara = "05119876543" };
            Kisi kisi3 = new Kisi { Isim = "Aylin", Soyisim = "Güney", Numara = "05112345678" };
            Kisi kisi4 = new Kisi { Isim = "Pelin", Soyisim = "Aydın", Numara = "05118765432" };
            Kisi kisi5 = new Kisi { Isim = "Mehmet", Soyisim = "Yıldız", Numara = "05110123456" };
            Kayitlar.Add(kisi1);
            Kayitlar.Add(kisi2);
            Kayitlar.Add(kisi3);
            Kayitlar.Add(kisi4);
            Kayitlar.Add(kisi5);
        }
        #endregion
    }
}
