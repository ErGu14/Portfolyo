namespace Entity
{
    public class Feature
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string IconPath { get; set; } = null!;
        public bool IsActive { get; set; } = true;
    }
}
