using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcOnlineTicariOtomasyon.Data;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariPanelController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CariPanelController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        public IActionResult Index()
        {
            var carimail= HttpContext.Session.GetString("CariMail");
            var cari=_context.Carilers.FirstOrDefault(x=>x.CariMail==carimail);
            ViewBag.m = carimail;
            return View(cari);
        }

        public IActionResult Siparisler()
        {
            var carimail = HttpContext.Session.GetString("CariMail");
            var id = _context.Carilers.Where(x=>x.CariMail==carimail).Select(y=>y.Cariid).FirstOrDefault();
            var siparisler = _context.SatisHarekets.Where(s => s.Cariid == id)
                .Include(u=>u.Urun)
                .ToList();
            return View(siparisler);
        }
    }
}
