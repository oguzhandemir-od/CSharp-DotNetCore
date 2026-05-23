using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dosyaİslemler
{
    public static class SWrite
    {
        public static void DosyaYazma()
        {
            try
            {
                // Dinamik yol tanımı
                string[] yol = Directory.GetCurrentDirectory().Split('\\');
                string dosyaYol = "";
                for (int i = 0; i < yol.Length - 3; i++)
                {
                    dosyaYol += yol[i] + '\\';
                }
                dosyaYol += "Adlar.txt";

                string[] adlar = new string[] { "Zara", "Ayça", "Mehmet", "Selim", "Kaan" };
                using (StreamWriter sw = new StreamWriter(dosyaYol))
                {
                    foreach (string s in adlar)
                    {
                        sw.WriteLine(s);
                    }
                    Console.WriteLine("\nAdlar.txt dosyası başarılı bir şekilde oluşturuldu.");
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
