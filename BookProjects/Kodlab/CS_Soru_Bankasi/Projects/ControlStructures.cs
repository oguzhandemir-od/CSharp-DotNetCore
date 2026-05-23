class ControlStructes
{
    #region If Structure
    // Write the codes finding if the entered number is 10 or less than 10 or greater than 10 using if command
    public static void Question1()
    {
        Console.Write("Bir sayı giriniz: ");
        int number=int.Parse(Console.ReadLine());
        if(number<10)
        {
            Console.WriteLine("10'dan küçük bir sayı girildi");
        }
        else if(number==10)
        {
            Console.WriteLine("10 sayısı girildi");
        }
        else
        {
            Console.WriteLine("10'dan büyük bir sayı girildi");
        }
    }

    // Write the codes finding whether the input value is a letter or a number or a special character using if command
    public static void Question2()
    {
        Console.Write("Bir tuşa basınız: ");
        char input=Convert.ToChar(Console.ReadLine());

        if((input>='a'&&input<='z')||(input>='A'&&input<='Z'))
        {
            Console.WriteLine("Bir harfe basıldı.");
        }
        if(input>='0'&&input<='9')
        {
            Console.WriteLine("Bir rakama basıldı.");
        }
        if(!((input>='a'&&input<='z')||(input>='A'&&input<='Z')
        ||(input>='0'&&input<='9')))
        {
            Console.WriteLine("Özel karaktere basıldı.");
        }
    }

    // Write the codes finding the minimum number between the three numbers entered by user, using if command
    public static void Question3()
    {
        int minNumber,newNumber;
        Console.Write("Bir sayı giriniz: ");
        minNumber=int.Parse(Console.ReadLine());
        Console.Write("Bir sayı giriniz: ");
        newNumber=int.Parse(Console.ReadLine());
        if(newNumber<minNumber)
        {
            minNumber=newNumber;
        }
        Console.Write("Bir sayı giriniz: ");
        newNumber=int.Parse(Console.ReadLine());
        if(newNumber<minNumber)
        {
            minNumber=newNumber;
        }
        Console.WriteLine($"Girilen en küçük sayı: {minNumber}");
    }

    // Write the codes finding whether the pressed key is lower case or UPPER CASE with if-else commands
    public static void Question4()
    {
        Console.Write("Bir harf tuşuna basınız: ");
        char letter=Convert.ToChar(Console.ReadLine());
        if(letter>='a'&&letter<='z')
        {
            Console.WriteLine("küçük harf");
        }
        else
        {
            Console.WriteLine("BÜYÜK HARF");
        }
    }

    // Write the codes finding whether the number entered is odd or even, using if command
    public static void Question5()
    {
        Console.Write("Bir sayı giriniz: ");
        int number=int.Parse(Console.ReadLine());
        if((number%2)==0)
        {
            Console.WriteLine("Girilen sayı çifttir.");
        }
        else
        {
            Console.WriteLine("Girilen sayı tektir.");
        }
    }

    // Write the codes computing the roots of a quadratic equation using if-else command
    public static void Question6()
    {
        Console.WriteLine("ax2 + bx + c denklemi için,");
        Console.Write("a katsayısını giriniz: ");
        int aFactor=int.Parse(Console.ReadLine());
        Console.Write("b katsayısını giriniz: ");
        int bFactor=int.Parse(Console.ReadLine());
        Console.Write("c sayısını giriniz: ");
        int cFactor=int.Parse(Console.ReadLine());

        double delta=(bFactor*bFactor)-(4*aFactor*cFactor);
        if(delta>0)
        {
            double rootOne=(-bFactor+Math.Sqrt(delta))/(2*aFactor);
            double rootTwo=(-bFactor-Math.Sqrt(delta))/(2*aFactor);
            Console.WriteLine($"1. Kök: {rootOne}");
            Console.WriteLine($"2. Kök: {rootTwo}");
        }
        else if(delta==0)
        {
            double rootOnly=-bFactor/(2*aFactor);
            Console.WriteLine($"Tek Kök: {rootOnly}");
        }
        else
        {
            Console.WriteLine("Reel kök yoktur");
        }
    }

    // Write the program codes approving the applications of the applicants who are men, done the military service
    // And equal or less than 30, after receive the gender, military service and age information,
    // Using if-else command
    public static void Question7()
    {
        Console.WriteLine("Başvuran kişinin cinsiyeti");
        Console.Write("Erkek için (e), bayan için (b): ");
        char applicantGender=Convert.ToChar(Console.ReadLine());
        if(applicantGender=='b')
        {
            Console.WriteLine("Yalnızca erkek personel işe alınacaktır.");
        }
        else if(applicantGender=='e')
        {
            Console.WriteLine("Askerlik durumunu giriniz");
            Console.Write("Yapıldı ise (e), yapılmadı ise (h): ");
            char serviceDone=Convert.ToChar(Console.ReadLine());
            if(serviceDone=='h')
            {
                Console.WriteLine("Askerliğini yapmış personel işe alınacaktır.");
            }
            else if(serviceDone=='e')
            {
                Console.Write("Yaşınız: ");
                int age=int.Parse(Console.ReadLine());
                if(age<=30)
                {
                    Console.WriteLine("İşe alındınız");
                }
                else
                    Console.WriteLine("Yaşınız 30 veya daha küçük olmalıdır.");
            }
        }
    }
    #endregion

    #region Ternary Operator
    // Write the codes controlling whether the number entered by user is less than 10, using ternary operator
    public static void Question8()
    {
        Console.Write("Lütfen 10'dan küçük bir sayı giriniz: ");
        int number=int.Parse(Console.ReadLine());
        Console.WriteLine(number<10?"Sayı girişi kabul edildi":"Sayı girişi kabul edilmedi");
    }
    #endregion

    #region Switch-Case
    // Write the program "I love you" on screen in the selected language using switch-case method
    public static void Question9()
    {
        Console.WriteLine("DİLLER");
        Console.WriteLine("1- Türkçe");
        Console.WriteLine("2- English");
        Console.WriteLine("3- Deutschland");
        Console.WriteLine("4- la France");
        Console.Write("Seçiminiz: ");
        string selection=Console.ReadLine();

        switch (selection)
        {
            case "1":
            Console.WriteLine("Seni seviyorum");
            break;
            case "2":
            Console.WriteLine("I love you");
            break;
            case "3":
            Console.WriteLine("Ich liebe dich");
            break;
            case "4":
            Console.WriteLine("Je t'aime");
            break;
            default:
            Console.WriteLine("Geçersiz giriş");
            break;
        }
    }

    // Write the codes finding the season based on the month name entered by user, using switch-case method
    public static void Question10()
    {
        Console.Write("Bulunduğunuz ay ismini yazınız: ");
        string month = Console.ReadLine().ToLower();

        switch (month)
        {
            case "aralık":
            case "ocak":
            case "şubat":
                Console.WriteLine("Kış Mevsimi");
                break;
            case "mart":
            case "nisan":
            case "mayıs":
                Console.WriteLine("İlkbahar Mevsimi");
                break;
            case "haziran":
            case "temmuz":
            case "ağustos":
                Console.WriteLine("Yaz Mevsimi");
                break;
            case "eylül":
            case "ekim":
            case "kasım":
                Console.WriteLine("Sonbahar Mevsimi");
                break;
            default:
                Console.WriteLine("Geçersiz giriş");
                break;
        }
    }

    // Write the codes calculating of the result after entering two numbers and one of simple four operations (+ - * /)
    // Use switch-case method
    public static void Question11()
    {
        Console.Write("Sayıları ve işlemi giriniz: (3 4 *): ");
        int number1=int.Parse(Console.ReadLine());
        int number2=int.Parse(Console.ReadLine());
        char operation=Convert.ToChar(Console.ReadLine());
        int result;
        switch (operation)
        {
            case '+':
            result=number1+number2;
            Console.WriteLine($"{number1} {operation} {number2} = {result}");
            break;
            case '-':
            result=number1-number2;
            Console.WriteLine($"{number1} {operation} {number2} = {result}");
            break;
            case '*':
            result=number1*number2;
            Console.WriteLine($"{number1} {operation} {number2} = {result}");
            break;
            case '/':
            result=number1/number2;
            Console.WriteLine($"{number1} {operation} {number2} = {result}");
            break;
            default:
            Console.WriteLine("Geçersiz işlem!");
            break;            
        }
    }

    // Write the codes finding the day based on the date entered by user in day/month/year format using switch-case method
    public static void Question12()
    {
        Console.WriteLine("Gün/Ay/Yıl olarak tarih değerini giriniz (24/10/1976): ");
        Console.Write("Gün: ");
        int day = int.Parse(Console.ReadLine());
        Console.Write("Ay: ");
        int month = int.Parse(Console.ReadLine());
        Console.Write("Yıl: ");
        int year = int.Parse(Console.ReadLine());
        int monthDays = 0;
        int totalDays = 0;
        string dayName = "Pazar";

        switch (month)
        {
            case 1:
                monthDays = 0;
                break;
            case 2:
                monthDays = 31;
                break;
            case 3:
                monthDays = 59;
                break;
            case 4:
                monthDays = 90;
                break;
            case 5:
                monthDays = 120;
                break;
            case 6:
                monthDays = 151;
                break;
            case 7:
                monthDays = 181;
                break;
            case 8:
                monthDays = 212;
                break;
            case 9:
                monthDays = 243;
                break;
            case 10:
                monthDays = 273;
                break;
            case 11:
                monthDays = 304;
                break;
            case 12:
                monthDays = 334;
                break;
        }

        
        totalDays = (year - 1) * 365 + year / 4 + monthDays + day;
        int mode = totalDays % 7;

        switch (mode)
        {
            
            case 0:
                dayName = "Pazartesi";
                break;
            case 1:
                dayName = "Salı";
                break;
            case 2:
                dayName = "Çarşamba";
                break;
            case 3:
                dayName = "Perşembe";
                break;
            case 4:
                dayName = "Cuma";
                break;
            case 5:
                dayName = "Cumartesi";
                break;
                case 6:
                dayName = "Pazar";
                break;
        }

        Console.WriteLine($"{day}/{month}/{year} tarihi {dayName} günüdür");
    }
    #endregion

    #region Loops - For Loop
    // Write the codes that type "Kodlab" on screen for 10 times using for command
    public static void Question13()
    {
        for(int i=0;i<10;i++)
        {
            Console.WriteLine($"{i} Kodlab");
        }
    }

    // Write the codes calculating the total of even numbers and the total of odd numbers between 0-20, using for command
    public static void Question14()
    {
        int evenTotal=0;
        int oddTotal=0;
        for(int i=0;i<=20;i++)
        {
            if(i%2==0)
                evenTotal+=i;
            else
                oddTotal+=i;
        }
        Console.WriteLine($"Çift sayıların toplamı: {evenTotal}");
        Console.WriteLine($"Tek sayıların toplamı: {oddTotal}");
    }

    // Write the codes calculating the total and average of the 16 numbers entered by user, using for command
    public static void Question15()
    {
        int total=0;
        int average=0;
        for(int i=1;i<=16;i++)
        {
            Console.Write($"{i}. sayıyı giriniz: ");
            int number=int.Parse(Console.ReadLine());
            total+=number;
        }
        average=total/16;
        Console.WriteLine($"Sayıların toplamı: {total}");
        Console.WriteLine($"Sayıların ortalaması: {average}");
    }

    // Write the codes generating random numbers between 1-100 and typing them on screen, using for command
    public static void Question16()
    {
        int number;
        for(int i=1;i<=10;i++)
        {
            Random rnd=new Random();
            number = rnd.Next(1,101);
            Console.WriteLine($"{i}. sayı: {number}");
        }
    }

    // Write the codes that types the even numbers between two numbers entered by user
    // Use continue command and for loop
    public static void Question17()
    {
        Console.Write("Bir sayı giriniz: ");
        int number1=int.Parse(Console.ReadLine());
        Console.Write("Bir sayı giriniz: ");
        int number2=int.Parse(Console.ReadLine());
        for(int i=number1;i<=number2;i++)
        {
            if(i%2!=0)
                continue;
            Console.WriteLine(i);
        }
    }

    // Write the codes generating random decimal numbers between 10-20 and typing on screen
    // Use for command
    public static void Question18()
    {
         Random rnd=new Random();
        double number;
        for(int i=1;i<=10;i++)
        {
            number = rnd.Next(1000,2001);
            number/=100;
            Console.WriteLine($"{i}. sayı: {number}");
        }
    }

    // Write the codes generating 7 digits password through the characters inside an array
    // Use for command
    public static void Question19()
    {
        Random rnd = new Random();
        char[] keys = { 'A', 'B', 'C', 'k', 'o', 'n', 'v', '#', 'a', 'b', 'c', '6', '7', '8', '&', '?', '.', '!' };
        for (int i = 1; i <= 7; i++)
        {
            int key = rnd.Next(0, 18);
            Console.Write(keys[key] + " ");
        }
    }

    // Write the codes that types the result of 5 matches played between Fenerbahçe and Galatasaray on screen
    // Use for command
    public static void Question20()
    {
        int scoreFenerbahce,scoreGalatasaray,totalFenerbahce=0,totalGalatasaray=0;
        Random rnd=new Random();
        for(int i=1;i<=5;i++)
        {
            scoreFenerbahce=rnd.Next(0,6);
            scoreGalatasaray=rnd.Next(0,6);
            if(scoreFenerbahce>scoreGalatasaray)
                totalFenerbahce++;
            else if(scoreFenerbahce<scoreGalatasaray)
                totalGalatasaray++;
            Console.WriteLine($"Fenerbahçe: {scoreFenerbahce} - Galatasaray: {scoreGalatasaray}");
        }
        if(totalFenerbahce>totalGalatasaray)
            Console.WriteLine($"Kazanan takım {totalFenerbahce} maç ile Fenerbahçe");
        else
            Console.WriteLine($"Kazanan takım {totalGalatasaray} maç ile Galatasaray");
    }

    // Write the codes for finding game of a random number computer keeps between 1-100
    // Use for command
    public static void Question21()
    {
        Random rnd = new Random();
        int theNumber = rnd.Next(1, 101);
        int input = 0;
        for (int i = 1; i <= 5; i++)
        {
            Console.Write("Bir sayı giriniz: ");
            input = int.Parse(Console.ReadLine());
            if (input > theNumber)
            {
                if (i == 5)
                    break;
                Console.WriteLine("Sayıyı KÜÇÜLT");
            }
            if (input < theNumber)
            {
                if (i == 5)
                    break;
                Console.WriteLine("Sayıyı BÜYÜT");
            }
            if (input == theNumber)
            {
                Console.WriteLine($"{i}. hakkınızda buldunuz");
                break;
            }
        }
        if (input != theNumber)
            Console.WriteLine("Bulamadınız");
    }

    // Write the codes calculating the sum and average of the numbers input until zero (0) entered
    // Use for command
    public static void Question22()
    {
        int loop=0;
        double number,total=0,average;
        for(;;)
        {
            Console.Write("Sayı giriniz: ");
            number=double.Parse(Console.ReadLine());
            if(number==0)
                break;
            total+=number;
            loop++;
        }
        average=total/loop;
        Console.WriteLine($"Sayıların toplamı: {total}");
        Console.WriteLine($"Sayıların ortalaması: {average:F2}");
    }

    // Write the codes converting a decimal entered by user to a binary, using for command
    public static void Question23()
    {
        Console.Write("10 tabanında bir sayı giriniz: ");
        int number=int.Parse(Console.ReadLine());
        int division=number;
        string binaryNumber="";

        for(;;)
        {
            binaryNumber=(division%2).ToString()+binaryNumber;
            division=division/2;
            if(division<2)
            {
                binaryNumber=division.ToString()+binaryNumber;
                break;
            }  
        }
        Console.WriteLine($"Sayının 2 tabanında karşılığı: {binaryNumber}");
    }    
    #endregion

    #region Loops - Foreach Loop
    // Write the codes calculating the sum and average of the grades students receive in the programming fundementals course,
    // In a class of 10 students
    // Use foreach command
    public static void Question24()
    {
        int[] scores={65,32,98,100,24,34,52,100,38,69};
        int totalScore=0;
        int average;
        int loop=0;
        foreach(int s in scores)
        {
            totalScore+=s;
            loop++;
        }
        average=totalScore/loop;
        
        Console.WriteLine($"Notların Toplamı: {totalScore}");
        Console.WriteLine($"Notların Ortalaması: {average}");
    }
    #endregion

    #region Loops - While Loop
    // Write the codes that type the table of multiplication for 7, using while command
    public static void Question25()
    {
        int factor=1;
        while(factor<11)
        {
            Console.WriteLine($"7 x {factor} = {7*factor}");
            factor++;
        }
    }

    // Write the codes that type the entered number and its square until zero (0) is entered
    // Use while command
    public static void Question26()
    {
        while(true)
        {
            Console.Write("Bir sayı giriniz: ");
            int number=int.Parse(Console.ReadLine());
            if(number==0)
                break;
            Console.WriteLine($"Sayı: {number} Karesi: {number*number}");
        }
    }

    // Write the codes calculating the sum of numbers between 1-100
    // Use while command
    public static void Question27()
    {
        int number=1,total=0;
        while(number<=100)
        {
            total+=number;
            number++;
        }        
        Console.WriteLine($"1-100 arasındaki sayıların toplamı: {total}");
    }

    // Write the codes calculating the sum of number between two numbers entered on keyboard
    // Use while command
    public static void Question28()
    {
        Console.Write("1. sayıyı giriniz: ");
        int number1=int.Parse(Console.ReadLine());
        Console.Write("2. sayıyı giriniz: ");
        int number2=int.Parse(Console.ReadLine());
        int total=number1;

        if(number1==number2)
            total=0;
        
        while(number1!=number2)
        {
            if(number1<number2)
                number1++;
            else if(number1>number2)
                number1--;
            total+=number1;
        }
        Console.WriteLine($"Sayıların Toplamı: {total}");
    }

    // Write the codes calculating the factorial of the entered number on keyboard
    // Use while command
    public static void Question29()
    {
        Console.Write("Bir sayı giriniz: ");
        int number = int.Parse(Console.ReadLine());
        int factorial = 1;

        if (number < 0)
        {
            Console.WriteLine("Negatif sayıların faktöriyeli olmaz.");
        }
        else if (number == 0)
            Console.WriteLine("0 sayısının faktöriyeli = 1");
        else
        {
            int decreasedNumber=number;
            while (decreasedNumber > 0)
            {
                factorial *= decreasedNumber;
                decreasedNumber--;
            }
            Console.WriteLine($"{number} sayısının faktöriyeli = {factorial}");
        }
    }

    // Write the codes calculation the multiplication of two numbers entered on keyboard 
    // using only summing and subtraction operations
    // Use while command
    public static void Question30()
    {
        Console.Write("Bir sayı giriniz: ");
        int number1=int.Parse(Console.ReadLine());
        Console.Write("Bir sayı giriniz: ");
        int number2=int.Parse(Console.ReadLine());

        int result=0;

        while(number2!=0)
        {
            result+=number1;
            number2--;
        }
        if(number2<0)
            result=-result;
        
        Console.WriteLine($"Sayıların çarpımı = {result}");
    }
    #endregion

    #region Loops - Do While Loop
    // Write the codes that types the number itself, square of it and cube of it between the numbers 1-10
    // Use do-while command
    public static void Question31()
    {
        Console.WriteLine("Sayı     Karesi  Küpü");
        Console.WriteLine("-----------------");
        int number=0;
        
        do
        {
            number++;
            Console.WriteLine($"{number}    {number*number}     {number*number*number}");
        } while (number<10);
    }

    // Write the codes calculating the sinus, cosinus, tangent and cotangent of the angle entered on keyboard
    // Use do-while command
    public static void Question32()
    {
        char answer;
        do
        {
            Console.Write("Açı değerini giriniz: ");
        double angle=double.Parse(Console.ReadLine());
        double angleRadian=angle*Math.PI/180;

        double angleSin=Math.Sin(angleRadian);
        double angleCos=Math.Cos(angleRadian);
        double angleTan=Math.Tan(angleRadian);
        double angleCot=angleCos/angleTan;

        Console.WriteLine($"{angle} açısının sinüsü: {angleSin:F2}");
        Console.WriteLine($"{angle} açısının kosinüsü: {angleCos:F2}");
        Console.WriteLine($"{angle} açısının tanjantı: {angleTan:F2}");
        Console.WriteLine($"{angle} açısının kotanjantı: {angleCot:F2}");

        Console.Write("Devam edecek misiniz? (e/h): ");
        answer=char.Parse(Console.ReadLine());
        } while (answer=='e' || answer=='E');
    }

    // Write the codes calculating the logarithms of the numbers between 1-10
    // Use do-while command
    public static void Question33()
    {
        int number = 0;
        do
        {
            number++;
            double numberLog=Math.Log10(number);
            Console.WriteLine($"{number} 10 tabanında logaritması: {numberLog:F2}");

        } while (number < 10);
    }

    // Write the codes finding how many 3-digits number among 10 numbers entered on keyboard
    // Use do-while command
    public static void Question34()
    {
        int place=0,counter=0;
        do
        {
            place++;
            Console.Write($"{place}. sayıyı giriniz: ");
            int number=int.Parse(Console.ReadLine());

            if((number>=-999 && number <=-100) || (number>=100 && number <=999))
                counter++;

        } while (place<10);

        Console.WriteLine($"{counter} tane 3 basamaklı sayı vardır.");
    }

    // Write the codes finding the maximum number among 10 numbers entered on keyboard
    // Use do-while command
    public static void Question35()
    {
        int maxNumber=0,place=0;
        do
        {
            place++;
            Console.Write($"{place}. sayıyı giriniz: ");
            int number=int.Parse(Console.ReadLine());

            if(number>maxNumber)
                maxNumber=number;
        } while (place<10);

        Console.WriteLine($"Girilen en büyük sayı {maxNumber}");
    }

    // Write the codes calculating the result of 1-2+3-4+5-6...n expression according to n value
    // Use do-while command
    public static void Question36()
    {
        int number = 0;
        Console.Write("Bir sayı değeri giriniz: ");
        int n = int.Parse(Console.ReadLine());
        int total = 0;
        string equation = "";
        do
        {
            number++;
            if (number % 2 == 0)
            {
                total += -number;
                equation = equation + "-" + number.ToString();
            }
            else if(number==1)
            {
                equation=equation+number.ToString();
                total +=1;
            }
            else
            {
                total += number;
                equation = equation + "+" + number.ToString();
            }

        } while (number < n);

        Console.WriteLine($"{equation} = {total}");
    }

    // Write the codes finding how many numbers between 1-200 are divisible by both 3 and 10
    // Use do-while command
    public static void Question37()
    {
        int number=0,total=0,counter=0;
        do
        {
            number++;
            if(number%3==0 && number%10==0)
                {
                    total+=number;
                    counter++;
                }
        } while (number<2000);

        Console.WriteLine($"Sayısı: {counter}");
        Console.WriteLine($"Toplamı: {total}");
    }
    #endregion
}