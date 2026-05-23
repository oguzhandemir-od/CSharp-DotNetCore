using Microsoft.AspNetCore.Mvc;
using MvcOnlineTicariOtomasyon.Data;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class GaleriController : Controller
    {
        private readonly ApplicationDbContext _context;
        public GaleriController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var urunler = _context.Uruns.ToList();
            return View(urunler);
        }
    }
}
