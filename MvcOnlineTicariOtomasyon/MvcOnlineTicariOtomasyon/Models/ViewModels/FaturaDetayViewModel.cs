using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Models.ViewModels
{
    public class FaturaDetayViewModel
    {
        public IEnumerable<Faturalar> Faturas { get; set; }
        public IEnumerable<FaturaKalem> FaturaKalems { get; set; }
    }
}
