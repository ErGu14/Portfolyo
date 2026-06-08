namespace Entity.DTOs
{
    public class SkillDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string IconPath { get; set; } = null!;
        public string Items { get; set; } = null!;
        public bool IsActive { get; set; }
    }

    public class SkillCreateDto
    {
        public string Title { get; set; } = null!;
        public string IconPath { get; set; } = null!;
        public string Items { get; set; } = null!;
        public bool IsActive { get; set; }
    }

    public class SkillUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string IconPath { get; set; } = null!;
        public string Items { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}
