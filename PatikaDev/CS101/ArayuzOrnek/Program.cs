using ArayuzOrnek;

internal class Program
{
    private static void Main(string[] args)
    {
        Focus focus=new Focus();
        Console.WriteLine(focus.HangiMarka().ToString());
        Console.WriteLine(focus.TekerlekSayisi());
        Console.WriteLine(focus.StandartRenk().ToString());

        Civic civic = new Civic();
        Console.WriteLine(civic.HangiMarka().ToString());
        Console.WriteLine(civic.TekerlekSayisi());
        Console.WriteLine(civic.StandartRenk().ToString());

    }
}