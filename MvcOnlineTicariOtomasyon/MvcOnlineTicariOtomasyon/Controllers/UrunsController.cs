using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcOnlineTicariOtomasyon.Data;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class UrunsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public UrunsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var urunler = _context.Uruns
                .Include(u=>u.Kategori)
                .Where(x=>x.Durum==true)
                .ToList();
            return View(urunler);
        }

        public IActionResult YeniUrun()
        {
            var kategoriliste=_context.Kategoris.ToList();
            ViewBag.Kategoriler= kategoriliste;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> YeniUrun(Urun p)
        {
            _context.Add(p);
            _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UrunSil(int id)
        {
            var p = await _context.Uruns.FindAsync(id);
            p.Durum = false;
            _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UrunGetir(int id)
        {
            var kategoriliste = _context.Kategoris.ToList();
            ViewBag.Kategoriler = kategoriliste;
            var urun = await _context.Uruns.FindAsync(id);
            return View(urun);
        }

        public async Task<IActionResult> UrunGuncelle(Urun p)
        {
            var urun = await _context.Uruns.FindAsync(p.Urunid);
            urun.UrunAd = p.UrunAd;
            urun.Marka = p.Marka;
            urun.Stok = p.Stok;
            urun.AlisFiyat = p.AlisFiyat;
            urun.SatisFiyat = p.SatisFiyat;
            urun.Kategoriid = p.Kategoriid;
            urun.UrunGorsel = p.UrunGorsel;
            urun.Durum = p.Durum;
            _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
