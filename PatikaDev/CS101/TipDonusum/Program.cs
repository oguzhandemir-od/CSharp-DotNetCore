internal class Program
{
    private static void Main(string[] args)
    {
        // Implicit Conversion (Bilinçsiz Dönüşüm)

        Console.WriteLine("***** Implicit Conversion *****");

        byte a =5;
        sbyte b = 30;
        short c = 10;

        int d = a + b + c;
        Console.WriteLine("d: " + d);

        long h = d;
        Console.WriteLine("h: " + h);

        float i = h;
        Console.WriteLine("i: " + i);

        string e = "Oğuzhan";
        char f = 'd';
        object g = e + f + d;
        Console.WriteLine("g: " + g);


        // Explicit Conversion (Bilinçli Dönüşüm)

        Console.WriteLine("\n***** Explicit Conversion *****");
        int x = 4;
        byte y = (byte)x;
        Console.WriteLine("y: " + y);

        int z = 100;
        byte t = (byte)z;
        Console.WriteLine("t: " + t);

        float w = 10.3f;
        byte v = (byte)w;
        Console.WriteLine("v: " + v);

        // ToString Metodu
        Console.WriteLine("\n***** ToString Metodu *****");
        int xx = 6;
        string yy = xx.ToString();
        Console.WriteLine("yy: " + yy);

        string zz = 12.5f.ToString();
        Console.WriteLine("zz: " + zz);

        // System.Convert Sınıfı
        Console.WriteLine("\n***** System.Convert Sınıfı *****");
        string s1 = "10", s2 = "20";
        int sayi1, sayi2;
        int toplam;

        sayi1 = Convert.ToInt32(s1);
        sayi2 = Convert.ToInt32(s2);
        toplam = sayi1 + sayi2;
        Console.WriteLine("Toplam: " + toplam);

        // Parse Metodu
        Console.WriteLine("\n***** Parse Metodu *****");
        ParseMethod();
    }
    public static void ParseMethod()
    {
        string metin1 = "10";
        string metin2 = "10.25";
        int rakam1;
        double db1;

        rakam1 = Int32.Parse(metin1);
        Console.WriteLine("Rakam 1: " + rakam1);

        db1 = double.Parse(metin2);
        Console.WriteLine("Db1: " + db1);

    }
}