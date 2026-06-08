namespace PortfolioFrontend.Models
{
    public class RecentTechnologyDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }

    public class SkillDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string IconPath { get; set; } = string.Empty;
        public string Items { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }

    public class FeatureDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string IconPath { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
