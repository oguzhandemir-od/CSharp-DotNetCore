using Microsoft.AspNetCore.Mvc;
using MvcOnlineTicariOtomasyon.Data;
using MvcOnlineTicariOtomasyon.Models.DTO;

namespace MvcOnlineTicariOtomasyon.Models.ViewComponents
{
    public class CarilerPartialViewComponent: ViewComponent
    {
        private readonly ApplicationDbContext _context; // Veritabanı bağlamınızın adı

        public CarilerPartialViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cariler = _context.Carilers.ToList();
            return View(cariler);
        }
    }
}
