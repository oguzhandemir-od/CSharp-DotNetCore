using Inheritance;

internal class Program
{
    private static void Main(string[] args)
    {
        TohumluBitkiler tohumlubitki= new TohumluBitkiler();
        tohumlubitki.TohumlaCogalma();

        Console.WriteLine("**********");

        Kuslar marti= new Kuslar();
        marti.Ucmak();
    }
}