using IronBarCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeGenerator
{
    internal class Islemler
    {
        public static void BarkodOlustur()
        {
            Console.WriteLine();
            Console.Write("Barkod için ifade giriniz: ");
            string ifade = Console.ReadLine();
            var barcode = BarcodeWriter.CreateBarcode(ifade, BarcodeEncoding.Code128);
            barcode.ResizeTo(400, 100);
            barcode.SaveAsImage("Barkod.png");
            Console.WriteLine("Barkod oluşturuldu.");
        }
        public static void BarkodOku()
        {
            Console.WriteLine();
            var okunanBarkod = BarcodeReader.Read("Barkod.png");
            Console.Write("Barkod çözümlemesi: ");
            foreach (BarcodeResult result in okunanBarkod)
            {
                Console.WriteLine(result.Text);
            }
        }
    }
}
