using DaireCizme;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Daire çizimi için yarıçap giriniz: ");
        double yaricap=Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("\nDaire");
        Daire daire = new Daire();
        daire.DaireCiz(yaricap);
    }
}
