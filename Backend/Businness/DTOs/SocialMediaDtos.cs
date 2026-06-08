using Microsoft.AspNetCore.Http;

namespace Entity.DTOs
{
    public class SocialMediaListDto
    {
        public int Id { get; set; }
        public string PlatformAd { get; set; } = null!;
        public string Link { get; set; } = null!;
        public string IconPath { get; set; } = null!;
    }

    public class SocialMediaCreateDto
    {
        public string PlatformAd { get; set; } = null!;
        public string Link { get; set; } = null!;
        public string IconPath { get; set; } = null!;
        public string UserId { get; set; } = null!;
    }

    public class SocialMediaUpdateDto
    {
        public int Id { get; set; }
        public string PlatformAd { get; set; } = null!;
        public string Link { get; set; } = null!;
        public string? IconPath { get; set; }
        public string UserId { get; set; } = null!;
    }
}
