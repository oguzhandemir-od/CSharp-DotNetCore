using System.Collections;
using Microsoft.AspNetCore.Mvc;
using MvcOnlineTicariOtomasyon.Data;
using MvcOnlineTicariOtomasyon.Models.ViewModels;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class GraphicsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public GraphicsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index2()
        {
            var satislar = new List<int> { 85, 66, 98 };
            var kategoriler = new List<string> { "Mobilya", "Ofis Eşyaları", "Bilgisayar" };

            ViewBag.Satislar = satislar;
            ViewBag.Kategoriler = kategoriler;

            return View();
        }

        public IActionResult Index3()
        {
            ArrayList xValue = new ArrayList();
            ArrayList yValue = new ArrayList();

            var sonuclar = _context.Uruns.ToList();
            sonuclar.ToList().ForEach(x => xValue.Add(x.UrunAd));
            sonuclar.ToList().ForEach(y => yValue.Add(y.Stok));

            ViewBag.Urunler = xValue;
            ViewBag.Stoklar = yValue;

            return View();
        }

        public IActionResult Index4()
        {
            return View();
        }

        public IActionResult VisualizeProductResult()
        {
            return new JsonResult(UrunListesi());
        }

        public List<GoogleChartViewModel> UrunListesi()
        {
            var liste = new List<GoogleChartViewModel>
            {
                new GoogleChartViewModel
                {
                    UrunAdi="Bilgisayar",
                    Stok=120
                },
                new GoogleChartViewModel
                {
                    UrunAdi="Beyaz Eşya",
                    Stok=150
                },
                new GoogleChartViewModel
                {
                    UrunAdi="Mobilya",
                    Stok=70
                },
                new GoogleChartViewModel
                {
                    UrunAdi="Küçük Ev Aletleri",
                    Stok=180
                },
                new GoogleChartViewModel
                {
                    UrunAdi="Mobil Cihazlar",
                    Stok=90
                }
            };
            return liste;
        }

        public IActionResult VisualizeProductResult2()
        {
            return new JsonResult(UrunListesi2());
        }

        public IActionResult Index5()
        {
            return View();
        }

        public List<GoogleChartViewModel> UrunListesi2()
        {
            var liste = new List<GoogleChartViewModel>();
            liste = _context.Uruns.Select(x => new GoogleChartViewModel
            {
                UrunAdi = x.UrunAd,
                Stok = x.Stok,
            })
                .ToList();

            return liste;
        }

        public IActionResult Index6()
        {
            return View();
        }

        public IActionResult Index7()
        {
            return View();
        }
    }
}
