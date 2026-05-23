import java.io.*;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        ReadFile();
        WriteFile();
        ReadFile();
    }

    public static void CreateFile()
    {
        File file=new File("C:\\Users\\oğuzhan\\Documents\\Projeler\\" +
                "Yazılım-Programlama\\BTK_Akademi\\JavaGiris\\files\\students.txt");
        try {
            if(file.createNewFile())
            {
                System.out.println("Dosya oluşturuldu.");
            }
            else
            {
                System.out.println("Dosya mevcut.");
            }
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }

    public static void GetFileInfo()
    {
        File file=new File("C:\\Users\\oğuzhan\\Documents\\Projeler\\" +
                "Yazılım-Programlama\\BTK_Akademi\\JavaGiris\\files\\students.txt");
        if(file.exists())
        {
            System.out.println("Dosya Adı: "+file.getName());
            System.out.println("Dosya Yolu: "+file.getAbsolutePath());
            System.out.println("Dosya yazılabilir mi?: "+file.canWrite());
            System.out.println("Dosya okunabilir mi?: "+file.canRead());
            System.out.println("Dosya Boyutu (byte): "+file.length());
        }
    }

    public static void ReadFile()
    {
        File file=new File("C:\\Users\\oğuzhan\\Documents\\Projeler\\" +
                "Yazılım-Programlama\\BTK_Akademi\\JavaGiris\\files\\students.txt");
        try
        {
            Scanner reader = new Scanner(file);
            while(reader.hasNextLine())
            {
                String line=reader.nextLine();
                System.out.println(line);
            }
            reader.close();
        }
        catch (FileNotFoundException e)
        {
            e.printStackTrace();
        }

    }

    public static void WriteFile()
    {
        try
        {
            BufferedWriter writer=new BufferedWriter(new FileWriter("C:\\" +
                    "Users\\oğuzhan\\Documents\\Projeler\\" +
                    "Yazılım-Programlama\\BTK_Akademi\\JavaGiris\\" +
                    "files\\students.txt",true));
            writer.newLine();
            writer.write("Ahmet");
            System.out.println("Dosyaya yazıldı.");
            writer.close();
        }
        catch (IOException e)
        {
            e.printStackTrace();
        }
    }
}