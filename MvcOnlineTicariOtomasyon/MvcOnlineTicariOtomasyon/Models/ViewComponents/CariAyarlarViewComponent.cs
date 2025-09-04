using Microsoft.AspNetCore.Mvc;
using MvcOnlineTicariOtomasyon.Data;

namespace MvcOnlineTicariOtomasyon.Models.ViewComponents
{
    public class CariAyarlarViewComponent:ViewComponent
    {
        private readonly ApplicationDbContext _context; // Veritabanı bağlamınızın adı

        public CariAyarlarViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var carimail = HttpContext.Session.GetString("CariMail");
            var cari = _context.Carilers.FirstOrDefault(x => x.CariMail == carimail);
            return View(cari);
        }
    }
}
