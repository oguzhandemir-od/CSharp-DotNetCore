using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHAR
{
    public static class CHAR06
    {
        public static void AnaKod()
        {
            string s1 = "This string consists of a single short sentence.";
            int nWords = 0;

            s1 = s1.Trim();
            for (int ctr = 0; ctr < s1.Length; ctr++)
            {
                if (char.IsPunctuation(s1[ctr]) | char.IsWhiteSpace(s1[ctr]))
                    nWords++;
            }
            Console.WriteLine("The sentence\n     {0}\nhas {1} words.", s1, nWords);
        }
    }
}
