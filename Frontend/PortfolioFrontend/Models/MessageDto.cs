namespace PortfolioFrontend.Models
{
    public class MessageDto
    {
        public int Id { get; set; }
        public string AdSoyad { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Konu { get; set; } = string.Empty;
        public string Mesaj { get; set; } = string.Empty;
        public DateTime GondermeTarihi { get; set; }
        public bool OkunduMu { get; set; }
    }
}

