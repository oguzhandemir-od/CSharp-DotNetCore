using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dosyaİslemler
{
    public static class FInfo
    {
        public static void DosyaBilgisi()
        {
            string dosyaYolu = Dosya.FizikselYol("Adlar.txt");
            var fi = new FileInfo(dosyaYolu);

            Console.WriteLine(fi.FullName);
            Console.WriteLine(fi.Length);
            Console.WriteLine(fi.Extension);
            Console.WriteLine(fi.CreationTime);
            Console.WriteLine(fi.LastAccessTime);
            Console.WriteLine(fi.Name);
        }
    }
}
