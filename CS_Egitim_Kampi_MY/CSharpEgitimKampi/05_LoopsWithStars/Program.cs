using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_LoopsWithStars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Top and Bottom 10 Stars

            //for (int i = 0; i <=10; i++)
            //{
            //    Console.WriteLine("*");
            //}

            #endregion

            #region Side by Side 10 Stars

            //for (int i = 0; i <= 10; i++)
            //{
            //    Console.Write("*");
            //}

            #endregion

            #region 10 Rows, 10 Stars in Each Row

            //for (int i = 0; i <= 10; i++)
            //{
            //    Console.Write("**********");
            //}

            #endregion

            #region Right Triangle

            //for (int i = 1; i <=5; i++)
            //{
            //    for(int j=1;j<=i;j++)
            //    {
            //        Console.Write("*");
            //    }
            //    Console.WriteLine();
            //}

            #endregion

            #region Reverse Right Triangle

            //for (int i = 5; i >= 1; i--)
            //{
            //    for (int j = 1; j <= i; j++)
            //    {
            //        Console.Write("*");
            //    }
            //    Console.WriteLine();
            //}

            #endregion

            #region Half Diamond

            //for (int i = 1;i<=5;i++)
            //{
            //    for(int j=1;j<=i;j++)
            //    {
            //        Console.Write("*");
            //    }
            //    Console.WriteLine();
            //}

            //for(int k=4;k>=1;k--)
            //{
            //    for(int m=1;m<=k;m++)
            //    {
            //        Console.Write("*");
            //    }
            //    Console.WriteLine();
            //}

            #endregion

            #region Half Diamond 2

            //int n = 5;

            //for (int i = 1; i <= n; i++)
            //{
            //    for(int j=n-1;j>0;j--)
            //    {
            //        Console.Write(" ");
            //    }
            //    for(int k=1;k<=2*i-1;k++)
            //    {
            //        Console.Write("*");
            //    }
            //    Console.WriteLine();
            //}

            //for(int i=n-1;i>=1;i--)
            //{
            //    for(int j=n-1;j>0;j--)
            //    {
            //        Console.Write(" ");
            //    }
            //    for(int k=1;k<=2*i-1;k++)
            //    {
            //        Console.Write("*");
            //    }
            //    Console.WriteLine();
            //}

            #endregion

            #region Pyramid

            //int n = 5;
            //for(int i=1;i<=n; i++)
            //{
            //    for(int j=n-i;j>0;j--)
            //    {
            //        Console.Write(" ");
            //    }
            //    for(int k=1;k<=2*i-1;k++)
            //    {
            //        Console.Write("*");
            //    }
            //    Console.WriteLine();
            //}

            #endregion

            #region Reverse Pyramid            

            int n = 5;
            for (int i = n; i >= 1; i--)
            {
                for (int j = n - i; j > 0; j--)
                {
                    Console.Write(" ");
                }
                for (int k = 1; k <= 2 * i - 1; k++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }

            #endregion

            Console.ReadKey();
        }
    }
}
