using Microsoft.AspNetCore.Mvc;
using MvcOnlineTicariOtomasyon.Data;
using MvcOnlineTicariOtomasyon.Models.DTO;

namespace MvcOnlineTicariOtomasyon.Models.ViewComponents
{
    public class DepartmanGrupViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context; // Veritabanı bağlamınızın adı

        public DepartmanGrupViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var departmanlar = _context.Personels
                .GroupBy(d => d.Departman.DepartmanAd)
                .Select(g => new DepartmanPersonelDto
                {
                    Departman = g.Key, // Departman adı string formatında olmalı
                    Sayi = g.Count()
                })
                .OrderByDescending(g => g.Sayi)
                .ToList();

            var toplamdepartman = _context.Departmans.Count();
            ViewBag.ToplamDep = toplamdepartman;
            return View(departmanlar);
        }
    }
}
