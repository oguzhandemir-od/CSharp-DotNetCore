internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine(Gunler.Pazar);
        Console.WriteLine((int)Gunler.Cumartesi);

        int sicaklik = 32;
        if(sicaklik<=(int)HavaDurumu.Normal)
        {
            Console.WriteLine("Dışarı çıkmak için havanın biraz daha ısınmasını bekleyin.");
        }
        else if(sicaklik>=(int)HavaDurumu.Sicak)
        {
            Console.WriteLine("Dışarı çıkmak için çok sıcak bir gün");
        }
        else if(sicaklik>=(int)HavaDurumu.Normal&&sicaklik<(int)HavaDurumu.CokSicak)
        {
            Console.WriteLine("Hadi dışarı çıkalım");
        }
    }
}

enum Gunler
{
    Pazartesi=1,
    Salı,
    Çarşamba,
    Perşembe,
    Cuma,
    Cumartesi,
    Pazar
}

enum HavaDurumu
{
    Soguk=5,
    Normal=20,
    Sicak=25,
    CokSicak=30
}