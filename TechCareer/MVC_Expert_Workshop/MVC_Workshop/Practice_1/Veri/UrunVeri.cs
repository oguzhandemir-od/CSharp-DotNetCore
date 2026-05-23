using Practice_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practice_1.Veri
{
    public class UrunVeri
    {
        public static List<Urun> Urunler = new List<Urun>
        {
            new Urun
            {
                Id=1,
                UrunAdi="Harici Harddisk",
                UrunFiyati=799,
                UrunKargoSuresi=2,
                UrunMagazasi="A",
                UrunOzellikleri="500 GB"
            },
            new Urun
            {
                Id=2,
                UrunAdi="Harddisk Kutusu",
                UrunFiyati=165,
                UrunKargoSuresi=2,
                UrunMagazasi="B",
                UrunOzellikleri="USB 3.0"
            },
            new Urun
            {
                Id=3,
                UrunAdi="Kablosuz Kulaklık",
                UrunFiyati=599,
                UrunKargoSuresi=2,
                UrunMagazasi="C",
                UrunOzellikleri="Bluetooth"
            }
        };

    }
}