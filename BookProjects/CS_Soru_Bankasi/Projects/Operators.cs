class Operators
{
    #region Arithmetic Operators
    // Write the codes computing sum, subtraction, multiplication, division and mode of two numbers entered by user
    public static void Question1()
    {
        Console.Write("Bir sayı giriniz: ");
        int number1=int.Parse(Console.ReadLine());
        Console.Write("Bir sayı giriniz: ");
        int number2=int.Parse(Console.ReadLine());
        int sum=number1+number2;
        Console.WriteLine("{0} + {1} = {2}",number1,number2,sum);
        int subtraction=number1-number2;
        Console.WriteLine("{0} - {1} = {2}",number1,number2,subtraction);
        int multiplication=number1*number2;
        Console.WriteLine("{0} x {1} = {2}",number1,number2,multiplication);
        double division=(double)number1/(double)number2;
        Console.WriteLine("{0} / {1} = {2}",number1,number2,division);
        int mode=number1%number2;
        Console.WriteLine("{0} % {1} = {2} ",number1,number2,mode);
    }

    // Write the codes computing the average of four numbers entered by user
    public static void Question2()
    {
        Console.Write("1. sayıyı giriniz: ");
        int number1=int.Parse(Console.ReadLine());
        Console.Write("2. sayıyı giriniz: ");
        int number2=int.Parse(Console.ReadLine());
        Console.Write("3. sayıyı giriniz: ");
        int number3=int.Parse(Console.ReadLine());
        Console.Write("4. sayıyı giriniz: ");
        int number4=int.Parse(Console.ReadLine());
        double average=((double)(number1+number2+number3+number4)/4);
        Console.Write("({0} + {1} + {2} + {3}) / 4 = {4}",number1,number2,number3,number4,average);
    }

    // Write the codes computing area and circumference of a triangle whose perpendicular edges entered by user
    public static void Question3()
    {
        Console.Write("1. kısa kenarı giriniz: ");
        int firstEdge=int.Parse(Console.ReadLine());
        Console.Write("2. kısa kenarı giriniz: ");
        int secondEdge=int.Parse(Console.ReadLine());
        int areaTriangle=firstEdge*secondEdge/2;
        double thirdEdge=Math.Sqrt(Math.Pow(firstEdge,2)+Math.Pow(secondEdge,2));
        double circumferenceTriangle=(double)firstEdge+(double)secondEdge+thirdEdge;
        Console.WriteLine($"Üçgenin Alanı: {areaTriangle}");
        Console.WriteLine($"Üçgenin Çevresi: {circumferenceTriangle}");
    }

    // Write the codes computing area and circumference of a circle whose radius entered by user
    public static void Question4()
    {
        Console.Write("Çemberin yarıçapını giriniz: ");
        double radius=double.Parse(Console.ReadLine());
        double circleCircumference=2*Math.PI*radius;
        double circleArea=Math.PI*radius*radius;
        Console.WriteLine($"Çemberin Çevresi: {circleCircumference:F2}");
        Console.WriteLine($"Çemberin Alanı: {circleArea:F2}");
    }

    // Write the codes computing the amount of Dollars and Euros based on their exchange rates and TL amount entered by user
    public static void Question5()
    {
        Console.Write("TL cinsinden para miktarı giriniz: ");
        double moneyAmountTL=double.Parse(Console.ReadLine());
        Console.Write("Euro kurunu giriniz: ");
        double rateEuro=double.Parse(Console.ReadLine());
        Console.Write("Dolar kurunu giriniz: ");
        double rateDollar=double.Parse(Console.ReadLine());
        double moneyAmountEuro=moneyAmountTL/rateEuro;
        double moneyAmountDollar=moneyAmountTL/rateDollar;
        Console.WriteLine($"{moneyAmountTL} TL = {moneyAmountEuro:F2} Euro");
        Console.WriteLine($"{moneyAmountTL} TL = {moneyAmountDollar:F2} Dolar");
    }
    #endregion

    #region Transfer Operators
    // Write the codes computing the sum, the multiplication and the mode of the numbers entered by user using abbraviated 
    // transfer operators
    public static void Question6()
    {
        Console.Write("Bir sayı giriniz: ");
        int number1=int.Parse(Console.ReadLine());
        Console.Write("Bir sayı giriniz: ");
        int number2=int.Parse(Console.ReadLine());
        number2+=number1;
        Console.WriteLine($"Girilen sayıların toplamı: {number2}");

        Console.Write("Bir sayı giriniz: ");
        int number3=int.Parse(Console.ReadLine());
        Console.Write("Bir sayı giriniz: ");
        int number4=int.Parse(Console.ReadLine());
        number4*=number3;
        Console.WriteLine($"Girilen sayıların çarpımı: {number4}");

        Console.Write("Bir sayı giriniz: ");
        int number5=int.Parse(Console.ReadLine());
        Console.Write("Bir sayı giriniz: ");
        int number6=int.Parse(Console.ReadLine());
        number5%=number6;
        Console.WriteLine($"Girilen sayıların modu: {number5}");
    }

    // Find the output of the code block below
    public static void Question7()
    {
        int d, e, f;
        d = 90;
        e = 34;
        d++;
        ++d;
        Console.WriteLine("d'nin başlangıç değeri: 90");
        Console.WriteLine("d++ ve ++d işleminden sonra d'nin değeri: {0}", d);
        e--;
        --e;
        Console.WriteLine("e'nin başlangıç değeri: 34");
        Console.WriteLine("e-- ve --e işleminden sonra e'nin değeri: {0}", e);
        f = ++d - e;
        Console.WriteLine("f = ++d - e işleminden sonra");
        Console.WriteLine("d değeri: {0}", d);
        Console.WriteLine("f değeri: {0}", f);
        f = d++ - e;
        Console.WriteLine("f = d++ - e işleminden sonra");
        Console.WriteLine("d değeri: {0}", d);
        Console.WriteLine("f değeri: {0}", f);
    }
    #endregion 

    #region Bitwise Operators
    // Write the codes finding the bitwise results for two numbers using AND, OR, XOR logic operators
    public static void Question8()
    {
        Console.Write("Bir sayı giriniz: ");
        int number1=int.Parse(Console.ReadLine());
        Console.Write("Bir sayı giriniz: ");
        int number2=int.Parse(Console.ReadLine());
        Console.WriteLine("AND: {0}",number1&number2);
        Console.WriteLine("OR: {0}",number1|number2);
        Console.WriteLine("XOR: {0}",number1^number2);
    }

    // Write the codes finding results obtained by using the right 3 and left 4 bit shift operators for the sum of two numbers
    public static void Question9()
    {
        Console.Write("Bir sayı giriniz: ");
        int number1=int.Parse(Console.ReadLine());
        Console.Write("Bir sayı giriniz: ");
        int number2=int.Parse(Console.ReadLine());
        int sum=number1+number2;
        Console.WriteLine("Sağa 3 bit kaydırılınca toplam değeri: {0}",(sum>>3));
        Console.WriteLine("Sola 4 bit kaydırılınca toplam değeri: {0}",(sum<<4));
    }
    #endregion
}