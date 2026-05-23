using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fow45
{
    internal class University
    {
        #region Alanlar
        private string _name;
        private int _year;
        private string _city;
        #endregion

        #region Kapsülleme
        public string Name { get => _name; set => _name = value; }
        public int Year { get => _year; set => _year = value; }
        public string City { get => _city; set => _city = value; }
        #endregion

        #region Kurucu
        public University()
        {
            _name = Name;
            _year = Year;
            _city = City;
            
        }
        #endregion

        #region İşlemler
        public void UniversiteEkle(List<University> unis)
        {
            Console.Write("Üniversite Adı: ");
            string isim = Console.ReadLine();
            Console.Write("Üniversite Yılı: ");
            int yil = int.Parse(Console.ReadLine());
            Console.Write("Üniversite Şehri: ");
            string sehir = Console.ReadLine();
            unis.Add(new University { Name=isim,Year=yil,City=sehir});
        }
        public void UniversiteSil(List<University> unis)
        {
            Console.Write("Silinecek üniversite adı: ");
            unis.Remove(UniversiteAra(unis));
        }
        public static University UniversiteAra(List<University> unis)
        {
            string isim = Console.ReadLine();

            bool kontrol = unis.Any(u => u.Name == isim);
            University bul=new University();
            if (kontrol)
            {
                bul = unis.FirstOrDefault(u => u.Name == isim);
                Console.WriteLine();
                Console.WriteLine($"Bulunan Üniversite: {bul.Name}");
                Console.WriteLine(bul.Year);
                Console.WriteLine(bul.City);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Üniversite bulunamadı.");
                Console.WriteLine();
            }
            return bul;
        }
        public static void UniversiteListele(List<University> unis)
        {
            Console.WriteLine();
            Console.WriteLine("Üniversiteler");
            Console.WriteLine("-------------");
            foreach(University u in unis)
            {
                Console.WriteLine();
                Console.WriteLine($"Üniversite Adı: {u.Name}");
                Console.WriteLine($"Üniversite Yılı: {u.Year}");
                Console.WriteLine($"Üniversite Şehri: {u.City}");
                Console.WriteLine();

            }
        }
        #endregion

    }
}
