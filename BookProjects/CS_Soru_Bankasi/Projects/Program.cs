using System.Formats.Asn1;
using System.Runtime.CompilerServices;

internal class Program
{
    private static void Main(string[] args)
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

        Console.ReadKey();
    }
}