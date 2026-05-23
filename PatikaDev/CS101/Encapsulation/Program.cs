internal class Program
{
    private static void Main(string[] args)
    {
        Ogrenci ogrenci = new Ogrenci();
        ogrenci.Isim = "Ayşe";
        ogrenci.Soyisim = "Yılmaz";
        ogrenci.OgrenciNo = 293;
        ogrenci.Sinif = 3;

        ogrenci.OgrenciBilgileriniYaz();

        ogrenci.SinifAtlat();
        ogrenci.OgrenciBilgileriniYaz();

        Ogrenci ogrenci2= new Ogrenci("Deniz","Arda",256,1);
        ogrenci2.OgrenciBilgileriniYaz();

        ogrenci2.SinifDusur();
        ogrenci2.SinifDusur();
        ogrenci2.OgrenciBilgileriniYaz();


    }
}
class Ogrenci
{
    private string isim;
    private string soyisim;
    private int ogrenciNo;
    private int sinif;

    public string Isim 
    {
        get { return isim; }
        set { isim = value; }
    }

    public string Soyisim { get => soyisim; set => soyisim = value; }
    public int OgrenciNo { get => ogrenciNo; set => ogrenciNo = value; }
    public int Sinif
    {
        get => sinif;
        set 
        {
            if (value < 1)
            {
                Console.WriteLine("Sınıf en az 1 olabilir, 1 atandı");
                sinif = 1;
            }
            else
            {
                sinif = value;
            }

        }
        
    }

    public Ogrenci()
    {

    }

    public Ogrenci(string isim, string soyisim, int ogrenciNo, int sinif)
    {
        Isim = isim;
        Soyisim = soyisim;
        OgrenciNo = ogrenciNo;
        Sinif = sinif;
    }

    public void OgrenciBilgileriniYaz()
    {
        Console.WriteLine("***** Öğrenci Bilgileri *****");
        Console.WriteLine($"Öğrenci Adı: {Isim}");
        Console.WriteLine($"Öğrenci Adı: {Soyisim}");
        Console.WriteLine($"Öğrenci Adı: {OgrenciNo}");
        Console.WriteLine($"Öğrenci Adı: {Sinif}");
    }

    public void SinifAtlat()
    {
        this.Sinif = this.Sinif + 1;
    }

    public void SinifDusur()
    {
        this.Sinif = this.Sinif - 1;
    }
}