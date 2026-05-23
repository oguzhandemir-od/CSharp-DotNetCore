import java.util.Locale;

public class Main {
    public static void main(String[] args)
    {
        String mesaj="Bugün hava çok güzel.";

        System.out.println(mesaj);
        System.out.println("Eleman sayısı: "+mesaj.length());
        System.out.println("5. eleman:" + mesaj.charAt(4));
        System.out.println(mesaj.concat(" Harika!"));
        System.out.println(mesaj.startsWith("A"));
        System.out.println(mesaj.endsWith("l"));

        char[] karakterler=new char[7];
        mesaj.getChars(2,9,karakterler,0);
        System.out.println(karakterler);

        System.out.println(mesaj.indexOf('v'));
        System.out.println(mesaj.indexOf("ha"));
        System.out.println(mesaj.lastIndexOf("e"));

        String yeniMesaj=mesaj.replace(' ','-');
        System.out.println(yeniMesaj);

        System.out.println(mesaj.substring(2));
        System.out.println(mesaj.substring(2,5));

        for(String kelime:mesaj.split(" "))
        {
            System.out.println(kelime);
        }

        System.out.println(mesaj.toLowerCase());
        System.out.println(mesaj.toUpperCase());

        System.out.println(mesaj.trim());
    }
}