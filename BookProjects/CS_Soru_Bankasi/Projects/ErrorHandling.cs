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
    }
}
