using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospital.Data;
using Hospital.Models;

namespace Hospital.Controllers
{
    public class CurrentAdmissionsController : Controller
    {
        private readonly CHDBContext _context;

        public CurrentAdmissionsController(CHDBContext context)
        {
            _context = context;
        }

        // GET: CurrentAdmissions
        public async Task<IActionResult> Index(string nursingUnitId)
        {
            var nursingUnits = from n in _context.NursingUnits
                               orderby n.ManagerLastName
                               select new { Name = n.ManagerFirstName + " " + n.ManagerLastName, n.NursingUnitId };

            ViewBag.NursingUnitId = new SelectList(nursingUnits, "NursingUnitId", "Name");

            var admissions = from a in _context.Admissions
                             .Include(a => a.Patient)
                             .Where(a => a.DischargeDate == null)
                             .OrderBy(a => a.Patient.LastName)
                             .ThenBy(a => a.Patient.FirstName)
                             select a;

            if (!string.IsNullOrEmpty(nursingUnitId))
            {
                admissions = admissions.Where(a => a.NursingUnitId == nursingUnitId);
            }

            return View(await admissions.AsNoTracking().ToListAsync());
        }

        // GET: CurrentAdmissions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admissions = await _context.Admissions
                .Include(a => a.AttendingPhysician)
                .Include(a => a.NursingUnit)
                .Include(a => a.Patient)
                .FirstOrDefaultAsync(m => m.PatientId == id);
            if (admissions == null)
            {
                return NotFound();
            }

            return View(admissions);
        }

        // GET: CurrentAdmissions/Create
        public IActionResult Create()
        {
            ViewData["AttendingPhysicianId"] = new SelectList(_context.Physicians, "PhysicianId", "PhysicianId");
            ViewData["NursingUnitId"] = new SelectList(_context.NursingUnits, "NursingUnitId", "NursingUnitId");
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "PatientId");
            return View();
        }

        // POST: CurrentAdmissions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PatientId,AdmissionDate,DischargeDate,PrimaryDiagnosis,SecondaryDiagnoses,AttendingPhysicianId,NursingUnitId,Room,Bed")] Admissions admissions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(admissions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AttendingPhysicianId"] = new SelectList(_context.Physicians, "PhysicianId", "PhysicianId", admissions.AttendingPhysicianId);
            ViewData["NursingUnitId"] = new SelectList(_context.NursingUnits, "NursingUnitId", "NursingUnitId", admissions.NursingUnitId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "PatientId", admissions.PatientId);
            return View(admissions);
        }

        // GET: CurrentAdmissions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admissions = await _context.Admissions.FindAsync(id);
            if (admissions == null)
            {
                return NotFound();
            }
            ViewData["AttendingPhysicianId"] = new SelectList(_context.Physicians, "PhysicianId", "PhysicianId", admissions.AttendingPhysicianId);
            ViewData["NursingUnitId"] = new SelectList(_context.NursingUnits, "NursingUnitId", "NursingUnitId", admissions.NursingUnitId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "PatientId", admissions.PatientId);
            return View(admissions);
        }

        // POST: CurrentAdmissions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PatientId,AdmissionDate,DischargeDate,PrimaryDiagnosis,SecondaryDiagnoses,AttendingPhysicianId,NursingUnitId,Room,Bed")] Admissions admissions)
        {
            if (id != admissions.PatientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(admissions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdmissionsExists(admissions.PatientId))
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
            ViewData["AttendingPhysicianId"] = new SelectList(_context.Physicians, "PhysicianId", "PhysicianId", admissions.AttendingPhysicianId);
            ViewData["NursingUnitId"] = new SelectList(_context.NursingUnits, "NursingUnitId", "NursingUnitId", admissions.NursingUnitId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "PatientId", admissions.PatientId);
            return View(admissions);
        }

        // GET: CurrentAdmissions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admissions = await _context.Admissions
                .Include(a => a.AttendingPhysician)
                .Include(a => a.NursingUnit)
                .Include(a => a.Patient)
                .FirstOrDefaultAsync(m => m.PatientId == id);
            if (admissions == null)
            {
                return NotFound();
            }

            return View(admissions);
        }

        // POST: CurrentAdmissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var admissions = await _context.Admissions.FindAsync(id);
            _context.Admissions.Remove(admissions);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdmissionsExists(int id)
        {
            return _context.Admissions.Any(e => e.PatientId == id);
        }
    }
}
