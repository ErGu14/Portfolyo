namespace PortfolioFrontend.Models
{
    public class SiteSettingsDto
    {
        public int Id { get; set; }
        public string AdSoyad { get; set; } = string.Empty;
        public string Unvan { get; set; } = string.Empty;
        public string Hakkimda { get; set; } = string.Empty;
        public string CvPath { get; set; } = string.Empty;
        public string? ProfilFoto { get; set; }
    }
}
