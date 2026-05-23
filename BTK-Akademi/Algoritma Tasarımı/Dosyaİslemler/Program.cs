using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dosyaİslemler
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string kaynak = Dosya.FizikselYol("İsimler.txt");

            Dosya.Silme(kaynak);

            Console.ReadKey();
        }

        
       
    }
}
