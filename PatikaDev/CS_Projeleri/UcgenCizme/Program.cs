using UcgenCizme;

internal class Program
{
    private static void Main(string[] args)
    {
        
        while(true)
        {
            Console.WriteLine("Üçgen için boyut değeri giriniz: ");
            int boyut = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Ucgen ucgen = new Ucgen();
            if(!ucgen.BoyutKontrol(boyut))
            {
                continue;
            }
            Console.WriteLine("Üçgen");
            ucgen.UcgenCiz(boyut);
            break;
        }
    }

    
}