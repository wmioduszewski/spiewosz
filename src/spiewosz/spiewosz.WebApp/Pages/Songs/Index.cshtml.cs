using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using spiewosz.WebApp.Data;
using spiewosz.WebApp.Model;

namespace spiewosz.WebApp.Pages.Songs
{
    public class IndexModel : PageModel
    {
        private readonly SongContext _context;
        public IndexModel(SongContext context)
        {
            _context = context;
        }

        public IList<Song> Songs { get; set; } = new List<Song>();

        public async Task OnGetAsync()
        {
            Songs = await _context.Songs.AsNoTracking().ToListAsync();
        }
    }
}
