using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uygulama10_Nesne
{
    class Ogrenci
    {
        private string ad;
        private string soyad;
        private string kulup;

        public string Ad
        {
            get { return ad; }
            set { ad = value.ToLower(); }
        }

        public string Soyad
        {
            get
            {
                return soyad;
            }

            set
            {
                soyad = value;
            }
        }

        public string Kulup
        {
            get
            {
                return kulup;
            }

            set
            {
                kulup = value;
            }
        }
    }
}
