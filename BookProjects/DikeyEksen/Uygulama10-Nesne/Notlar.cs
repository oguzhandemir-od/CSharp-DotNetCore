using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uygulama10_Nesne
{
    class Notlar
    {
        private int Sinav1;
        private int Sinav2;
        private int Sinav3;
        private int ortalama;

        public int Sinav11
        {
            get
            {
                return Sinav1;
            }

            set
            {
                Sinav1 = value;
            }
        }

        public int Sinav21
        {
            
            get
            {
                return Sinav2;
            }

            set
            {
                if(value >=70 && value <=100)
                {
                    Sinav2 = value;
                }
                else
                {
                    Sinav2 = 70;
                }
            }
        }

        public int Sinav31
        {
            get
            {
                return Sinav3;
            }

            set
            {
                Sinav3 = value;
            }
        }

        public int Ortalama
        {
            get
            {
                return ortalama;
            }

            set
            {
                ortalama = value;
            }
        }
    }
}
