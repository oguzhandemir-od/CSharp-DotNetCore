using Microsoft.AspNetCore.Mvc;
using MvcOnlineTicariOtomasyon.Data;
using MvcOnlineTicariOtomasyon.Models.DTO;
using MvcOnlineTicariOtomasyon.Models.Siniflar;


namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public StatisticsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var cariler = _context.Carilers.Count().ToString();
            ViewBag.CariSayi = cariler;

            var urunler = _context.Uruns.Count().ToString();
            ViewBag.UrunSayi = urunler;

            var personeller = _context.Personels.Count().ToString();
            ViewBag.PersonelSayi = personeller;

            var kategoriler = _context.Kategoris.Count().ToString();
            ViewBag.KategoriSayi = kategoriler;

            var stoklar = _context.Uruns.Sum(u => u.Stok).ToString();
            ViewBag.StokSayi = stoklar;

            var markalar = _context.Uruns.Select(u => u.Marka).Distinct().Count();
            ViewBag.MarkaSayi = markalar.ToString();

            var kritikSeviye = _context.Uruns.Count(u => u.Stok <= 20).ToString();
            ViewBag.KritikSeviye = kritikSeviye;

            var maxFiyatUrun = _context.Uruns.OrderByDescending(u => u.SatisFiyat).FirstOrDefault().UrunAd;
            ViewBag.MaxFiyatUrun = maxFiyatUrun;

            var minFiyatUrun = _context.Uruns.OrderBy(u => u.SatisFiyat).FirstOrDefault().UrunAd;
            ViewBag.MinFiyatUrun = minFiyatUrun;

            var maxMarka = _context.Uruns.GroupBy(m => m.Marka).OrderByDescending(m => m.Count()).Select(m => m.Key).FirstOrDefault();
            ViewBag.MaxMarka = maxMarka;

            var enCokSatan = _context.Uruns.Where(u => u.Urunid ==
            (_context.SatisHarekets.GroupBy(s => s.Urunid).OrderByDescending(s => s.Count()).Select(s => s.Key).FirstOrDefault()))
                .Select(u => u.UrunAd).FirstOrDefault();
            ViewBag.EnCokSatan = enCokSatan;

            var BuzdSayi = _context.Uruns.Count(u => u.UrunAd == "Buzdolabi").ToString();
            ViewBag.BuzdSayi = BuzdSayi;

            var LaptopSayi = _context.Uruns.Count(u => u.UrunAd == "Laptop").ToString();
            ViewBag.LaptopSayi = LaptopSayi;

            var kasaTutar = _context.SatisHarekets.Sum(s => s.ToplamTutar).ToString();
            ViewBag.KasaTutar = kasaTutar;

            var bugunSatis = _context.SatisHarekets.Count(s => s.Tarih == DateTime.Today).ToString();
            ViewBag.BugunSatis = bugunSatis;

            var bugunKasa = _context.SatisHarekets.Where(s => s.Tarih == DateTime.Today).Sum(s => s.ToplamTutar).ToString();
            ViewBag.BugunKasa = bugunKasa;
            
            return View();
        }

        public async Task<IActionResult> SimpleTables()
        {
            var sehirler = _context.Carilers.GroupBy(c => c.CariSehir).Select(g => new { Sehir = g.Key, Count = g.Count() })
                .OrderByDescending(g => g.Count)
                .ToList();
            ViewBag.Sehirler = sehirler;

            var toplamsehir = _context.Carilers.Count();
            ViewBag.ToplamSehir = toplamsehir;

            return View();
        }

        

        
    }
}
