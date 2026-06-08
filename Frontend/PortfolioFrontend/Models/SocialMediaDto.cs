namespace PortfolioFrontend.Models
{
    public class SocialMediaDto
    {
        public int Id { get; set; }
        public string PlatformAd { get; set; } = string.Empty;
        public string Link { get; set; } = string.Empty;
        public string IconPath { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
    }
}
