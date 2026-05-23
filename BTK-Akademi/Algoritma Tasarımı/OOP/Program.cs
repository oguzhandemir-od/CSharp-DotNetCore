using OOP.Banka;
using OOP.Cizim;
using OOP.Modelleme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    //public static class StringExtension
    //{
    //    public static int KelimeSayisi(this string s) => s.Split().Length;
    //}

    class Program
    {
        //public static void SekilCiz(Sekil sekil) => sekil.Ciz();

        
        static void Main(string[] args)
        {
            //Sekil s1 = new Dikdortgen(50,50,100,100);
            //SekilCiz(s1);

            //IBankaHesap mevduatHesabi = new YatirimHesabi();
            //mevduatHesabi.Yatir(100);
            //mevduatHesabi.Cek(500);
            //mevduatHesabi.Cek(50);
            //Console.WriteLine(mevduatHesabi.ToString());

            IBankaHesap mevduatHesabi = new MevduatHesabi();
            ITransfer aktifHesap = new AktifHesap();
            aktifHesap.Yatir(250);
            mevduatHesabi.Yatir(500);
            aktifHesap.TransferYap(mevduatHesabi, 200);

            Console.WriteLine(aktifHesap.ToString());
            Console.WriteLine(mevduatHesabi.ToString());

            Console.ReadKey();
        }
    }
}
