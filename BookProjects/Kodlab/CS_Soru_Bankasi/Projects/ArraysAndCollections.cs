class ArraysAndCollections
{
    
    #region Arrays - One-Dimensional Arrays
    // Write the codes finding the maximum number among 17 numbers entered on keyboard
    // Use arrays
    public static void Question1()
    {
        int[] numbers=new int[17];
        for(int i=0;i<17;i++)
        {
            Console.Write($"{i+1}.sayıyı giriniz: ");
            numbers[i]=int.Parse(Console.ReadLine());            
        }
        int maxNumber=numbers[0];
        for(int i=0;i<17;i++)
        {
            if(numbers[i]>maxNumber)
                maxNumber=numbers[i];
        }

        Console.WriteLine($"En Büyük Sayı: {maxNumber}");
    }

    // Write the codes sorting 5 numbers entered from the keyboard in descending order
    // Use arrays
    public static void Question2()
    {
        int[] numbers=new int[5];
        for(int i=0;i<5;i++)
        {
            Console.Write($"{i+1}. sayıyı giriniz: ");
            numbers[i]=int.Parse(Console.ReadLine());
        }
        
        int temp;

        for(int i=0;i<5;i++)
        {
            for(int j=i+1;j<5;j++)
            {
                if(numbers[i]<numbers[j])
                {
                    temp=numbers[i];
                    numbers[i]=numbers[j];
                    numbers[j]=temp;
                }
            }
        }

        for(int i=0;i<5;i++)
        {
            Console.WriteLine($"{i+1}. sayı: {numbers[i]}");
        }
    }

    // Write the codes sorting 5 names entered from the keyboard in alphebetical order
    // Use arrays
    public static void Question3()
    {
        string[] names=new string[5];

        for(int i=0; i<5;i++)
        {
            Console.Write($"{i+1}. kişinin adını giriniz: ");
            names[i] = Console.ReadLine();
        }

        string temp;

        for(int i=0; i<5;i++)
        {
            for(int j=i+1; j<5;j++)
            {
                if(string.Compare(names[i], names[j])>0)
                {
                    temp=names[i];
                    names[i]=names[j];
                    names[j]=temp;
                }
            }
        }

        Console.WriteLine("Alfabetik Sıralama");

        for(int i=0; i<5;i++)
        {
            Console.WriteLine($"{i+1}. kişinin adı: {names[i]}");
        }
    }

    // Write the codes finding that how many numbers whose last digit is 0 there are among the numbers entered from the keyboard
    // Use arrays
    public static void Question4()
    {
        int counter=0;
        int[] numbers=new int[5];

        for(int i=0; i<5;i++)
        {
            Console.Write($"{i+1}. sayıyı giriniz: ");
            numbers[i]=int.Parse(Console.ReadLine());
            if(numbers[i]%10==0)
            {
                counter++;
            }
        }

        Console.WriteLine($"Sonu 0 (sıfır) olan toplam {counter} adet sayı vardır.");
    }

    // The elements of a 10-elements array are assigned by computer between 1-1000 randomly.
    // Write the codes calculating of sum of the numbers between 500-600 in this array
    // And finding that how many numbers between 100-500 there are in this array.
    // Use arrays
    public static void Question5()
    {
        int[] numbers=new int[10];

        int total=0;
        int counter=0;

        Random rnd=new Random();

        for(int i=0;i<10;i++)
        {
            numbers[i]=rnd.Next(1,1001);

            if(numbers[i]>=500 && numbers[i]<=600)
                total+=numbers[i];
            
            if(numbers[i]>=100 && numbers[i]<500)
                counter++;
        }

        Console.WriteLine($"500-600 arasındaki sayıların toplamı: {total}");
        Console.WriteLine($"100-500 arasındaki sayıların sayısı: {counter}");
    }

    // Make a lotto game codes
    public static void Question6()
    {int temp, column;
        Random rnd = new Random();
        int[] numbers = new int[6];

        Console.Write("Kaç kolon oynamak istersiniz?: ");
        column = int.Parse(Console.ReadLine());

        if (column > 0 && column <= 8)
        {
            for(int i=1;i<=column;i++)
            {
                for(int j=0;j<6;j++)
                {
                    numbers[j]=rnd.Next(1,50);
                    
                    if(j>0)
                    {
                        for(int s=0;s<j;s++)
                        {
                            if(numbers[j]==numbers[s])
                        {
                            j--;
                        }
                        }
                    }
                    for(int k=0;k<6;k++)
                    {
                                              
                        if(numbers[j]<numbers[k])
                        {
                            temp=numbers[j];
                            numbers[j]=numbers[k];
                            numbers[k]=temp;
                        }
                    }
                }
                Console.WriteLine($"{i}. kolon");
                for(int k=0;k<6;k++)
                {
                    Console.Write($"{numbers[k]}  ");
                }
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("En az 1, en fazla 8 kolon oynayabilirsiniz.");
        }}
    #endregion

    #region Arrays - Multi Dimensional Arrays
    // 3x3 matrices as A and B are entered from the keyboard.
    // Write the codes finding whether the A and B matrices are equal to each other
    public static void Question7()
    {
        int[,] matrixA=new int[3,3];
        int[,] matrixB=new int[3,3];
        bool s=true;

        for(int i=0;i<3;i++)
        {
            for(int j=0;j<3;j++)
            {
                Console.Write($"A[{i+1},{j+1}]=");
                matrixA[i,j]=int.Parse(Console.ReadLine());
            }
        }

        for(int i=0;i<3;i++)
        {
            for(int j=0;j<3;j++)
            {
                Console.Write($"B[{i+1},{j+1}]=");
                matrixB[i,j]=int.Parse(Console.ReadLine());
            }
        }
        Console.WriteLine();
        Console.WriteLine("*** A Matrisi ***");
        for(int i=0;i<3;i++)
        {
            for(int j=0;j<3;j++)
            {
                Console.Write($"{matrixA[i,j]}  ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        Console.WriteLine("*** B Matrisi ***");
        for(int i=0;i<3;i++)
        {
            for(int j=0;j<3;j++)
            {
                Console.Write($"{matrixB[i,j]}  ");
            }
            Console.WriteLine();
        }

        for(int i=0;i<3;i++)
        {
            for(int j=0;j<3;j++)
            {
                if(matrixA[i,j]!=matrixB[i,j])
                {
                    Console.WriteLine("A ve B matrisleri eşit değildir.");
                    s=false;
                    break;
                }                
            }
        }
        if(s==true)
        {
            Console.WriteLine("Matrisler birbirine eşittir.");
        }
    }

    // 3x3 matrices as A and B are entered from the keyboard.
    // Write the codes calculating the matrix C which is the sum of matrices A and B
    public static void Question8()
    {
        int[,] matrixA=new int[3,3];
        int[,] matrixB=new int[3,3];
        int[,] matrixC=new int[3,3];

        for(int i=0;i<3;i++)
        {
            for(int j=0;j<3;j++)
            {
                Console.Write($"A[{i+1},{j+1}]=");
                matrixA[i,j]=int.Parse(Console.ReadLine());
            }
        }

        for(int i=0;i<3;i++)
        {
            for(int j=0;j<3;j++)
            {
                Console.Write($"B[{i+1},{j+1}]=");
                matrixB[i,j]=int.Parse(Console.ReadLine());
            }
        }

        for(int i=0;i<3;i++)
        {
            for(int j=0;j<3;j++)
            {
                matrixC[i,j]=matrixA[i,j]+matrixB[i,j];
            }
        }

        Console.WriteLine("*** A Matrisi ***");
        for(int i=0;i<3;i++)
        {
            for(int j=0;j<3;j++)
            {
                Console.Write($"{matrixA[i,j]}  ");
            }
            Console.WriteLine();
        }
        Console.WriteLine("*** B Matrisi ***");
        for(int i=0;i<3;i++)
        {
            for(int j=0;j<3;j++)
            {
                Console.Write($"{matrixB[i,j]}  ");
            }
            Console.WriteLine();
        }
        Console.WriteLine("*** Toplam Matrisi ***");
        for(int i=0;i<3;i++)
        {
            for(int j=0;j<3;j++)
            {
                Console.Write($"{matrixC[i,j]}  ");
            }
            Console.WriteLine();
        }
    }

    // Write the codes generating nxn unit matrix
    public static void Question9()
    {
        Console.Write("Oluşturulacak birim matrisin boyutunu giriniz: ");
        int dimension=int.Parse(Console.ReadLine());
        int[,] matrix=new int[dimension, dimension];

        Console.WriteLine($"Birim Matris {dimension}x{dimension}");

        for(int i=0; i<dimension; i++)
        {
            for(int j=0;j<dimension;j++)
            {
                if(i==j)
                    matrix[i,j]=1;
                else
                    matrix[i,j]=0;
            }
        }

        for(int i=0; i<dimension; i++)
        {
            for(int j=0;j<dimension;j++)
            {
                Console.Write($"{matrix[i,j]}  ");
            }
            Console.WriteLine();
        }
    }
    #endregion

    #region Arrays - Unordered Arrays
    // Write the codes that type an unordered list after its values entered
    public static void Question10()
    {
        int[][] unorderedArray = new int[4][];
        unorderedArray[0] = new int[5];
        unorderedArray[1] = new int[2];
        unorderedArray[2] = new int[3];
        unorderedArray[3] = new int[6];
        unorderedArray[0][3] = 15;
        unorderedArray[1][1] = 12;
        unorderedArray[2][1] = 9;
        unorderedArray[2][2] = 99;
        unorderedArray[3][0] = 10;
        unorderedArray[3][1] = 11;
        unorderedArray[3][2] = 12;
        unorderedArray[3][3] = 13;
        unorderedArray[3][4] = 14;

        for (int i = 0; i < 5; i++)
        {
            Console.Write($"{unorderedArray[0][i]}  ");
        }
        Console.WriteLine();
        for (int j = 0; j < 2; j++)
        {
            Console.Write($"{unorderedArray[1][j]}  ");
        }
        Console.WriteLine();
        for (int k = 0; k < 3; k++)
        {
            Console.Write($"{unorderedArray[2][k]}  ");
        }
        Console.WriteLine();
        for (int m = 0; m < 6; m++)
        {
            Console.Write($"{unorderedArray[3][m]}  ");
        }
    }
}