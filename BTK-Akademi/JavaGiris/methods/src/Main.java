public class Main {
    public static void main(String[] args)
    {
        SayiBulma();
    }

    public static void SayiBulma()
    {
        int[] numbers=new int[]{1,2,5,7,9,0};
        int lookFor =6;
        boolean isThere=false;

        for(int number:numbers)
        {
            if(number==lookFor)
            {
                isThere=true;
                break;
            }
        }

        if(isThere)
        {
            MesajVer(lookFor + " sayısı dizide mevcut.");
        }
        else
        {
            MesajVer(lookFor + " sayısı dizide mevcut değildir.");
        }
    }

    public static void MesajVer(String mesaj)
    {
        System.out.println(mesaj);
    }
}