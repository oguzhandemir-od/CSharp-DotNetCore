using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Models.ViewModels
{
    public class UrunSatisViewModel
    {
        public SatisHareket Satis { get; set; }

        public int UrunId { get; set; }
        public string UrunAd { get; set; }
        public string UrunMarka { get; set; }
        public decimal UrunFiyat { get; set; }

        public List<Personel> Personeller { get; set; }

        public List<Cariler> Cariler { get; set; }
    }
}
