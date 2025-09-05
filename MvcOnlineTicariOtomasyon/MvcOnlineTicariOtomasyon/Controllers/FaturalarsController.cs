using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MvcOnlineTicariOtomasyon.Data;
using MvcOnlineTicariOtomasyon.Models.Siniflar;
using MvcOnlineTicariOtomasyon.Models.ViewModels;

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

        public ActionResult Dinamik()
        {
            FaturaDetayViewModel model = new FaturaDetayViewModel();
            model.Faturas = _context.Faturalars.ToList();
            model.FaturaKalems = _context.FaturaKalems.ToList();
            return View(model);
        }

        public async Task<IActionResult> FaturaKaydet(string FaturaSeriNo, string FaturaSiraNo,DateTime Tarih,
            string VergiDairesi, DateTime saat, string TeslimEden, string TeslimAlan,string Toplam,
            FaturaKalem[] kalemler)
        {
            Faturalar f = new Faturalar();
            f.FaturaSeriNo = FaturaSeriNo;
            f.FaturaSiraNo = FaturaSiraNo;
            f.Tarih=Tarih;
            f.VergiDairesi = VergiDairesi;
            f.Saat = saat;
            f.TeslimEden = TeslimEden;
            f.TeslimAlan = TeslimAlan;
            f.Toplam = decimal.Parse(Toplam);
            _context.Faturalars.Add(f);
            foreach(var x in kalemler)
            {
                FaturaKalem k=new FaturaKalem();
                k.Aciklama=x.Aciklama;
                k.BirimFiyat=x.BirimFiyat;
                k.Faturalarid = x.Faturakalemid;
                k.Miktar=x.Miktar;
                k.Tutar=x.Tutar;
                _context.FaturaKalems.Add(k);
            }
            _context.SaveChanges();
            return Json("İşlem başarılı");
        }

    }
}
