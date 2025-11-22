using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using spiewosz.WebApp.Data;
using spiewosz.WebApp.Model;

namespace spiewosz.WebApp.Pages.Songs
{
    public class DeleteModel : PageModel
    {
        private readonly SongContext _context;
        public DeleteModel(SongContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Song Song { get; set; }

        public async Task<IActionResult> OnGetAsync(System.Guid id)
        {
            Song = await _context.Songs.FindAsync(id);
            if (Song == null) return NotFound();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var entity = await _context.Songs.FindAsync(Song.Id);
            if (entity != null)
            {
                _context.Songs.Remove(entity);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("Index");
        }
    }
}
