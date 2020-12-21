using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using movie_tracker_razor.Data;
using movie_tracker_razor.Models;

namespace movie_tracker_razor.Pages.Movies
{
    public class DetailsModel : PageModel
    {
        private readonly movie_tracker_razor.Data.movie_tracker_razorContext _context;

        public DetailsModel(movie_tracker_razor.Data.movie_tracker_razorContext context)
        {
            _context = context;
        }

        public Movie Movie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = await _context.Movie.FirstOrDefaultAsync(m => m.Id == id);

            if (Movie == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
