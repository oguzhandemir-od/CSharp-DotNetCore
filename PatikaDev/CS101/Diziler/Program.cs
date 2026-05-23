internal class Program
{
    private static void Main(string[] args)
    {
        // Dizi Tanımlama
        string[] renkler = new string[5];

        string[] hayvanlar = { "Kedi", "Köpek", "Kuş", "Maymun" };

        int[] dizi;
        dizi= new int[4];

        // Dizilere Değere Atama ve Erişim
        renkler[0] = "Mavi";
        dizi[3] = 10;

        Console.WriteLine(hayvanlar[0]);
        Console.WriteLine(dizi[3]);
        Console.WriteLine(renkler[0]);

        // Döngülerle Dizi Kullanımı
        // Klavyeden girilen n tane sayının ortalaması
        Console.Write("Lütfen dizinin eleman sayısını giriniz: ");
        int diziUzunluğu = int.Parse(Console.ReadLine());
        int[] sayiDizisi = new int[diziUzunluğu];

        for(int i=0;i<diziUzunluğu;i++)
        {
            Console.Write("{0}. sayıyı giriniz: ", i + 1);
            sayiDizisi[i]= int.Parse(Console.ReadLine());
        }

        int toplam = 0;
        foreach (var sayi in sayiDizisi)
        {
            toplam += sayi;
        }

        Console.WriteLine("Ortalama: {0}", toplam / diziUzunluğu);
    }
}