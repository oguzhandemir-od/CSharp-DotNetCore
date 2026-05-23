using Microsoft.AspNetCore.Mvc;
using MvcOnlineTicariOtomasyon.Data;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class YapilacaksController : Controller
    {
        private readonly ApplicationDbContext _context;
        public YapilacaksController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var cariler = _context.Carilers.Count().ToString();
            ViewBag.Cariler=cariler;

            var urunler=_context.Uruns.Count().ToString();
            ViewBag.Urunler=urunler;

            var kategoriler=_context.Kategoris.Count().ToString();
            ViewBag.Kategoriler=kategoriler;

            var sehirler=_context.Carilers.Select(s=>s.CariSehir).Distinct().Count().ToString();
            ViewBag.Sehirler=sehirler;

            var yapilacaklar = _context.Yapilacaks.ToList();

            return View(yapilacaklar);
        }
    }
}
