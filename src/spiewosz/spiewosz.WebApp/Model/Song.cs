namespace spiewosz.WebApp.Model
{
    public class Song
    {
        public System.Guid Id { get; set; } = System.Guid.NewGuid();
        public string Title { get; set; }
        public string Lyrics { get; set; }
        public string? Category { get; set; }
    }
}
