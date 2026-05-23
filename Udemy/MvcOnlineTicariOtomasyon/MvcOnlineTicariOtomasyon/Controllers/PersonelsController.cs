using System.Security.Cryptography;
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
        public async Task<IActionResult> PersonelEkle(Personel p,IFormFile resim)
        {
            if(resim != null && resim.Length > 0)
            {
                string dosyaAdi = Path.GetFileName(resim.FileName);
                string yol=Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/images", dosyaAdi);

                using (var stream = new FileStream(yol, FileMode.Create))
                {
                    await resim.CopyToAsync(stream);
                }

                p.PersonelGorsel = "/images/"+dosyaAdi;
            }
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

        public async Task<IActionResult> PersonelGuncelle(Personel p, IFormFile resim)
        {
            
            var personel = await _context.Personels.FindAsync(p.Personelid);
            personel.PersonelAd = p.PersonelAd;
            personel.PersonelSoyad = p.PersonelSoyad;
            personel.Departmanid = p.Departmanid;

            if (resim != null && resim.Length > 0)
            {
                string dosyaAdi = Path.GetFileName(resim.FileName);
                string yol = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", dosyaAdi);

                using (var stream = new FileStream(yol, FileMode.Create))
                {
                    await resim.CopyToAsync(stream);
                }

                personel.PersonelGorsel = "/images/" + dosyaAdi;
            }            

            await _context.SaveChangesAsync();
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
