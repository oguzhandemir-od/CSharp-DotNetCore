using Microsoft.AspNetCore.Mvc;
using MvcOnlineTicariOtomasyon.Data;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class KargoController : Controller
    {
        private readonly ApplicationDbContext _context;
        public KargoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string search)
        {
            var kargoSorgu = _context.KargoDetays.AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                kargoSorgu = kargoSorgu.Where(k => k.TakipKodu.Contains(search));
            }
            var kargolar = kargoSorgu.ToList();
            return View(kargolar);
        }

        public IActionResult YeniKargo()
        {
            string takipKodu = TakipKoduUret();
            ViewBag.TakipKodu = takipKodu;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> YeniKargo(KargoDetay k)
        {
            _context.KargoDetays.Add(k);
            _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [Route("Kargo/KargoTakip/{kod}")]
        // Veya string id şeklinde parametre yollanabilir

        public IActionResult KargoTakip(string kod)
        {
            var kargo = _context.KargoTakips.Where(x => x.TakipKodu == kod).ToList();
            return View(kargo);
        }
        public string TakipKoduUret()
        {
            Random rnd = new Random();
            string[] karakterler = { "A", "B", "C", "D" };
            int k1, k2, k3;
            k1 = rnd.Next(0, 4);
            k2 = rnd.Next(0, 4);
            k3 = rnd.Next(0, 4);
            int s1, s2, s3;
            s1 = rnd.Next(100, 1000);
            s2 = rnd.Next(10, 99);
            s3 = rnd.Next(10, 99);
            string kod = s1.ToString() + karakterler[k1] + s2.ToString() + karakterler[k2] + s3.ToString() + karakterler[k3];
            return kod;
        }
    }
}
