using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using spiewosz.Data;
using spiewosz.Data.Model;

namespace spiewosz.WebApp.Pages.Songs
{
    public class DetailsModel : PageModel
    {
        private readonly SongContext _context;
        public DetailsModel(SongContext context)
        {
            _context = context;
        }

        public Song Song { get; set; }

        public async Task<IActionResult> OnGetAsync(System.Guid id)
        {
            Song = await _context.Songs.FindAsync(id);
            if (Song == null) return NotFound();
            return Page();
        }
    }
}
