namespace Entity
{
    public class Skill
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string IconPath { get; set; } = null!;
        public string Items { get; set; } = null!; // Multiline text, each line is an item
        public bool IsActive { get; set; } = true;
    }
}
