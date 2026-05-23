using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcOnlineTicariOtomasyon.Data;
using MvcOnlineTicariOtomasyon.Models.DTO;

namespace MvcOnlineTicariOtomasyon.Models.ViewComponents
{
    public class UrunMarkaViewComponent:ViewComponent
    {
        private readonly ApplicationDbContext _context; // Veritabanı bağlamınızın adı

        public UrunMarkaViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var urunler = await _context.Uruns.GroupBy(u => u.Marka)
                .Select(g => new UrunMarkaDto
                {
                    Marka = g.Key,
                    Sayi = g.Count()
                })
                .OrderByDescending(g => g.Sayi)
                .ToListAsync();

            var toplamUrun= _context.Uruns.Count();
            ViewBag.ToplamUrun = toplamUrun;
            return View(urunler);
        }
    }
}
