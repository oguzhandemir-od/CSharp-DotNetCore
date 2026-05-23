internal class Program
{
    private static void Main(string[] args)
    {
        // Out Parametreler
        string sayi = "999";
        int outSayi;

        bool sonuc = int.TryParse(sayi, out outSayi);
        if(sonuc)
        {
            Console.WriteLine("Başarılı");
            Console.WriteLine(outSayi);
        }
        else
        {
            Console.WriteLine("Başarısız");
        }

        Metotlar instance=new Metotlar();
        instance.Topla(2, 3, out int toplamSonuc);
        Console.WriteLine(toplamSonuc);

        // Metot Aşırı Yükleme
        int ifade = 999;
        instance.EkranaYazdir(ifade);
        instance.EkranaYazdir("Oğuzhan", "Demir");

        // Metot İmzası
        // Metot Adı + Parametre Sayısı + Parametre
    }
}
internal class Metotlar
{
    public void Topla(int a,int b,out int Toplam)
    {
        Toplam = a + b;
    }

    public void EkranaYazdir(string veri)
    {
        Console.WriteLine(veri);
    }

    public void EkranaYazdir(int veri)
    {
        Console.WriteLine(veri);
    }

    public void EkranaYazdir(string veri,string veri2)
    {
        Console.WriteLine(veri+veri2);
    }
}