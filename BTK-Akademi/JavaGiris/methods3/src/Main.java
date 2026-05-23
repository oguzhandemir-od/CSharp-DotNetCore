public class Main {
    public static void main(String[] args)
    {
        int sayi=Topla(5,7);
        String mesaj=SehirVer();
        System.out.println(sayi);
        int toplam=Topla2(2,3,8,7,6);
        System.out.println(toplam);
    }

    public static void Ekle()
    {
        System.out.println("Eklendi.");
    }

    public static void Sil()
    {
        System.out.println("Silindi.");
    }

    public static void Guncelle()
    {
        System.out.println("Güncellendi.");
    }

    public static int Topla(int sayi1,int sayi2)
    {
        return sayi1+sayi2;
    }

    public static int Topla2(int... sayilar)
    {
        int toplam=0;
        for(int sayi:sayilar)
        {
            toplam+=sayi;
        }
        return toplam;
    }

    public static String SehirVer()
    {
        return "Ankara";
    }
    
}