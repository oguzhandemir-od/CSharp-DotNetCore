internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Bir cümle yazınız: ");
        string cumle = Console.ReadLine();
        Console.WriteLine("\nCümlenin tersten yazılmış hali: ");
        TerstenYaz(cumle);
        Console.WriteLine();
    }
    public static void TerstenYaz(string cumle)
    {
        string[] parcalar = cumle.Split(' ');
        for (int i = 0; i < parcalar.Length; i++)
        {
            string yeniParca = "";

            for (int j = parcalar[i].Length - 1; j >= 0; j--)
            {
                yeniParca += parcalar[i][j];

            }
            Console.Write(yeniParca + " ");
        }
    }
}