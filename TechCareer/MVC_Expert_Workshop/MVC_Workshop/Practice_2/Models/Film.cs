using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Practice_2.Models
{
    public class Film
    {
        public int Id {  get; set; }

        [DisplayName("Film Adı")]
        public string Ad {  get; set; }

        [DisplayName("Tür")]
        public string Tur { get; set; }

        [DisplayName("Açıklama")]
        public string Aciklama { get; set; }

        [DisplayName("Puan")]
        public double Puan {  get; set; }

    }
}