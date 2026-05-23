using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBDZ
{
    public class Matris
    {
        /// <summary>
        /// Matris oluşturur.
        /// </summary>
        /// <param name="satir">Satır sayısı.</param>
        /// <param name="sutun">Sütun sayısı.</param>
        /// <param name="min">Minimum değer.</param>
        /// <param name="max">Maksimum değer.</param>
        /// <returns>X Matrisi.</returns>
        public static int[,] Olustur(int satir = 3, int sutun = 3, int min = 1, int max = 9)
        {
            int[,] X = new int[satir, sutun];
            for (int i = 0; i < satir; i++)
            {
                for (int j = 0; j < sutun; j++)
                {
                    X[i, j] = new Random().Next(min, max);
                }

            }
            return X;
        }

        /// <summary>
        /// Matrisi yazdırır.
        /// </summary>
        /// <param name="X">Matris</param>
        public static void Yazdir(int[,] X)
        {
            Console.WriteLine();

            for (int i = 0; i < X.GetLength(0); i++)
            {
                for (int j = 0; j < X.GetLength(1); j++)
                {
                    Console.Write("{0,3}", X[i, j]);

                }
                Console.WriteLine();
            }
        }
        public static void Yazdir(int[] X)
        {
            Console.WriteLine();
            for (int i = 0; i < X.Length; i++)
            {
                Console.Write("{0,5}", X[i]);
            }
            Console.WriteLine();

        }

        /// <summary>
        /// Sıfır Matrisi oluşturur.
        /// </summary>
        /// <param name="satir">Satır sayısı</param>
        /// <param name="sutun">Sütun sayısı</param>
        /// <returns>Sıfır matrisi</returns>
        public static int[,] SifirMatrisiOlustur(int satir, int sutun)
        {
            return Olustur(satir, sutun, 0, 0);
        }

        public static int[,] BirlerMatrisiOlustur(int satir, int sutun)
        {
            return Olustur(satir, sutun, 1, 1);
        }

        /// <summary>
        /// Köşegen matris oluşturur.
        /// </summary>
        /// <param name="boyut">Satır ve sütun sayısı</param>
        /// <param name="min">Minimum değer</param>
        /// <param name="max">Maksimum değer</param>
        /// <returns>Köşegen matris</returns>
        public static int[,] KosegenMatrisOlustur(int boyut = 3, int min = 1, int max = 9)
        {
            int[,] X = SifirMatrisiOlustur(boyut, boyut);
            for (int i = 0; i < X.GetLength(0); i++)
            {
                X[i, i] = new Random().Next(min, max);
            }
            return X;
        }

        /// <summary>
        /// Skaler matris oluşturur.
        /// </summary>
        /// <param name="boyut">Satır ve sütun</param>
        /// <param name="skaler">Köşegen üstündeki değer</param>
        /// <returns>Skaler matris</returns>
        public static int[,] SkalerMatrisOlustur(int boyut = 3, int skaler = 3)
        {
            return KosegenMatrisOlustur(boyut, skaler, skaler);
        }

        /// <summary>
        /// Kare matris kontrolü yapar.
        /// </summary>
        /// <param name="X">Matris</param>
        /// <returns>Sonuç</returns>
        public static bool KareMatrisMi(int[,] X)
        {
            return X.GetLength(0) == X.GetLength(1) ? true : false;
        }

        public static int[,] BirimMatrisOlustur(int boyut=3)
        {
            return SkalerMatrisOlustur(boyut, 1);
        }

        public static bool BirimMatrisMi(int[,] X)
        {
            bool s = true;
            for (int i = 0; (i < X.GetLength(0) && s==true); i++)
            {
                for (int j = 0; j < X.GetLength(1); j++)
                {
                    // Diagonal elemanları dışındakiler 0 mı?
                    if(X[i,j]!=0 && i!=j)
                    {
                        s = false;
                        break;
                    }
                    else
                    {
                        // Diagonal elemanlar 1 mi?
                        if(X[i,i]!=1 && i==j)
                        {
                            s = false;
                            break;
                        }
                    }
                }
            }
            return s;
        }

        /// <summary>
        /// Diagonal elemanların listesini gösterir.
        /// </summary>
        /// <param name="X">Matris</param>
        /// <returns>Diagonal elemanların listesi</returns>
        public static int[] DiagonalElemanlarnListesi(int[,] X)
        {
            if (KareMatrisMi(X))
            {
                int[] D = new int[X.GetLength(0)];
                for (int i = 0; i < X.GetLength(0); i++)
                {
                    D[i] = X[i, i];
                }
                return D;
            }
            else
            {
                Console.WriteLine("Lütfen kare matris giriniz!");
                return new int[1];
            }
        }

        /// <summary>
        /// Matrisin izini hesaplar.
        /// </summary>
        /// <param name="X">Matris</param>
        /// <returns>Matrisin izi</returns>
        public static int Izi(int[,] X)
        {
            int t = 0;
            if (KareMatrisMi(X))
            {
                int[] D = DiagonalElemanlarnListesi(X);

                for (int i = 0; i < D.Length; i++)
                {
                    t += D[i];
                }
                return t;
            }
            else
            {
                return t;
            }
            
        }

        /// <summary>
        /// Bir matrisin transpozunu alır.
        /// </summary>
        /// <param name="X">Matris</param>
        /// <returns>Transpoz</returns>
        public static int[,] Transpoz(int[,] X)
        {
            int[,] T = new int[X.GetLength(1), X.GetLength(0)];
            for (int i = 0; i < T.GetLength(0); i++)
            {
                for (int j = 0; j < T.GetLength(1); j++)
                {
                    T[i,j] = X[j,i];
                }
            }
            return T;
        }

        public static int[,] YenidenSekillendir(int[,] X,int yeniSatir,int yeniSutun)
        {
            if (X.Length==yeniSatir*yeniSutun)
            {
                int[] D = new int[X.Length];
                int sayac = 0;
                int[,] Y = new int[yeniSatir, yeniSutun];
                for (int i = 0; i < X.GetLength(0); i++)
                {
                    for (int j = 0; j < X.GetLength(1); j++)
                    {
                        D[sayac] = X[i, j];
                        sayac++;
                    }
                }
                Yazdir(D);
                sayac = 0;
                for (int i = 0; i < Y.GetLength(0); i++)
                {
                    for (int j = 0; j < yeniSutun; j++)
                    {
                        Y[i, j] = D[sayac];
                        sayac++;
                    }
                }
                return Y;
            }
            else
            {
                Console.WriteLine("Bir hata oluştu!");
                return new int[1, 1];
            }
            
        }

        public static bool EsitMi(int[,] X,int[,] Y)
        {
            bool s = true;

            // Boyut Kontrolü
            if (X.GetLength(0)==Y.GetLength(0)&&X.GetLength(1)==Y.GetLength(1))
            {
                // Eleman Kontrolü
                for (int i = 0; i < X.GetLength(0); i++)
                {
                    for (int j = 0; j < X.GetLength(1); j++)
                    {
                        if (X[i,j]!=Y[i,j])
                        {
                            s = false;
                            break;
                        }
                    }
                }
            }
            else
            {
                s = false;
            }
            return s;
        }

        /// <summary>
        /// Determinant hesabı yapar.
        /// </summary>
        /// <param name="X">Matris</param>
        /// <returns>Determinant</returns>
        public static int Determinant(int[,] X)
        {
            int d = -1;
            if (KareMatrisMi(X))
            {
                if(X.Length==4)
                {
                    d = X[0, 0] * X[1, 1] - X[0, 1] * X[1, 0];

                }
                else if(X.Length==9)
                {
                    d = X[0, 0] * (X[1, 1] * X[2, 2] - X[1, 2] * X[2, 1]) -
                        X[0, 1] * (X[1, 0] * X[2, 2] - X[2, 0] * X[1, 2]) +
                        X[0, 2] * (X[1, 0] * X[2, 1] - X[1, 1] * X[2, 0]);
                }
                else
                {
                    Console.WriteLine("Tanımlı bir boyut yok.");
                }
                return d;
            }
            else
            {
                Console.WriteLine("Kare matris olmalı.");
                return d;
            }
            
        }

        /// <summary>
        /// Skaler bir değer ile matrisi çarpar.
        /// </summary>
        /// <param name="c">Skaler değer</param>
        /// <param name="X">Matris</param>
        /// <returns>Çarpım Sonucu</returns>
        public static int[,] SkalerCarpim(int c, int[,] X)
        {
            for (int i = 0; i < X.GetLength(0); i++)
            {
                for (int j = 0; j < X.GetLength(1); j++)
                {
                    X[i, j] = c * X[i, j];
                }
            }
            return X;
        }

        /// <summary>
        /// Bir matristeki elemanların toplamını bulur.
        /// </summary>
        /// <param name="X">Matris</param>
        /// <returns>Toplam sonucu</returns>
        public static int ElemanlarinToplami(int[,] X)
        {
            int t = 0;
            for(int i=0;i< X.GetLength(0);i++)
            {
                for(int j=0;j<X.GetLength(1);j++)
                {
                    t += X[i, j];
                }
            }
            return t;
        }

        public static int[,] SimetrikMatrisOlustur(int boyut=3,int min=1,int maks=9)
        {
            int[,] X = KosegenMatrisOlustur(boyut, min, maks);
            for (int i = 1; i < X.GetLength(0); i++)
            {
                for (int j = 0; j <=i-1; j++)
                {
                    X[i, j] = new Random().Next(min, maks);
                    X[j, i] = X[i, j];
                }
            }
            return X;
        }

        public static bool SimetrikMi(int[,] X)
        {
            int[,] Y = Matris.Transpoz(X);
            return EsitMi(X, Y);
        }

        public static bool KosegenMatrisMi(int[,] X)
        {
            bool s = true;
            if(Matris.KareMatrisMi(X))
            {
                for (int i = 0; i < X.GetLength(0); i++)
                {
                    for (int j = 0; j < X.GetLength(1); j++)
                    {
                        if(!(X[i,j]==0))
                        {
                            if(i!=j)
                            {
                                s = false;
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Kare matris değil.");
                s = false;
            }
            return s;
        }

        public static int[,] UstUcgenMatrisOlustur(int boyut=3,int min=1,int maks=9)
        {
            int[,] X = KosegenMatrisOlustur(boyut, min, maks);

            for (int i = 0; i < X.GetLength(0); i++)
            {
                for (int j = i; j < X.GetLength(1); j++)
                {
                    X[i, j] = new Random().Next(min, maks);
                }
            }
            return X;
        }

        /// <summary>
        /// Alt üçgen matris oluşturur.
        /// </summary>
        /// <param name="boyut">Boyut</param>
        /// <param name="min">Min</param>
        /// <param name="maks">Maks</param>
        /// <returns>Alt üçgen matris</returns>
        public static int[,] AltUcgenMatrisOlustur(int boyut=3,int min=1,int maks=9)
        {
            int[,] X = KosegenMatrisOlustur(boyut, min, maks);

            for (int i = 0; i < X.GetLength(0); i++)
            {
                for (int j = 0; j <=i; j++)
                {
                    X[i, j] = new Random().Next(min, maks);
                }
            }
            return X;
        }

        /// <summary>
        /// Parametre oalrak aldığı matrisin üst üçgen matris olup olmadığını kontrol eder.
        /// </summary>
        /// <param name="X">Matris</param>
        /// <returns>Sonuç</returns>
        public static bool UstUcgenMatrisMi(int[,] X)
        {
            bool s = true;

            for (int i = 0; i < X.GetLength(0); i++)
            {
                for (int j = 0; j <=i-1; j++)
                {
                    if(!(X[i,j]==0))
                    {
                        s = false;
                        break;
                    }
           

            
                }
            }
            return s;
        }

        /// <summary>
        /// Alt üçgen matris kontrolü yapar.
        /// </summary>
        /// <param name="X">Matris</param>
        /// <returns>Sonuç</returns>
        public static bool AltUcgenMatrisMi(int[,] X)
        {
            bool s = true;
            for (int i = 0; i < X.GetLength(0); i++)
            {
                for (int j = i+1; j < X.GetLength(1); j++)
                {
                    if (!(X[i,j]==0))
                    {
                        s = false;
                        break;
                    }
                }
            }
            return s;
        }
    }
}
