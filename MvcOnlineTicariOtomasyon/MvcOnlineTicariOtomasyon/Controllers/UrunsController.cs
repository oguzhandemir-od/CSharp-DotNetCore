using Microsoft.AspNetCore.Mvc;
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
                .ToList();
            return View(urunler);
        }

        public IActionResult YeniUrun()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> YeniUrun(Urun p)
        {
            _context.Add(p);
            _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
