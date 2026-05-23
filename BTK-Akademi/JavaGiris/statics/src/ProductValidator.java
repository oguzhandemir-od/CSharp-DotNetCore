public class ProductValidator {
    static{
        System.out.println("Statik yapıcı blok çalıştı.");
    }

    public ProductValidator()
    {
        System.out.println("Yapıcı blok çalıştı.");
    }

    public static boolean IsValid(Product product)
    {
        if(product.price>0 && !product.name.isEmpty())
        {
            return true;
        }
        else
            return false;

    }


}
