using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dosyaİslemler
{
    public class Dosya
    {
        public static string FizikselYol(string dosyaAdi)
        {
            string[] yol = Directory.GetCurrentDirectory().Split('\\');
            string dosyaYol = "";
            for (int i = 0; i < yol.Length-3; i++)
            {
                dosyaYol += yol[i] + '\\';
            }
            dosyaYol += dosyaAdi;
            return dosyaYol;
        }

        /// <summary>
        /// Dosya kopyalama işlemini gerçekleştirir.
        /// </summary>
        /// <param name="kaynak">Kaynak dosya yolu</param>
        /// <param name="hedef">Hedef dosya yolu</param>
        public static void Kopyalama(string kaynak, string hedef)
        {
            try
            {
                FileInfo fi = new FileInfo(kaynak);
                fi.CopyTo(hedef);
                Console.WriteLine("{0} kaynaklı dosya {1} hedefine kopyalandı.", kaynak, hedef);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }

        /// <summary>
        /// Verilen parametre bilgisine bağlı olarak ilgili dosyayı siler.
        /// </summary>
        /// <param name="kaynak">Kaynak dosya</param>
        public static void Silme(string kaynak)
        {
            try
            {
                FileInfo fi = new FileInfo(kaynak);
                fi.Delete();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                throw;
            }
        }
    }
}
