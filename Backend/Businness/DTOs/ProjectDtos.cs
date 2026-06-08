using Microsoft.AspNetCore.Http;
using System;

namespace Entity.DTOs
{
    public class ProjectListDto
    {
        public int Id { get; set; }
        public string Baslik { get; set; } = null!;
        public string? Aciklama { get; set; }
        public string Teknolojiler { get; set; } = null!;
        public string? Resim { get; set; }
        public string? Link { get; set; }
        public DateTime EklemeTarihi { get; set; }
        public bool AktifMi { get; set; }
    }

    public class ProjectCreateDto
    {
        public string Baslik { get; set; } = null!;
        public string? Aciklama { get; set; }
        public string Teknolojiler { get; set; } = null!;
        public IFormFile? ResimFile { get; set; }
        public string? Link { get; set; }
        public bool AktifMi { get; set; }
        public string UserId { get; set; } = null!;
    }

    public class ProjectUpdateDto
    {
        public int Id { get; set; }
        public string Baslik { get; set; } = null!;
        public string? Aciklama { get; set; }
        public string Teknolojiler { get; set; } = null!;
        public IFormFile? ResimFile { get; set; }
        public string? Resim { get; set; }
        public string? Link { get; set; }
        public bool AktifMi { get; set; }
        public string UserId { get; set; } = null!;
    }
}
