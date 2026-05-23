public class Main {
    public static void main(String[] args)
    {
        String[] ogrenciler=new String[4];
        ogrenciler[0]="Oğuzhan";
        ogrenciler[1]="Berk";
        ogrenciler[2]="Selin";
        ogrenciler[3]="Gizem";

        for(int i=0;i< ogrenciler.length;i++)
        {
            System.out.println(ogrenciler[i]);
        }

        for(String ogrenci:ogrenciler)
        {
            System.out.println(ogrenci);
        }
    }
}