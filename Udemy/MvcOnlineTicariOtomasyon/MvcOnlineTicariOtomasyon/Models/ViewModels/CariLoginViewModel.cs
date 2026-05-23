using System.ComponentModel.DataAnnotations;

namespace MvcOnlineTicariOtomasyon.Models.ViewModels
{
    public class CariLoginViewModel
    {
        [Required(ErrorMessage = "E-posta adresi gereklidir.")]
        [EmailAddress(ErrorMessage = "Geçersiz e-posta adresi.")]
        public string CariMail { get; set; }

        [Required(ErrorMessage = "Şifre gereklidir.")]
        public string CariSifre { get; set; }
    }
}
