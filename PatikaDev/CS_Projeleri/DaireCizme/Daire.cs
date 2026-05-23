using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaireCizme
{
    internal class Daire
    {
        private double yaricap;
        public double Yaricap { get => yaricap; set => yaricap = value; }

        public void DaireCiz(double r)
        {
            double a = 2.0 * r;
            for (double i = -r; i <= r; i++)
            {
                for (double j = -a; j <= a; j++)
                {
                    double d = (j / a) * (j / a) + (i / r) * (i / r);
                    if (d > 0.9 && d < 1.2)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
