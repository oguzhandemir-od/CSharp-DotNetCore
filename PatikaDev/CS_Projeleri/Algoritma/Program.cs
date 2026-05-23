internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Lütfen (kelime,sıra) olacak şekilde bir kelime ve \nçıkarılmasını istediğiniz karakter sırasını giriniz: ");
        string giris = Console.ReadLine();
        KarakterSil(giris);
    }
    public static void KarakterSil(string giris)
    {
        string[] parca = giris.Split(',');
        string kelime = parca[0];
        int sira = int.Parse(parca[1]) - 1;
        string yeniKelime = kelime.Remove(sira, 1);
        Console.WriteLine($"Kelimenin son hali: {yeniKelime}");
    }
}