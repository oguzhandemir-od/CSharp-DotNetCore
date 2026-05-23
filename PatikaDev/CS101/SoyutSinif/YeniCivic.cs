using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoyutSinif
{
    internal class YeniCivic : Otomobil
    {
        public override Marka HangiMarka()
        {
            return Marka.Honda;
        }

        public override Renk StandartRenk()
        {
            return Renk.Gri;
        }
    }
}
