using Microsoft.AspNetCore.Http;
using System;

namespace Entity.DTOs
{
    public class CertificateListDto
    {
        public int Id { get; set; }
        public string Baslik { get; set; } = null!;
        public string Kurum { get; set; } = null!;
        public string Path { get; set; } = null!; 
        public DateTime AlmaTarihi { get; set; }
        public bool AktifMi { get; set; }
    }

    public class CertificateCreateDto
    {
        public string Baslik { get; set; } = null!;
        public string Kurum { get; set; } = null!;
        public IFormFile? Dosya { get; set; } 
        public DateTime AlmaTarihi { get; set; }
        public bool AktifMi { get; set; }
        public string UserId { get; set; } = null!;
    }

    public class CertificateUpdateDto
    {
        public int Id { get; set; }
        public string Baslik { get; set; } = null!;
        public string Kurum { get; set; } = null!;
        public IFormFile? Dosya { get; set; }
        public string? Path { get; set; }
        public DateTime AlmaTarihi { get; set; }
        public bool AktifMi { get; set; }
        public string UserId { get; set; } = null!;
    }
}
