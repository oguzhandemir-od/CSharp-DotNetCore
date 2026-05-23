using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArayuzOrnek
{
    internal class Civic : IOtomobil
    {
        public Marka HangiMarka()
        {
            return Marka.Honda;
        }

        public Renk StandartRenk()
        {
            return Renk.Gri;
        }

        public int TekerlekSayisi()
        {
            return 4;
        }
    }
}
