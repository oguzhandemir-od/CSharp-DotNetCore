using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcOnlineTicariOtomasyon.Data;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class SatisHareketsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SatisHareketsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var satislar = _context.SatisHarekets
                .Include(u=>u.Urun)
                .Include(c=>c.Cariler)
                .Include(p=>p.Personel)
                .ToList();
            return View(satislar);
        }

        public IActionResult YeniSatis()
        {
            var urunler = _context.Uruns.ToList();
            var cariler=_context.Carilers.ToList();
            var personeller=_context.Personels.ToList();
            ViewBag.Urunler = urunler;
            ViewBag.Cariler = cariler;
            ViewBag.Personeller = personeller;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> YeniSatis(SatisHareket s)
        {
            s.Tarih=DateTime.Parse(DateTime.Now.ToShortDateString());
            _context.Add(s);
            await _context.SaveChangesAsync();

            var urun = await _context.Uruns.FirstOrDefaultAsync(u => u.Urunid == s.Urunid);
            if (urun != null)
            {
                urun.Stok -= (short)s.Adet;
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> SatisGetir(int id)
        {
            var urunler = _context.Uruns.ToList();
            var cariler = _context.Carilers.ToList();
            var personeller = _context.Personels.ToList();
            ViewBag.Urunler = urunler;
            ViewBag.Cariler = cariler;
            ViewBag.Personeller = personeller;

            var satis = await _context.SatisHarekets.FindAsync(id);
            return View(satis);
        }

        public async Task<IActionResult> SatisGuncelle(SatisHareket s)
        {
            var satis = await _context.SatisHarekets.FindAsync(s.Satishareketid);
            satis.Urunid = s.Urunid;
            satis.Cariid = s.Cariid;
            satis.Personelid = s.Personelid;
            satis.Adet = s.Adet;
            satis.Fiyat = s.Fiyat;
            satis.ToplamTutar = s.ToplamTutar;
            satis.Tarih=s.Tarih;
            _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> SatisDetay(int id)
        {
            var satis = _context.SatisHarekets
                .Include(u=>u.Urun)
                .Include(c=>c.Cariler)
                .Include(p=>p.Personel)
                .Where(s=>s.Satishareketid==id).FirstOrDefault();
            return View(satis);
        }
    }
}
