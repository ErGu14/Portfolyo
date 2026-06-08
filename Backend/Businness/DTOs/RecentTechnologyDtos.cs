namespace Entity.DTOs
{
    public class RecentTechnologyDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool IsActive { get; set; }
    }

    public class RecentTechnologyCreateDto
    {
        public string Name { get; set; } = null!;
        public bool IsActive { get; set; }
    }

    public class RecentTechnologyUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}
