using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHAR
{
    public static class CHAR04
    {
        public static void AnaKod()
        {
            string sentence = "This sentence has five words.";
            int startPosition = sentence.IndexOf(" ") + 1;
            string word2 = sentence.Substring(startPosition, sentence.IndexOf(" ", startPosition) - startPosition);
            Console.WriteLine("Second word: " + word2);
        }
    }
}
