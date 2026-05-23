using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHAR
{
    public static class CHAR05
    {
        public static void AnaKod()
        {
            DateTime dateAndTime = new DateTime(2011, 7, 6, 7, 32, 0);
            double temperature = 68.3;
            string result = string.Format("At {0:t} on {0:D}, the temperature was {1:F1} degrees Fahrenheit.", dateAndTime, temperature);

            Console.WriteLine(result);
        }
    }
}
