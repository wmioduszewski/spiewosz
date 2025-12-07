using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using spiewosz.Data;
using spiewosz.Data.Model;

namespace spiewosz.WebApp.Pages.Songs
{
    public class CreateModel : PageModel
    {
        private readonly SongContext _context;
        public CreateModel(SongContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Song Song { get; set; }

        public void OnGet()
        {
            Song = new Song();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Songs.Add(Song);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
