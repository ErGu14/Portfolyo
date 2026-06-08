namespace PortfolioFrontend.Models
{
    public class ProjectDto
    {
        public int Id { get; set; }
        public string Baslik { get; set; } = string.Empty;
        public string? Aciklama { get; set; }
        public string Teknolojiler { get; set; } = string.Empty;
        public string? Resim { get; set; }
        public string? Link { get; set; }
        public DateTime EklemeTarihi { get; set; }
        public bool AktifMi { get; set; }
    }
}
