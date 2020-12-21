using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using movie_tracker_razor.Data;
using movie_tracker_razor.Models;

namespace movie_tracker_razor.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly movie_tracker_razor.Data.movie_tracker_razorContext _context;
        private readonly IWebHostEnvironment _environment;

        public CreateModel(movie_tracker_razor.Data.movie_tracker_razorContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Movie Movie { get; set; }

        [BindProperty]
        public IFormFile Upload { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Upload != null)
            {
                var file = Path.Combine(_environment.WebRootPath, "images", Path.GetFileName(Upload.FileName));
                using (var fileStream = new FileStream(file, FileMode.Create))
                {
                    await Upload.CopyToAsync(fileStream);
                }

                Movie.ImageFile = Path.GetFileName(Upload.FileName);
            }

            _context.Movie.Add(Movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
