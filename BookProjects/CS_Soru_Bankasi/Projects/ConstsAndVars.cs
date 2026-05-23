class ConstsAndVars
{
    #region Constants
    // As adult ticket prices 10 TL, student ticket prices 7 TL for a theatre; find the total price a family with 3 kids has to pay
    // Prices of tickets must be "constants" in codes
    public static void Question1()
    {
        const int adultTicket=10,studentTicket=7;
        int atNumber,stNumber,total;
        Console.Write("Yetişkin bilet sayısı: ");
        atNumber=int.Parse(Console.ReadLine());
        Console.Write("Öğrenci bilet sayısı: ");
        stNumber=int.Parse(Console.ReadLine());
        total=(atNumber*adultTicket)+(stNumber*studentTicket);
        Console.Write("Toplam tutar: {0} TL",total);
    }
    #endregion

    #region Variable Types
    // Assign values to Short, Sbyte, Int, Decimal, String, Double, Char, Bool and Float variable types
    // Write these values on screen top and bottom
    public static void Question2()
    {
        short shortVar=125;
        sbyte sbyteVar=-25;
        int integerVar=54786;
        decimal decimalVar=123.45m;
        string stringVar="Kitap";
        double doubleVar=456678;
        char charVar='&';
        bool booleanVar=true;
        float floatVar=-2541.78f;
        Console.WriteLine("Short {0}",shortVar);
        Console.WriteLine("SByte {0}",sbyteVar);
        Console.WriteLine("Integer {0}",integerVar);
        Console.WriteLine("Decimal {0}",decimalVar);
        Console.WriteLine("String {0}",stringVar);
        Console.WriteLine("Double {0}",doubleVar);
        Console.WriteLine("Char {0}",charVar);
        Console.WriteLine("Boolean {0}",booleanVar);
        Console.WriteLine("Float {0}",floatVar);
    }
    #endregion

    #region Variable Types According To Places They Are Defined
    // Write the codes finding the multiplication of global variable 'g' and local variable 'y'
    public static int g=32;
    public static void Question3()
    {
        int y=15;
        int result=g*y;
        Console.WriteLine("Genel ve yerel değişkenlerin çarpımı: {0}", result);
    }
    #endregion

    #region User-Defined Data Types - Creating Enums and Accessing the Elements in Enums

    // After defining the month names in year as Enum, write the codes finding the name of the month 
    // user enters as number
    public static void Question4()
    {
        Console.Write("Ay için sayısal değer giriniz: ");
        int month=int.Parse(Console.ReadLine());
        Months monthName=(Months) month-1;
        Console.WriteLine("{0} ayı yılın {1}. ayıdır.",monthName,month);
    }

    public enum Months
    {
        Ocak,Şubat,Mart,
        Nisan,Mayıs,Haziran,
        Temmuz,Ağustos,Eylül,
        Ekim,Kasım,Aralık
    }
    #endregion

    #region Learning Variable Types
    // Write the codes finding the types of variables we use through GetType method
    public static void Question5()
    {
        int integerVar=54786;
        decimal decimalVar=123.45m;
        string stringVar="Kitap";
        bool booleanVar=true;

        Console.WriteLine("{0} değerindeki değişkenin tipi: {1}",integerVar,integerVar.GetType());
        Console.WriteLine("{0} değerindeki değişkenin tipi: {1}",decimalVar,decimalVar.GetType());
        Console.WriteLine("{0} değerindeki değişkenin tipi: {1}",stringVar,stringVar.GetType());
        Console.WriteLine("{0} değerindeki değişkenin tipi: {1}",booleanVar,booleanVar.GetType());
    }
    #endregion

    #region Converting Between Variable Types
    // Write the codes finding the division of two integers entered by user
    // The result must be decimal
    public static void Question6()
    {
        Console.Write("Bir sayı giriniz: ");
        int number1=int.Parse(Console.ReadLine());
        Console.Write("Bir sayı giriniz: ");
        int number2=int.Parse(Console.ReadLine());
        double result=(double)number1/(double)number2;
        Console.Write("{0} / {1} = {2}",number1,number2,result);
    }

    // Write the codes asking if the equation (15 / 3 = 5) on screen is true or false
    // According to user's answer evaulate their math sufficiency 
    public static void Question7()
    {
        Console.Write("15 / 3 = 5 ifadesi doğru mu? (true/false): ");
        bool input=Convert.ToBoolean(Console.ReadLine());
        if(input)
        {
            Console.Write("Matematik bilginiz iyi.");
        }
        else
        {
            Console.Write("Matematik dersine çalışmalısınız.");
        }
    }

    // Write the codes finding the gender value according to the gender information entered by user
    // (e for Men, k for Women)
    public static void Question8()
    {
        Console.Write("Cinsiyet bilgisini giriniz (e / k): ");
        char genderInfo=Convert.ToChar(Console.ReadLine());
        if(genderInfo=='e')
        {
            Console.Write("Erkek bilgisi girildi");
        }
        if(genderInfo=='k')
        {
            Console.Write("Kadın bilgisi girildi");
        }
    }
    #endregion
}