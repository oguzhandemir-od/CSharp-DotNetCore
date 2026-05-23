using OrtalamaHesaplama;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Fibonacci Serisi Ortalama Hesaplama");
        Console.WriteLine("***********************************");
        while(true)
        {
            Console.Write("Fibonacci serisi için bir derinlik giriniz: ");

            int derinlik = Convert.ToInt32(Console.ReadLine());
            if(!Islemler.DerinlikKontrol(derinlik))
            {
                continue;
            }
            
            Fibonacci fibo = new Fibonacci(derinlik);
            int[] fiboSeri = fibo.FibonacciSerisi(derinlik);
            Console.Write($"Fibonacci Serisi (Derinlik {derinlik}): ");
            Islemler.SeriYazdir(fiboSeri);
            Console.WriteLine($"\nSeri Ortalaması: {fibo.FibonacciOrtalama(fiboSeri):F2}");
            break;
        }
        
        
    }
}