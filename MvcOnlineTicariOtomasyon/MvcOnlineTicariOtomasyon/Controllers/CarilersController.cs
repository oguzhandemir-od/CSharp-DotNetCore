using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcOnlineTicariOtomasyon.Data;
using MvcOnlineTicariOtomasyon.Models.Siniflar;


namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CarilersController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CarilersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var cariler = _context.Carilers
                .Where(c => c.Durum == true)
                .ToList();
            return View(cariler);
        }

        public IActionResult CariEkle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CariEkle(Cariler c)
        {
            c.Durum = true;
            _context.Add(c);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CariSil(int id)
        {
            var c = await _context.Carilers.FindAsync(id);
            c.Durum = false;
            _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CariGetir(int id)
        {
            var cari = await _context.Carilers.FindAsync(id);
            return View(cari);
        }

        public async Task<IActionResult> CariGuncelle(Cariler c)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(CariGetir));
            }
            var cari = await _context.Carilers.FindAsync(c.Cariid);
            cari.CariAd = c.CariAd;
            cari.CariSoyad = c.CariSoyad;
            cari.CariSehir = c.CariSehir;
            cari.CariMail = c.CariMail;
            _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CariSatisGecmis(int id)
        {
            var satislar = _context.SatisHarekets
                .Include(s => s.Urun)
                .Include(s => s.Personel)
                .Where(s => s.Cariid == id)
                .ToList();
            var cari = _context.Carilers.FirstOrDefault(c => c.Cariid == id);
            ViewBag.CariAdi = cari.CariAd.ToString() + "" + cari.CariSoyad.ToString();
            return View(satislar);
        }

    }
}
