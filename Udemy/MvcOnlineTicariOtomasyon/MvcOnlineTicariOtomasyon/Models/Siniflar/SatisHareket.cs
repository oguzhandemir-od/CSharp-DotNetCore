using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class SatisHareket
    {
        [Key]
        public int Satishareketid { get; set; }
        // Ürün
        // Cari
        // Personel
        public DateTime Tarih { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
        public decimal ToplamTutar { get; set; }

        public int Urunid { get; set; }
        public int Cariid { get; set; }
        public int Personelid { get; set; }

        public Urun Urun { get; set; }
        [ForeignKey("Cariid")]
        public Cariler Cariler { get; set; }
        public Personel Personel { get; set; }
    }
}
