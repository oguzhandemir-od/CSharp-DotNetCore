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
        #endregion
    }
}
