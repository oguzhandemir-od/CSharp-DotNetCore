using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Practice_1.Models
{
    public class Urun
    {        
        public int Id { get; set; }

        [DisplayName("Ürün Adı")]
        public string UrunAdi { get; set; }

        [DisplayName("Mağaza")]
        public string UrunMagazasi { get; set; }

        [DisplayName("Özellikler")]
        public string UrunOzellikleri { get; set; }

        [DisplayName("Fiyat")]
        public int UrunFiyati { get; set; }

        [DisplayName("Tahmini Kargo Süresi")]
        public int UrunKargoSuresi { get; set; }

    }
}