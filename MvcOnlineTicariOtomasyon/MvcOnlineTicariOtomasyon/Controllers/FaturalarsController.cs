using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcOnlineTicariOtomasyon.Data;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class FaturalarsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public FaturalarsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var faturalar = _context.Faturalars.ToList();
            return View(faturalar);
        }

        public IActionResult FaturaEkle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FaturaEkle(Faturalar f)
        {
            _context.Add(f);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> FaturaGetir(int id)
        {
            var fatura = await _context.Faturalars.FindAsync(id);
            return View(fatura);
        }

        public async Task<IActionResult> FaturaGuncelle(Faturalar f)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(FaturaGetir));
            }
            var fatura = await _context.Faturalars.FindAsync(f.Faturalarid);
            fatura.FaturaSeriNo = f.FaturaSeriNo;
            fatura.FaturaSiraNo = f.FaturaSiraNo;
            fatura.VergiDairesi = f.VergiDairesi;
            fatura.Tarih = f.Tarih;
            fatura.TeslimEden = f.TeslimEden;
            fatura.TeslimAlan = f.TeslimAlan;
            _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> FaturaDetay(int id)
        {
            var faturakalemleri = _context.FaturaKalems.Where(f => f.Faturalarid == id).ToList();
            return View(faturakalemleri);
        }

        public IActionResult YeniKalem()
        {            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> YeniKalem(FaturaKalem f)
        {
            _context.Add(f);
            _context.SaveChanges();

            var fatura = await _context.Faturalars.FirstOrDefaultAsync(x => x.Faturalarid == f.Faturalarid);
            if (fatura != null)
            {
                fatura.Toplam += f.Tutar;
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
