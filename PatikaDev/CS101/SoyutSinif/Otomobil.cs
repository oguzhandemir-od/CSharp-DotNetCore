using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoyutSinif
{
    public abstract class Otomobil
    {
        public int TekerlekSayisi()
        {
            return 4;
        }

        public virtual Renk StandartRenk()
        {
            return Renk.Beyaz;
        }

        public abstract Marka HangiMarka();
    }
}
