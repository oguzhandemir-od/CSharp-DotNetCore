using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBDZ
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[,] X = Matris.Olustur(4,3);
            //int[,] Y = Matris.Olustur(4, 3);
            //Matris.Yazdir(X);
            //Matris.Yazdir(Y);

            //Console.Write("{0}", Matris.EsitMi(X, Y) ? "Matrisler eşit." : "Matrisler eşit değil.");
            //int[,] Y = Matris.YenidenSekillendir(X, 3, 5);
            //Matris.Yazdir(Y);


            //int[,] X = Matris.SifirMatrisiOlustur(3, 3);
            //int[,] X = Matris.BirlerMatrisiOlustur(4, 4);
            //int[,] X = Matris.KosegenMatrisOlustur(5);

            //int[,] X = Matris.SkalerMatrisOlustur(4,9);

            //int[,] X = Matris.BirimMatrisOlustur();


            //int[,] T = Matris.Transpoz(X);
            //Matris.Yazdir(T);
            //Console.WriteLine("Matrisin izi: {0}", Matris.Izi(X));
            //int[] D = Matris.DiagonalElemanlarnListesi(X);
            //Matris.Yazdir(D);
            //Console.WriteLine("{0}", Matris.KareMatrisMi(X)?"Kare matris":"Kare matris değil");
            //Console.WriteLine("{0}", Matris.BirimMatrisMi(X) ? "Birim matris" : "Birim matris değil");

            int[,] X = Matris.UstUcgenMatrisOlustur(5,-2,3);
            Matris.Yazdir(X);
            Console.WriteLine("{0}", Matris.KosegenMatrisMi(X) ? "Köşegen matristir." : "Köşegen matris değildir.");
            //Console.WriteLine("{0}", Matris.SimetrikMi(X) ? "Simetrik." : "Simetrik Değil.");
            //Matris.Determinant(X);
            //X = Matris.SkalerCarpim(2, X);
            //Matris.Yazdir(X);
            //Console.WriteLine("|X| = {0}", Matris.Determinant(X));
            Console.WriteLine("{0}", Matris.ElemanlarinToplami(X));
            Console.ReadKey();
        }
    }
}
