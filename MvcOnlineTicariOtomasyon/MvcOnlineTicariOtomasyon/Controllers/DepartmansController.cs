using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcOnlineTicariOtomasyon.Data;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class DepartmansController : Controller
    {
        private readonly ApplicationDbContext _context;
        public DepartmansController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var degerler = _context.Departmans
                .Where(x => x.Durum == true)
                .ToList();
            return View(degerler);
        }

        [Authorize(Policy = "CanCreate")]
        public IActionResult DepartmanEkle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DepartmanEkle(Departman d)
        {
            _context.Add(d);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DepartmanSil(int id)
        {
            var d = await _context.Departmans.FindAsync(id);
            d.Durum = false;
            _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DepartmanGetir(int id)
        {
            var departman = await _context.Departmans.FindAsync(id);
            return View(departman);
        }

        public async Task<IActionResult> DepartmanGuncelle(Departman d)
        {
            var departman = await _context.Departmans.FindAsync(d.Departmanid);
            departman.DepartmanAd = d.DepartmanAd;
            _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DepartmanDetay(int id)
        {
            var personeller = _context.Personels.Where(p => p.Departmanid == id).ToList();
            var departman = _context.Departmans.FirstOrDefault(d => d.Departmanid == id);
            ViewBag.DepAdi = departman.DepartmanAd.ToString();
            return View(personeller);
        }
        public async Task<IActionResult> DepartmanPersonelSatis(int id)
        {
            var satislar=_context.SatisHarekets.Where(s=>s.Personelid == id)
                .Include(s=>s.Urun)
                .Include(s=>s.Cariler)
                .ToList();
            var personel=_context.Personels.FirstOrDefault(p=>p.Personelid == id);
            ViewBag.PerAdi = personel.PersonelAd.ToString() + " " + personel.PersonelSoyad.ToString();
            return View(satislar);
        }
    }
}
