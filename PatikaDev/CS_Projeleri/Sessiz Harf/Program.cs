internal class Program
{
    private static void Main(string[] args)
    {
        string[] dizi;
        while (true)
        {
            Console.Write("Sessiz harf tespiti için bir ifade giriniz: ");
            string giris;
            while (true)
            {
                giris = Console.ReadLine();
                if (!KarakterKontrol(giris))
                {
                    Console.WriteLine("Girdiğiniz ifadede geçersiz karakterler vardır. Lütfen tekrar deneyin.");
                    Console.Write("İfade: ");
                    continue;
                }
                break;
            }
            giris = giris.ToLower();
            dizi = giris.Split(' ');
            int sayac = 0;
            Console.Write("İki sessiz harf yan yana mı?: ");
            foreach (string kelime in dizi)
            {
                foreach (var s in kelime)
                {
                    if (s == 'a' || s == 'e' || s == 'ı' || s == 'i' || s == 'o' || s == 'ö' || s == 'u' || s == 'ü')
                    {
                        sayac = 0;
                        continue;
                    }
                    else
                        sayac++;

                    if (sayac == 2)
                    {
                        Console.Write("True ");
                        break;
                    }
                }
                if (sayac <2)
                {
                    Console.Write("False ");
                    sayac = 0;
                }
            }
            Console.WriteLine();
            break;
        }

    }
    public static bool KarakterKontrol(string giris)
    {
        foreach (var s in giris)
        {
            if (!(char.IsLetter(s)) && (s != ',') && (s != ' '))
            {
                return false;
            }
        }
        return true;
    }
}