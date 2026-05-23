internal class Program
{
    private static void Main(string[] args)
    {
        int a = 2;
        int b = 3;

        int sonuc=Topla(a,b);

        Metotlar ornek = new Metotlar();
        ornek.EkranaYazdir(sonuc.ToString());

        int sonuc2 = ornek.ArtirveTopla(ref a, ref b);
        ornek.EkranaYazdir(sonuc2.ToString());
    }

    public static int Topla(int deger1,int deger2)
    {
        return deger1+deger2;
    }
}
internal class Metotlar
{
    public void EkranaYazdir(string veri)
    {
        Console.WriteLine(veri);
    }

    public int ArtirveTopla(ref int deger1,ref int deger2)
    {
        deger1++;
        deger2++;
        return deger1 + deger2;
    }
}