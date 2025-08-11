using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcOnlineTicariOtomasyon.Data;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class PersonelsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public PersonelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var personeller = _context.Personels
                .Include(d=>d.Departman)
                .ToList();
            return View(personeller);
        }

        public IActionResult PersonelEkle()
        {
            var departmanliste = _context.Departmans.ToList();
            ViewBag.Departmanlar = departmanliste;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PersonelEkle(Personel p)
        {
            _context.Add(p);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> PersonelGetir(int id)
        {
            var departmanliste = _context.Departmans.ToList();
            ViewBag.Departmanlar = departmanliste;
            var personel = await _context.Personels.FindAsync(id);
            return View(personel);
        }

        public async Task<IActionResult> PersonelGuncelle(Personel p)
        {
            var personel = await _context.Personels.FindAsync(p.Personelid);
            personel.PersonelAd = p.PersonelAd;
            personel.PersonelSoyad = p.PersonelSoyad;
            personel.PersonelGorsel = p.PersonelGorsel;
            personel.Departmanid = p.Departmanid;
            _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> PersonelListe()
        {
            var personeller = _context.Personels
                .Include(d=>d.Departman)
                .ToList();
            return View(personeller);
        }
    }
}
