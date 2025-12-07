using Microsoft.EntityFrameworkCore;
using spiewosz.Data.Model;

namespace spiewosz.Data
{
    public class SongContext : DbContext
    {
        public SongContext(DbContextOptions<SongContext> options) : base(options)
        {
        }

        public DbSet<Song> Songs => Set<Song>();
    }
}
