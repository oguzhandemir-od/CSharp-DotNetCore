internal class Program
{
    private static void Main(string[] args)
    {
        int deger = 2;
        string degisken = null;
        string Degisken = null;

        string degisken1 = " ";

        byte b = 5;             // 1 byte
        sbyte c = 5;            // 1 byte

        short s = 5;            // 2 byte
        ushort us = 5;          // 2 byte

        Int16 i16 = 2;          // 2 byte
        int i = 2;              // 4 byte
        Int32 i32 = 2;          // 4 byte
        Int64 i64 = 2;          // 8 byte

        uint ui = 2;            // 4 byte
        long l = 4;             // 8 byte
        ulong ul = 4;           // 8 byte

        // Ondalıklı Sayılar
        float f = 5;            // 4 byte
        double d = 5;           // 8 byte
        decimal dc = 5;         // 16 byte

        char ch = '2';           // 2 byte
        string str = "Oğuzhan";   // Sınırsız

        bool b1 = true;
        bool b2 = false;

        DateTime dt = DateTime.Now;

        Console.WriteLine(dt);

        object o1 = "x";
        object o2 = 'y';
        object o3 = 4;
        object o4 = 4.3;

        // String İfadeler

        string str1 = string.Empty;
        str1 = "Oğuzhan Demir";
        string ad = "Oğuzhan";
        string soyad = "Demir";
        string tamIsim = ad + " " + soyad;

        // Integer Tanımlama Şekilleri

        int int1 = 5;
        int int2 = 3;
        int int3 = int1 * int2;

        // Boolean İfadeler

        bool bool1 = 10 < 2;

        // Değişken Dönüşümleri
        string str20 = "20";
        int int20 = 20;
        string yeniDeger = str20 + int20.ToString();
        Console.WriteLine(yeniDeger); // Çıktısı 2020

        int int21 = int20 + Convert.ToInt32(str20);
        Console.WriteLine(int21); // Çıktısı 40

        int int22 = int20 + int.Parse(str20); // Çıktısı 40

        // DateTime

        string datetime1 = DateTime.Now.ToString("dd.MM.yyyy");
        Console.WriteLine(datetime1);

        string datetime2 = DateTime.Now.ToString("dd/MM/yyyy");
        Console.WriteLine(datetime2);

        string datetime3 = DateTime.Now.ToString("HH:mm");
        Console.WriteLine(datetime3);
    }
}