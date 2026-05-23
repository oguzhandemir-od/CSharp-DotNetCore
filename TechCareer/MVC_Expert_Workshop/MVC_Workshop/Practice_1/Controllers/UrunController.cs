using Practice_1.Models;
using Practice_1.Veri;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practice_1.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        public ActionResult Listele()
        {
            return View(UrunVeri.Urunler);
        }

        public ActionResult Yeni()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Yeni(Urun yeniUrun)
        {
            UrunVeri.Urunler.Add(yeniUrun);
            return RedirectToAction("Listele");
        }

        public ActionResult Duzenle(int id)
        {
            var urun = UrunVeri.Urunler.Where(u => u.Id == id).FirstOrDefault();
            return View(urun);
        }

        [HttpPost]
        public ActionResult Duzenle(Urun urun)
        {
            Urun duzenlenecekUrun= UrunVeri.Urunler.Where(u => u.Id == urun.Id).FirstOrDefault();
            duzenlenecekUrun.UrunAdi=urun.UrunAdi;
            duzenlenecekUrun.UrunMagazasi = urun.UrunMagazasi;
            duzenlenecekUrun.UrunOzellikleri = urun.UrunOzellikleri;
            duzenlenecekUrun.UrunFiyati = urun.UrunFiyati;
            duzenlenecekUrun.UrunKargoSuresi = urun.UrunKargoSuresi;
            return RedirectToAction("Listele");
        }

        public ActionResult Sil(int id)
        {
            var urun = UrunVeri.Urunler.Where(u => u.Id == id).FirstOrDefault();
            return View(urun);
        }

        [HttpPost]
        public ActionResult Sil(Urun urun)
        {
            Urun silinecekUrun = UrunVeri.Urunler.Where(u => u.Id == urun.Id).FirstOrDefault();
            UrunVeri.Urunler.Remove(silinecekUrun);
            return RedirectToAction("Listele");
        }
    }
}