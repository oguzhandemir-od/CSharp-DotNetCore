using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcgenCizme
{
    internal class Ucgen
    {
        private int boyut;

        public int Boyut { get => boyut; set => boyut = value; }

        public void UcgenCiz(int boyut)
        {
            for (int i = 0; i < boyut; i++)
            {
                for (int j = 1; j < boyut - i; j++)
                {
                    Console.Write(" ");
                }
                for (int k = 0; k <= i * 2; k++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
        public bool BoyutKontrol(int boyut)
        {
            while(true)
            {
                if(boyut <1)
                {
                    Console.WriteLine("Lütfen pozitif bir değer giriniz.");
                    return false;
                }
                return true;
            }
        }
    }
}
