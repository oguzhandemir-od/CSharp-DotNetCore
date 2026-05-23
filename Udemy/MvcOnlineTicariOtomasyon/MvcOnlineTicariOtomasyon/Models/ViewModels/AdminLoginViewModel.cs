using System.ComponentModel.DataAnnotations;

namespace MvcOnlineTicariOtomasyon.Models.ViewModels
{
    public class AdminLoginViewModel
    {
        [Required(ErrorMessage = "E-posta adresi gereklidir.")]
        [EmailAddress(ErrorMessage = "Geçersiz e-posta adresi.")]
        public string KullaniciAd { get; set; }

        [Required(ErrorMessage = "Şifre gereklidir.")]
        public string Sifre { get; set; }

        public string Yetki {  get; set; }
    }
}
