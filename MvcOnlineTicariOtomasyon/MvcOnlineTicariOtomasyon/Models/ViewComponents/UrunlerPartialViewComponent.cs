using Microsoft.AspNetCore.Mvc;
using MvcOnlineTicariOtomasyon.Data;

namespace MvcOnlineTicariOtomasyon.Models.ViewComponents
{
    public class UrunlerPartialViewComponent: ViewComponent
    {
        private readonly ApplicationDbContext _context; // Veritabanı bağlamınızın adı

        public UrunlerPartialViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var urunler = _context.Uruns.ToList();
            return View(urunler);
        }
    }
}
