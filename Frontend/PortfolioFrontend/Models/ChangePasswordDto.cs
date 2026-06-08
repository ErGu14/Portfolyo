using System.ComponentModel.DataAnnotations;

namespace PortfolioFrontend.Models
{
    public class ChangePasswordDto
    {
        [Required(ErrorMessage = "Mevcut şifre alanı zorunludur.")]
        public string CurrentPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "Yeni şifre alanı zorunludur.")]
        [MinLength(6, ErrorMessage = "Yeni şifre en az 6 karakter olmalıdır.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,}$", ErrorMessage = "Şifreniz en az bir büyük harf, bir küçük harf, bir rakam ve bir özel karakter içermelidir.")]
        public string NewPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "Şifre tekrarı zorunludur.")]
        [Compare("NewPassword", ErrorMessage = "Şifreler eşleşmiyor.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
