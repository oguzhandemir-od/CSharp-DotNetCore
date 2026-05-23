using Microsoft.AspNetCore.Mvc;
using MvcOnlineTicariOtomasyon.Data;

namespace MvcOnlineTicariOtomasyon.Models.ViewComponents
{
    public class CariDuyuruViewComponent:ViewComponent
    {
        private readonly ApplicationDbContext _context; // Veritabanı bağlamınızın adı

        public CariDuyuruViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var duyurular = _context.Mesajlars.Where(x => x.Gonderici == "Admin").ToList();
            return View(duyurular);
        }
    }
}
