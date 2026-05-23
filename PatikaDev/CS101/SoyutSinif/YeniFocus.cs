using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoyutSinif
{
    internal class YeniFocus : Otomobil
    {
        public override Marka HangiMarka()
        {
            return Marka.Ford;
        }
    }
}
