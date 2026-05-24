using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects
{
    class ErrorHandling
    {
        #region Try-Catch Block
        // Write the codes that check if the number of children is correct
        public static void Question1()
        {
            Console.Write("Lütfen çocuk sayısını giriniz: ");

            try
            {
                int children = int.Parse(Console.ReadLine());
                Console.WriteLine("Geçerli bir değer girdiniz");
            }
            catch (Exception)
            {
                Console.WriteLine("Lütfen sadece sayı giriniz");
            }
        }

        // Write the codes that show the exception during the type conversion of the data input by user 
        public static void Question2()
        {
            Console.Write("Lütfen bir sayı giriniz: ");

            try
            {
                int children = int.Parse(Console.ReadLine());
                Console.WriteLine("Geçerli bir değer girdiniz");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        #endregion

        #region Exception Object
        // Write the program that warns user once an error occured. Program checks if the student's ID, Name or Scores correct
        public static void Question3()
        {
            int midtermScore, finalScore, averageScore;
            string name, idNumber;

            Console.Write("Öğrencinin TC Kimlik numarasını giriniz: ");
            idNumber = Console.ReadLine();

            if (idNumber.Length != 11)
            {
                try
                {
                    throw new Exception();
                }
                catch (Exception e)
                {
                    Console.WriteLine("TC Kimlik numarası 11 haneli olmak zorundadır.");
                }
            }

            Console.Write("Öğrencinin adını ve soyadını giriniz: ");
            name = Console.ReadLine();

            if (name == "")
            {
                try
                {
                    throw new Exception();
                }
                catch (Exception)
                {
                    Console.WriteLine("Ad ve Soyad Bilgisi girilmesi zorunludur.");
                }

            }

            Console.Write("Öğrencinin vize notunu giriniz: ");
            midtermScore = int.Parse(Console.ReadLine());

            if (midtermScore < 0 || midtermScore > 100)
            {
                try
                {
                    throw new Exception();
                }
                catch (Exception)
                {
                    Console.WriteLine("Vize notu 0-100 arasında olmak zorundadır.");
                }

            }

            Console.Write("Öğrencinin final notunu giriniz: ");
            finalScore = int.Parse(Console.ReadLine());

            if (finalScore < 0 || finalScore > 100)
            {
                try
                {
                    throw new Exception();
                }
                catch (Exception)
                {
                    Console.WriteLine("Final notu 0-100 arasında olmak zorundadır.");
                }

            }

            averageScore = (int)(midtermScore * 0.4 + finalScore * 0.6);

            Console.Write($"\n{idNumber} numaralı {name} öğrencinin ortalaması: {averageScore}");
        }
        #endregion
    }
}
