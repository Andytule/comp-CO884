using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using assignment3.Data;
using assignment3.Models;

namespace assignment3.Controllers
{
    public class DivisionsController : Controller
    {
        private readonly HASCContext _context;

        public DivisionsController(HASCContext context)
        {
            _context = context;
        }

        // GET: Divisions
        public async Task<IActionResult> Index(string sortOrder)
        {
            var divisions = from a in _context.Divisions
                            .OrderBy(a => a.DivisionName)
                            select a;
            return View(await divisions.AsNoTracking().ToListAsync());
        }
        
    }
}
