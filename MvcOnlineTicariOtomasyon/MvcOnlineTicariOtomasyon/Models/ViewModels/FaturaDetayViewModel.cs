using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Models.ViewModels
{
    public class FaturaDetayViewModel
    {
        public Faturalar Fatura { get; set; }
        public IEnumerable<FaturaKalem> FaturaKalems { get; set; }
    }
}
