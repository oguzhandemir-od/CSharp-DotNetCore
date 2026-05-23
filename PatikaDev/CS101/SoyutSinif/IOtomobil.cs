using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoyutSinif
{
    internal interface IOtomobil
    {
        int TekerlekSayisi();
        Marka HangiMarka();
        Renk StandartRenk();
    }
}
