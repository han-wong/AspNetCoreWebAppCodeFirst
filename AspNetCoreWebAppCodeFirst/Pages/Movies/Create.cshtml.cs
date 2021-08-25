using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AspNetCoreWebAppCodeFirst.Data;

namespace AspNetCoreWebAppCodeFirst.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Movie Movie { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                Movie = new Movie();

                if (await TryUpdateModelAsync<Movie>(
                    Movie,
                    "movie",   // Prefix for form value.
                    movie => movie.Title, movie => movie.ReleaseDate, movie => movie.Genre, movie => movie.Price))
                {
                    _context.Movies.Add(Movie);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }

            }
            return Page();
        }
    }
}
