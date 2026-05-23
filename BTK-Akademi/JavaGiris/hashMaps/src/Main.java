import java.util.HashMap;

public class Main {
    public static void main(String[] args) {
        HashMap<String,String> sozluk=new HashMap<String,String>();

        sozluk.put("Book","Kitap");
        sozluk.put("Table","Masa");
        sozluk.put("Computer","Bilgisayar");
        System.out.println(sozluk.size());

        for(String item:sozluk.keySet())
        {
            System.out.println("Eleman-"+item+" Değer-"+sozluk.get(item));
        }


        sozluk.remove("Table");

        System.out.println(sozluk);
        System.out.println(sozluk.get("Book"));
    }
}