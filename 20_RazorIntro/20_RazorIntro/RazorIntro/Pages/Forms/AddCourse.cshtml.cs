using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorIntro.Models;

namespace RazorIntro.Pages.Forms
{
    public class AddCourseModel : PageModel
    {
        [BindProperty]
        public Course Course { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            return RedirectToPage("/Index", new { Course.CourseName });
        }
    }
}
