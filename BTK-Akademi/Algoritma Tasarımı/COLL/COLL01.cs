using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLL
{
    public class COLL01
    {
        public static void AnaKod()
        {
            string s = "Merhaba";
            IEnumerator rator = s.GetEnumerator();
            while (rator.MoveNext())
            {
                char c = (char)rator.Current;
                Console.Write(c + ".");
            }
            // M.e.r.h.a.b.a.
        }
    }
}
