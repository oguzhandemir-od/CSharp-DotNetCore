using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcOnlineTicariOtomasyon.Data;
using MvcOnlineTicariOtomasyon.Models.Siniflar;
using MvcOnlineTicariOtomasyon.Models.ViewModels;

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
            var carimail = HttpContext.Session.GetString("CariMail");
            var cari = _context.Carilers.FirstOrDefault(x => x.CariMail == carimail);
            ViewBag.m = carimail;
            return View(cari);
        }

        public IActionResult Siparisler()
        {
            var carimail = HttpContext.Session.GetString("CariMail");
            var id = _context.Carilers.Where(x => x.CariMail == carimail).Select(y => y.Cariid).FirstOrDefault();
            var siparisler = _context.SatisHarekets.Where(s => s.Cariid == id)
                .Include(u => u.Urun)
                .ToList();
            return View(siparisler);
        }

        public IActionResult GelenMesajlar()
        {
            var carimail = HttpContext.Session.GetString("CariMail");
            var id = _context.Carilers.Where(x => x.CariMail == carimail).Select(y => y.Cariid).FirstOrDefault();
            var gelenMesajlar = _context.Mesajlars
    .Join(
        _context.Carilers,
        mesaj => mesaj.Gonderici,
        cari => cari.CariMail,
        (mesaj, cari) => new { Mesaj = mesaj, Cari = cari }
    )
    .Where(result => result.Mesaj.Alici == carimail)
    .Select(result => new GelenKutusuViewModel
    {
        MesajId = result.Mesaj.Mesajlarid,
        GonderenAdiSoyadi = result.Cari.CariAd + " " + result.Cari.CariSoyad,
        Konu = result.Mesaj.Konu,
        Tarih = result.Mesaj.Tarih,
        Icerik = result.Mesaj.Icerik
    })
    .OrderByDescending(m=>m.MesajId)
    .ToList();

            var gelenSayisi = gelenMesajlar.Count();
            ViewBag.GelenSayisi = gelenSayisi;

            var gidenSayisi = _context.Mesajlars.Count(x => x.Gonderici == carimail).ToString();
            ViewBag.GidenSayisi = gidenSayisi;

            return View(gelenMesajlar);
        }

        public IActionResult GidenMesajlar()
        {
            var carimail = HttpContext.Session.GetString("CariMail");

            var gidenMesajlar = _context.Mesajlars
    .Join(
        _context.Carilers,
        mesaj => mesaj.Gonderici,
        cari => cari.CariMail,
        (mesaj, cari) => new { Mesaj = mesaj, Cari = cari }
    )
    .Where(result => result.Mesaj.Gonderici == carimail)
    .Select(result => new GelenKutusuViewModel
    {
        MesajId = result.Mesaj.Mesajlarid,
        AliciAdiSoyadi = result.Mesaj.Alici,
        Konu = result.Mesaj.Konu,
        Tarih = result.Mesaj.Tarih,
        Icerik = result.Mesaj.Icerik
    })
    .OrderByDescending(m=>m.MesajId)
    .ToList();

            var gidenSayisi = gidenMesajlar.Count();
            ViewBag.GidenSayisi = gidenSayisi;

            var gelenSayisi = _context.Mesajlars.Count(x => x.Alici == carimail).ToString();
            ViewBag.GelenSayisi = gelenSayisi;

            return View(gidenMesajlar);

        }
        public IActionResult YeniMesaj()
        {
            var carimail = HttpContext.Session.GetString("CariMail");

            var gelenSayisi = _context.Mesajlars.Count(x => x.Alici == carimail).ToString();
            ViewBag.GelenSayisi = gelenSayisi;

            var gidenSayisi = _context.Mesajlars.Count(x => x.Gonderici == carimail).ToString();
            ViewBag.GidenSayisi = gidenSayisi;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> YeniMesaj(Mesajlar m)
        {
            var gonderen= HttpContext.Session.GetString("CariMail");
            m.Gonderici = gonderen;

            m.Tarih = DateTime.Now;

            _context.Add(m);
            _context.SaveChangesAsync();
            return RedirectToAction(nameof(GidenMesajlar));
        }

        public IActionResult MesajDetay(int id)
        {
            var mesaj=_context.Mesajlars.Where(m=>m.Mesajlarid == id).FirstOrDefault();

            var carimail = HttpContext.Session.GetString("CariMail");

            var gelenSayisi = _context.Mesajlars.Count(x => x.Alici == carimail).ToString();
            ViewBag.GelenSayisi = gelenSayisi;

            var gidenSayisi = _context.Mesajlars.Count(x => x.Gonderici == carimail).ToString();
            ViewBag.GidenSayisi = gidenSayisi;

            return View(mesaj);
        }

        public IActionResult KargoTakip(string search)
        {
            var kargoSorgu = _context.KargoDetays.AsQueryable();
            kargoSorgu = kargoSorgu.Where(k => k.TakipKodu.Contains(search));
            var kargolar = kargoSorgu.ToList();
            return View(kargolar);
        }


    }
}
