using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcOnlineTicariOtomasyon.Data;
using MvcOnlineTicariOtomasyon.Models.Siniflar;
using MvcOnlineTicariOtomasyon.Models.ViewModels;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;
        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult ClientRegister()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> ClientRegister(Cariler c)
        {
            _context.Add(c);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ClientLogin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ClientLogin(CariLoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model); // Hataları göster
            }

            var bilgiler = _context.Carilers.FirstOrDefault(x => x.CariMail == model.CariMail && x.CariSifre == model.CariSifre);
            if (bilgiler != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, bilgiler.CariMail) // Kullanıcı mailini claim olarak ekle
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                // Cookie ile kimlik doğrulama
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                // Session kullanımı
                HttpContext.Session.SetString("CariMail", bilgiler.CariMail.ToString());

                return RedirectToAction("Index", "CariPanel");
            }
            ModelState.AddModelError("", "Geçersiz kullanıcı adı veya şifre."); // Hata mesajı ekle
            return View("Index", model); // Hataları göster
        }

        public IActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AdminLogin(AdminLoginViewModel p)
        {
            var bilgiler= _context.Admins.FirstOrDefault(x=>x.KullaniciAd== p.KullaniciAd && x.Sifre==p.Sifre);
            if (bilgiler != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, bilgiler.KullaniciAd) // Kullanıcı mailini claim olarak ekle
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                // Cookie ile kimlik doğrulama
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                // Session kullanımı
                HttpContext.Session.SetString("KullaniciAd", bilgiler.KullaniciAd.ToString());

                return RedirectToAction("Index", "Kategoris");
            }
            ModelState.AddModelError("", "Geçersiz kullanıcı adı veya şifre."); // Hata mesajı ekle
            return View("Index", p); // Hataları göster
        }
    }
}
