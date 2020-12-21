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
    public class NewScoreController : Controller
    {
        private readonly HASCContext _context;

        public NewScoreController(HASCContext context)
        {
            _context = context;
        }

        // GET: NewScore
        public async Task<IActionResult> Index(string refereeId)
        {
            var refereeNames = from b in _context.Referees
                               orderby b.LastName
                               select new { Name = b.FirstName + " " + b.LastName, b.RefereeId };

            ViewBag.RefereeId = new SelectList(refereeNames, "RefereeId", "Name");

            var games = from a in _context.Games
                        .Include(a => a.HomeTeam)
                        .Include(a => a.AwayTeam)
                        .Where(a => a.HomeTeamScore == null)
                        select a;

            if (!string.IsNullOrEmpty(refereeId))
            {
                games = games.Where(a => a.RefereeId.ToString() == refereeId);
            }

            return View(await games.AsNoTracking().ToListAsync());
        }

        // GET: NewScore/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Games
                .Include(g => g.AwayTeam)
                .Include(g => g.HomeTeam)
                .Include(g => g.Referee)
                .FirstOrDefaultAsync(m => m.GameId == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // GET: NewScore/Create
        public IActionResult Create()
        {
            ViewData["AwayTeamId"] = new SelectList(_context.Teams, "TeamId", "TeamId");
            ViewData["HomeTeamId"] = new SelectList(_context.Teams, "TeamId", "TeamId");
            ViewData["RefereeId"] = new SelectList(_context.Persons, "PersonId", "PersonId");
            return View();
        }

        // POST: NewScore/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GameId,GameDate,Field,HomeTeamId,HomeTeamScore,AwayTeamId,AwayTeamScore,RefereeId,GameNotes")] Game game)
        {
            if (ModelState.IsValid)
            {
                _context.Add(game);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AwayTeamId"] = new SelectList(_context.Teams, "TeamId", "TeamId", game.AwayTeamId);
            ViewData["HomeTeamId"] = new SelectList(_context.Teams, "TeamId", "TeamId", game.HomeTeamId);
            ViewData["RefereeId"] = new SelectList(_context.Persons, "PersonId", "PersonId", game.RefereeId);
            return View(game);
        }

        // GET: NewScore/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            ViewData["AwayTeamId"] = new SelectList(_context.Teams, "TeamId", "TeamId", game.AwayTeamId);
            ViewData["HomeTeamId"] = new SelectList(_context.Teams, "TeamId", "TeamId", game.HomeTeamId);
            ViewData["RefereeId"] = new SelectList(_context.Persons, "PersonId", "PersonId", game.RefereeId);
            return View(game);
        }

        // POST: NewScore/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GameId,GameDate,Field,HomeTeamId,HomeTeamScore,AwayTeamId,AwayTeamScore,RefereeId,GameNotes")] Game game)
        {
            if (id != game.GameId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(game);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameExists(game.GameId))
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
            ViewData["AwayTeamId"] = new SelectList(_context.Teams, "TeamId", "TeamId", game.AwayTeamId);
            ViewData["HomeTeamId"] = new SelectList(_context.Teams, "TeamId", "TeamId", game.HomeTeamId);
            ViewData["RefereeId"] = new SelectList(_context.Persons, "PersonId", "PersonId", game.RefereeId);
            return View(game);
        }

        // GET: NewScore/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Games
                .Include(g => g.AwayTeam)
                .Include(g => g.HomeTeam)
                .Include(g => g.Referee)
                .FirstOrDefaultAsync(m => m.GameId == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // POST: NewScore/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var game = await _context.Games.FindAsync(id);
            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameExists(int id)
        {
            return _context.Games.Any(e => e.GameId == id);
        }
    }
}
