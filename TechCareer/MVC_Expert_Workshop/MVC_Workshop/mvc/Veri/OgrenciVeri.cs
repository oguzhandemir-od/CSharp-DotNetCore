using mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvc.Veri
{
    public class OgrenciVeri
    {
        public static List<Ogrenci> Ogrenciler = new List<Ogrenci>
        {
            new Ogrenci
            {
                Id=1,
                Ad="Mehmet",
                Soyad="Yilmaz",
                BolumAd="Hukuk",
                TCKimlikNo="11111111111",
                GirisYili=2010
            },
            new Ogrenci
            {
                Id=2,
                Ad="Ali",
                Soyad="Yilmaz",
                BolumAd="Tip",
                TCKimlikNo="22222222222",
                GirisYili=2014
            }
        };
    }
}