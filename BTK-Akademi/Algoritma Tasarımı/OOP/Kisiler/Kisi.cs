using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class Kisi
    {
        
            public Kisi()
            {

            }
            public Kisi(string adi)
            {
                Adi = adi;
            }

            public Kisi(string adi, int yas)
            {
                Adi = adi;
                Yasi = yas;
            }
            public string Adi { get; set; }
            public int Yasi { get; set; }
        
    }
}
