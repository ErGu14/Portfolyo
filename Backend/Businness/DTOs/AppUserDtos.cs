using System.ComponentModel.DataAnnotations;

namespace Entity.DTOs
{
    public class AppUserDto
    {
        public string Id { get; set; } = null!;
        public string AdSoyad { get; set; } = null!;
        public string Email { get; set; } = null!;
    }

    public class LoginDto
    {
        [Required(ErrorMessage = "Email alanı zorunludur.")]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Şifre alanı zorunludur.")]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalıdır.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,}$", ErrorMessage = "Şifreniz en az bir büyük harf, bir küçük harf, bir rakam ve bir özel karakter içermelidir.")]
        public string Password { get; set; } = null!;
    }

    public class ChangePasswordDto
    {
        [Required(ErrorMessage = "Mevcut şifre alanı zorunludur.")]
        public string CurrentPassword { get; set; } = null!;

        [Required(ErrorMessage = "Yeni şifre alanı zorunludur.")]
        [MinLength(6, ErrorMessage = "Yeni şifre en az 6 karakter olmalıdır.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,}$", ErrorMessage = "Şifreniz en az bir büyük harf, bir küçük harf, bir rakam ve bir özel karakter içermelidir.")]
        public string NewPassword { get; set; } = null!;

        [Required(ErrorMessage = "Şifre tekrarı zorunludur.")]
        [Compare("NewPassword", ErrorMessage = "Şifreler eşleşmiyor.")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
