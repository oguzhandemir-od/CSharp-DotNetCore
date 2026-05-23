using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace efp.Models
{
    public class Urun
    {
        public int Id { get; set; }

        [DisplayName("Ürün Adı")]
        public string Ad {  get; set; }

        [DisplayName("Fiyat")]
        public double Fiyat { get; set; }

        [DisplayName("Stok")]
        public int StokSayisi { get; set; }

    }
}