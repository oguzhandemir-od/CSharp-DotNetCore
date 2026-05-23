using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHAR
{
    public static class CHAR03
    {
        public static void AnaKod()
        {
            string str1 = "Today is" + DateTime.Now.ToString("D") + ".";
            Console.WriteLine(str1);

            string str2 = "This is one senctence." + "This is a second.";
            str2 += "This is a third sentence.";
            Console.WriteLine(str2);
        }
    }
}
