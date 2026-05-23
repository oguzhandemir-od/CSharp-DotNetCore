internal class Program
{
    private static void Main(string[] args)
    {
        int[] ikililer;
        string[] dizi;
        while (true)
        {
            while (true)
            {
                Console.Write("Mutlak Kare için dizi uzunluğu giriniz: ");
                int uzunluk = int.Parse(Console.ReadLine());
                if (uzunluk % 2 != 0)
                {
                    Console.WriteLine("Dizi uzunluğu çift bir sayı olmalıdır. Lütfen tekrar deneyin.");
                    continue;
                }
                ikililer = new int[uzunluk];
                break;
            }
            while (true)
            {
                Console.Write("Dizi elemanlarını aralarında virgül ile giriniz: ");
                string giris;
                while (true)
                {
                    giris = Console.ReadLine();
                    if (!KarakterKontrol(giris))
                    {
                        Console.WriteLine("Girdiğiniz dizide geçersiz karakterler vardır. Lütfen tekrar deneyin.");
                        Console.Write("Dizi: ");
                        continue;
                    }
                    break;
                }
                giris = giris.Replace(" ", "");
                dizi = giris.Split(',');
                if (dizi.Length != ikililer.Length)
                {
                    Console.WriteLine("Girdiğiniz değerlerin sayısı, belirttiğiniz dizi uzunluğu ile eşleşmiyor. Lütfen tekrar deneyin.");
                    continue;
                }
                if (dizi[dizi.Length - 1] == "")
                {
                    dizi[dizi.Length - 1] = "0";
                }
                break;
            }
            Hesaplama(ikililer, dizi);

            break;
        }
    }
    public static void Hesaplama(int[] ikililer, string[] dizi)
    {
        int toplam = 0;
        int carpim = 1;
        for (int i = 0; i < ikililer.Length; i++)
        {
            ikililer[i] = int.Parse(dizi[i]);
        }
        for (int i = 0; i < ikililer.Length;)
        {
            if (ikililer[i] < 67)
                toplam = 67 - ikililer[i];
            else
                toplam = Math.Abs(67 - ikililer[i]) * Math.Abs(67 - ikililer[i]);

            if (ikililer[i + 1] < 67)
                toplam = toplam + 67 - ikililer[i + 1];
            else
                toplam = toplam + Math.Abs(67 - ikililer[i + 1]) * Math.Abs(67 - ikililer[i + 1]);
            
            Console.WriteLine($"{ikililer[i]} ve {ikililer[i + 1]} için sonuç: {toplam}");

            toplam = 0;
            i += 2;
        }
    }
    public static bool KarakterKontrol(string giris)
    {
        foreach (var s in giris)
        {
            if (!(char.IsDigit(s)) && (s != ',') && (s != ' ') && (s != '-'))
            {
                return false;
            }
        }
        return true;
    }
}