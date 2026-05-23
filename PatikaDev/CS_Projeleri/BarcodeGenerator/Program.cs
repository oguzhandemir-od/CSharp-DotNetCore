using BarcodeGenerator;
using IronBarCode;
using System.Reflection.PortableExecutable;

internal class Program
{
    private static void Main(string[] args)
    {
        bool kontrol = true;
        while (kontrol)
        {
            Menu.AnaMenu();
            string secim = Console.ReadLine();

            switch (secim)
            {
                case "1":
                    Islemler.BarkodOlustur();
                    Menu.AnaMenuyeDon();
                    break;
                case "2":
                    Islemler.BarkodOku();
                    Menu.AnaMenuyeDon();
                    break;
                case "3":
                    kontrol = false;
                    break;
                default:
                    Console.WriteLine("Geçersiz giriş.");
                    break;
            }

        }
    }
    
}