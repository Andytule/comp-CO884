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
    public class RegisterController : Controller
    {
        private readonly HASCContext _context;

        public RegisterController(HASCContext context)
        {
            _context = context;
        }

        // GET: Register
        public async Task<IActionResult> Index()
        {
            var hASCContext = _context.Persons.Include(p => p.Division).Include(p => p.Province).Include(p => p.SkillLevelNavigation).Include(p => p.Team);
            return View(await hASCContext.ToListAsync());
        }

        // GET: Register/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Persons
                .Include(p => p.Division)
                .Include(p => p.Province)
                .Include(p => p.SkillLevelNavigation)
                .Include(p => p.Team)
                .FirstOrDefaultAsync(m => m.PersonId == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // GET: Register/Create
        public IActionResult Create()
        {
            ViewBag.DivisionId = new SelectList(_context.Divisions.ToList(), "DivisionId", "DivisionName");
            return View();
        }

        // POST: Register/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonId,FirstName,LastName,DivisionId,Email,Gender,BirthDate,AddressLine1,AddressLine2,City,ProvinceId,PostalCode,Phone,Player,SkillLevel,TeamId,JerseyNumber,Coach,CoachingExperience,Referee,RefereeExperience,Administrator,UserPassword")] Person person)
        {
            var maxId = from a in _context.Persons
                        select a.PersonId;

            int id = maxId.Max();

            if (ModelState.IsValid)
            {
                ViewBag.Message = "";
                if ((18 < DateTime.Today.Year - person.BirthDate.Value.Year) || ((18 == DateTime.Today.Year - person.BirthDate.Value.Year) && (person.BirthDate.Value.Month < DateTime.Today.Month)) || ((18 == DateTime.Today.Year - person.BirthDate.Value.Year) && (person.BirthDate.Value.Month == DateTime.Today.Month) && (person.BirthDate.Value.Day <= DateTime.Today.Day)))
                {
                    person.PersonId = id + 1;

                    _context.Add(person);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                } 
                else
                {
                    ViewBag.Message = "You must be at least 18 years of age to join the club.";
                }
                
            }
            ViewBag.DivisionId = new SelectList(_context.Divisions.ToList(), "DivisionId", "DivisionName");
            return View(person);
        }

        // GET: Register/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Persons.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            ViewData["DivisionId"] = new SelectList(_context.Divisions, "DivisionId", "DivisionId", person.DivisionId);
            ViewData["ProvinceId"] = new SelectList(_context.Provinces, "ProvinceId", "ProvinceId", person.ProvinceId);
            ViewData["SkillLevel"] = new SelectList(_context.Skills, "SkillLevel", "SkillLevel", person.SkillLevel);
            ViewData["TeamId"] = new SelectList(_context.Teams, "TeamId", "TeamId", person.TeamId);
            return View(person);
        }

        // POST: Register/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PersonId,FirstName,LastName,DivisionId,Email,Gender,BirthDate,AddressLine1,AddressLine2,City,ProvinceId,PostalCode,Phone,Player,SkillLevel,TeamId,JerseyNumber,Coach,CoachingExperience,Referee,RefereeExperience,Administrator,UserPassword")] Person person)
        {
            if (id != person.PersonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(person.PersonId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DivisionId"] = new SelectList(_context.Divisions, "DivisionId", "DivisionId", person.DivisionId);
            ViewData["ProvinceId"] = new SelectList(_context.Provinces, "ProvinceId", "ProvinceId", person.ProvinceId);
            ViewData["SkillLevel"] = new SelectList(_context.Skills, "SkillLevel", "SkillLevel", person.SkillLevel);
            ViewData["TeamId"] = new SelectList(_context.Teams, "TeamId", "TeamId", person.TeamId);
            return View(person);
        }

        // GET: Register/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Persons
                .Include(p => p.Division)
                .Include(p => p.Province)
                .Include(p => p.SkillLevelNavigation)
                .Include(p => p.Team)
                .FirstOrDefaultAsync(m => m.PersonId == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: Register/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var person = await _context.Persons.FindAsync(id);
            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonExists(int id)
        {
            return _context.Persons.Any(e => e.PersonId == id);
        }
    }
}
