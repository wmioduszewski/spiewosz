namespace spiewosz.Data.Model
{
    public class Song
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string Lyrics { get; set; } = string.Empty;
        public string? Category { get; set; }
    }
}
