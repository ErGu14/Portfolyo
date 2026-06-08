using Microsoft.AspNetCore.Http;

namespace Entity.DTOs
{
    public class SiteSettingsDto
    {
        public int Id { get; set; }
        public string AdSoyad { get; set; } = null!;
        public string Unvan { get; set; } = null!;
        public string Hakkimda { get; set; } = null!;
        public string CvPath { get; set; } = null!;
        public string? ProfilFoto { get; set; }
    }

    public class SiteSettingsUpdateDto
    {
        public int Id { get; set; }
        public string AdSoyad { get; set; } = null!;
        public string Unvan { get; set; } = null!;
        public string Hakkimda { get; set; } = null!;
        public IFormFile? CvFile { get; set; }
        public string? CvPath { get; set; }
        public IFormFile? ProfilFotoFile { get; set; }
        public string? ProfilFoto { get; set; }
        public string UserId { get; set; } = null!;
    }
}
