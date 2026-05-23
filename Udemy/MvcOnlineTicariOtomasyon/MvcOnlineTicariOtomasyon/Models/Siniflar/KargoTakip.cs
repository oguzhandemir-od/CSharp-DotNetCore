using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class KargoTakip
    {
        [Key]
        public int KargoTakipid { get; set; }
        [Column(TypeName ="Varchar(10)")]
        public string TakipKodu { get; set; }
        [Column(TypeName = "Varchar(100)")]
        public string Aciklama { get; set; }
        public DateTime Tarih { get; set; }

    }
}
