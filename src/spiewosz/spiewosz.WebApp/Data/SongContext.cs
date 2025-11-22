using Microsoft.EntityFrameworkCore;
using spiewosz.WebApp.Model;

namespace spiewosz.WebApp.Data
{
    public class SongContext : DbContext
    {
        public SongContext(DbContextOptions<SongContext> options) : base(options)
        {
        }

        public DbSet<Song> Songs { get; set; }
    }
}
