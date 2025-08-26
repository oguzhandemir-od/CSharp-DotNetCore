using System.Drawing;
using System.Drawing.Imaging;
using Microsoft.AspNetCore.Mvc;
using QRCoder;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class QRCodeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string kod)
        {
            ViewBag.Karekod = GenerateQrCode(kod);
            return View();
        }

        public string GenerateQrCode(string kod)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator koduret = new QRCodeGenerator();
                QRCodeGenerator.QRCode karekod = koduret.CreateQrCode(kod, QRCodeGenerator.ECCLevel.Q);
                using (Bitmap resim = karekod.GetGraphic(10))
                {
                    resim.Save(ms, ImageFormat.Png);
                    return "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                }
            }
        }
    }
}
