namespace PortfolioFrontend.Models
{
    public class CertificateDto
    {
        public int Id { get; set; }
        public string Baslik { get; set; } = string.Empty;
        public string Kurum { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
        public DateTime AlmaTarihi { get; set; } = DateTime.Now;
        public bool AktifMi { get; set; } = true;
        public string UserId { get; set; } = string.Empty;
    }
}
