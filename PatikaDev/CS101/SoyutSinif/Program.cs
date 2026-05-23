using SoyutSinif;

internal class Program
{
    private static void Main(string[] args)
    {
        YeniFocus focus1=new YeniFocus();
        Console.WriteLine(focus1.HangiMarka().ToString());
        Console.WriteLine(focus1.TekerlekSayisi());
        Console.WriteLine(focus1.StandartRenk().ToString());

        YeniCivic civic1=new YeniCivic();
        Console.WriteLine(civic1.HangiMarka().ToString());
        Console.WriteLine(civic1.TekerlekSayisi());
        Console.WriteLine(civic1.StandartRenk().ToString());
    }
}