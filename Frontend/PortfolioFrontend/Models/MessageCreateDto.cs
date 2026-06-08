using System.ComponentModel.DataAnnotations;

namespace PortfolioFrontend.Models
{
    public class MessageCreateDto
    {
        [Required(ErrorMessage = "Lütfen adınızı giriniz.")]
        public string AdSoyad { get; set; } = string.Empty;

        [Required(ErrorMessage = "Lütfen e-posta adresinizi giriniz.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Lütfen bir konu belirtiniz.")]
        public string Konu { get; set; } = string.Empty;

        [Required(ErrorMessage = "Mesaj alanı boş bırakılamaz.")]
        public string Mesaj { get; set; } = string.Empty;
    }
}
