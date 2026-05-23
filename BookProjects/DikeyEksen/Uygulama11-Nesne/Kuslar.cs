using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uygulama11_Nesne
{
    class Kuslar
    {
        public string tur;
        public int ayak;
        public virtual string SesCikar()
        {
            return "buraya ses yazılacak";
        }

    }
}
