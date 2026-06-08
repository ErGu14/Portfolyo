namespace Entity.DTOs
{
    public class FeatureDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string IconPath { get; set; } = null!;
        public bool IsActive { get; set; }
    }

    public class FeatureCreateDto
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string IconPath { get; set; } = null!;
        public bool IsActive { get; set; }
    }

    public class FeatureUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string IconPath { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}
