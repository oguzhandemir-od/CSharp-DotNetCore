using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArayuzOrnek
{
    internal class Corolla : IOtomobil
    {
        public Marka HangiMarka()
        {
            return Marka.Toyota;
        }

        public Renk StandartRenk()
        {
            return Renk.Beyaz;
        }

        public int TekerlekSayisi()
        {
            return 4;
        }
    }
}
