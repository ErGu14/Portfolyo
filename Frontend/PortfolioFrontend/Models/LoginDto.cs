using System.ComponentModel.DataAnnotations;

namespace PortfolioFrontend.Models
{
    public class LoginDto
    {
        [Required(ErrorMessage = "E-posta alanı boş bırakılamaz.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Şifre alanı boş bırakılamaz.")]
        public string Password { get; set; } = string.Empty;
    }
    
    public class AuthResponseDto
    {
        public string Token { get; set; } = string.Empty;
    }
}
