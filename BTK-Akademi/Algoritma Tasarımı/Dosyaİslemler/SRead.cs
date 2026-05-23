using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dosyaİslemler
{
    public static class SRead
    {
        public static void DosyaOkuma()
        {
            try
            {
                // Dinamik konum
                string[] yol = Directory.GetCurrentDirectory().Split('\\');
                string dosyaYol = "";
                for (int i = 0; i < yol.Length - 3; i++)
                {
                    dosyaYol += yol[i] + '\\';
                }
                dosyaYol += "Rakamlar.txt";

                // Dosya okuma ve yazma
                using (StreamReader sr = new StreamReader(dosyaYol))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
