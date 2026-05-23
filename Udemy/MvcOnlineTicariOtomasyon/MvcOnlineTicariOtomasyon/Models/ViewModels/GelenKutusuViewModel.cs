namespace MvcOnlineTicariOtomasyon.Models.ViewModels
{
    public class GelenKutusuViewModel
    {
        public int MesajId { get; set; }
        public string GonderenAdiSoyadi { get; set; }
        public string AliciAdiSoyadi { get; set; }
        public string Konu { get; set; }
        public DateTime Tarih { get; set; }
        public string Icerik { get; set; }
    }
}
