using TelefonRehberi;

internal class Program
{
    private static void Main(string[] args)
    {
        while (true)
        {
            Menu.Menuler();
            string secim = Console.ReadLine();
            Menu.SecimiUygula(secim);
        }
    }
}
