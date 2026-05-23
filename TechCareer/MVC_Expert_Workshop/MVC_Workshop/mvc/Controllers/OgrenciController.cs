using mvc.Models;
using mvc.Veri;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc.Controllers
{
    public class OgrenciController : Controller
    {
        // GET: Ogrenci
        public ActionResult Listele()
        {
            return View(OgrenciVeri.Ogrenciler);
        }

        public ActionResult Yeni()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Yeni(Ogrenci yeniOgrenci)
        {
            yeniOgrenci.Id = OgrenciVeri.Ogrenciler.Max(s => s.Id) + 1;
            OgrenciVeri.Ogrenciler.Add(yeniOgrenci);
            return RedirectToAction("Listele");
        }

        public ActionResult Duzenle(int id)
        {
            var ogrenci = OgrenciVeri.Ogrenciler.Where(o => o.Id == id).
                FirstOrDefault();
            return View(ogrenci);
        }

        [HttpPost]
        public ActionResult Duzenle(Ogrenci ogrenci)
        {
            Ogrenci duzenlenecekOgrenci = OgrenciVeri.Ogrenciler.Where(o => o.Id == ogrenci.Id).FirstOrDefault();
            duzenlenecekOgrenci.Ad = ogrenci.Ad;
            duzenlenecekOgrenci.BolumAd = ogrenci.BolumAd;
            duzenlenecekOgrenci.GirisYili = ogrenci.GirisYili;
            duzenlenecekOgrenci.Soyad = ogrenci.Soyad;
            duzenlenecekOgrenci.TCKimlikNo = ogrenci.TCKimlikNo;
            return RedirectToAction("Listele");
        }

        public ActionResult Sil(int id)
        {
            var ogrenci = OgrenciVeri.Ogrenciler.Where(o => o.Id == id).FirstOrDefault();
            return View(ogrenci);
        }

        [HttpPost]
        public ActionResult Sil(Ogrenci ogrenci)
        {
            Ogrenci silinecekogrenci = OgrenciVeri.Ogrenciler.Where(o => o.Id == ogrenci.Id).FirstOrDefault();
            OgrenciVeri.Ogrenciler.Remove(silinecekogrenci);
            return RedirectToAction("Listele");
        }
    }
}