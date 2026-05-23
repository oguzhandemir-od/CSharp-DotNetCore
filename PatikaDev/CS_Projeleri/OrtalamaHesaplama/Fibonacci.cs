using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrtalamaHesaplama
{
    internal class Fibonacci
    {
        private int[] fSeri;

        public int[] FSeri { get => fSeri; set => fSeri = value; }

        public Fibonacci(int derinlik)
        {
            
            FSeri = new int[derinlik];
            FSeri[0] = 0;
            FSeri[1] = 1;
        }
        public int[] FibonacciSerisi(int derinlik)
        {
            for (int i = 2; i < derinlik; i++)
            {
                FSeri[i] = FSeri[i - 1] + FSeri[i - 2];
            }
            return FSeri;
        }
        public double FibonacciOrtalama(int[] seri)
        {
            double toplam = 0;
            for (int i = 0; i < seri.Length; i++)
            {
                toplam += seri[i];
            }
            double ortalama = toplam / seri.Length;
            return ortalama;
        }
    }
}
