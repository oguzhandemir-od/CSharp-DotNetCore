import java.util.ArrayList;

public class Main {
    public static void main(String[] args) {
        ArrayList sayilar=new ArrayList();
        sayilar.add(1);
        sayilar.add(10);
        sayilar.add("Ankara");
//        System.out.println(sayilar.size());
//        System.out.println(sayilar.get(2));
//        sayilar.set(1,5);
//        sayilar.remove(0);
//        sayilar.clear();

        for(Object eleman:sayilar)
        {
            System.out.println(eleman);
        }
    }
}