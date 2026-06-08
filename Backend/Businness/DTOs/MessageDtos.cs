using System;
using System.ComponentModel.DataAnnotations;

namespace Entity.DTOs
{
    public class MessageListDto
    {
        public int Id { get; set; }
        public string AdSoyad { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Konu { get; set; } = null!;
        public string Mesaj { get; set; } = null!;
        public bool OkunduMu { get; set; }
        public DateTime GondermeTarihi { get; set; }
    }

    public class MessageCreateDto
    {
        [Required(ErrorMessage = "Ad Soyad alanı zorunludur.")]
        public string AdSoyad { get; set; } = null!;

        [Required(ErrorMessage = "Email alanı zorunludur.")]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Konu alanı zorunludur.")]
        public string Konu { get; set; } = null!;

        [Required(ErrorMessage = "Mesaj alanı zorunludur.")]
        public string Mesaj { get; set; } = null!;
    }
}
