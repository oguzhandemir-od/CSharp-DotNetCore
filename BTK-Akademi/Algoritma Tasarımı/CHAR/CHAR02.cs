using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHAR
{
    public static class CHAR02
    {
        public static void AnaKod()
        {
            char[] chars = { 'w', 'o', 'r', 'd' };
            sbyte[] bytes = { 0x41, 0x42, 0x43, 0x44, 0x45, 0x00 };

            string str1 = new string(chars);
            Console.WriteLine(str1);

            string str2 = new string('c', 20);
            Console.WriteLine(str2);

            string stringFromBytes = null;
            string stringFromChars = null;
            unsafe
            {
                fixed (sbyte* pbytes = bytes)
                { stringFromBytes = new string(pbytes); }

                fixed (char* pchars = chars)
                {
                    stringFromChars = new string(pchars);
                }
            }
            Console.WriteLine(stringFromBytes);
            Console.WriteLine(stringFromChars);
        }
    }
}
