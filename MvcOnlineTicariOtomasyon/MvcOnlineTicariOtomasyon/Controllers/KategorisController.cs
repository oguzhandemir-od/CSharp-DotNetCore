using Microsoft.AspNetCore.Mvc;
using MvcOnlineTicariOtomasyon.Data;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class KategorisController : Controller
    {
        private readonly ApplicationDbContext _context;
        public KategorisController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var degerler = _context.Kategoris.ToList();
            return View(degerler);
        }

        public IActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> KategoriEkle(Kategori k)
        {
            _context.Add(k);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> KategoriSil(int id)
        {
            var k = await _context.Kategoris.FindAsync(id);
            _context.Kategoris.Remove(k);
            _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> KategoriGetir(int id)
        {
            var kategori = await _context.Kategoris.FindAsync(id);
            return View(kategori);
        }

        public async Task<IActionResult> KategoriGuncelle(Kategori k)
        {
            var kategori = await _context.Kategoris.FindAsync(k.Kategoriid);
            kategori.KategoriAd=k.KategoriAd;
            _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
