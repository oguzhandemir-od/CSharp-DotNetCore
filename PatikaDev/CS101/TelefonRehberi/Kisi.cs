using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TelefonRehberi
{
    internal class Kisi
    {
        #region Alanlar
        private string _isim;
        private string _soyisim;
        private string _numara;
        private static Kisi _kisi;
        #endregion

        #region Kapsülleme
        public string Isim { get => _isim; set => _isim = value; }
        public string Soyisim { get => _soyisim; set => _soyisim = value; }
        public string Numara { get => _numara; set => _numara = value; }
        #endregion

        #region Kurucular ve Başlatmalar
        public static Kisi Basla()
        {
            if (_kisi == null)
                _kisi = new Kisi();
            return _kisi;
        }
        public Kisi()
        {
            

        }
        public Kisi(string isim,string soyisim,string numara)
        {
            _isim = isim;
            _soyisim = soyisim;
            _numara = numara;
        }
        #endregion
    }
}

