using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace WebApp.Controllers
{
    public class RegistrationsController : Controller
    {
        private readonly AppDbContext _context;

        public RegistrationsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Registrations
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Registrations.Include(r => r.Competition).Include(r => r.Dog).Include(r => r.Participant).Include(r => r.Show);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Registrations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registration = await _context.Registrations
                .Include(r => r.Competition)
                .Include(r => r.Dog)
                .Include(r => r.Participant)
                .Include(r => r.Show)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registration == null)
            {
                return NotFound();
            }

            return View(registration);
        }

        // GET: Registrations/Create
        public IActionResult Create()
        {
            ViewData["CompetitionId"] = new SelectList(_context.Competitions, "Id", "Id");
            ViewData["DogId"] = new SelectList(_context.Dogs, "Id", "DogName");
            ViewData["ParticipantId"] = new SelectList(_context.Participants, "Id", "FirstName");
            ViewData["ShowId"] = new SelectList(_context.Shows, "Id", "Id");
            return View();
        }

        // POST: Registrations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Comment,Start,End,DogId,ParticipantId,CompetitionId,ShowId,Id")] Registration registration)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registration);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompetitionId"] = new SelectList(_context.Competitions, "Id", "Id", registration.CompetitionId);
            ViewData["DogId"] = new SelectList(_context.Dogs, "Id", "DogName", registration.DogId);
            ViewData["ParticipantId"] = new SelectList(_context.Participants, "Id", "FirstName", registration.ParticipantId);
            ViewData["ShowId"] = new SelectList(_context.Shows, "Id", "Id", registration.ShowId);
            return View(registration);
        }

        // GET: Registrations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registration = await _context.Registrations.FindAsync(id);
            if (registration == null)
            {
                return NotFound();
            }
            ViewData["CompetitionId"] = new SelectList(_context.Competitions, "Id", "Id", registration.CompetitionId);
            ViewData["DogId"] = new SelectList(_context.Dogs, "Id", "DogName", registration.DogId);
            ViewData["ParticipantId"] = new SelectList(_context.Participants, "Id", "FirstName", registration.ParticipantId);
            ViewData["ShowId"] = new SelectList(_context.Shows, "Id", "Id", registration.ShowId);
            return View(registration);
        }

        // POST: Registrations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,Comment,Start,End,DogId,ParticipantId,CompetitionId,ShowId,Id")] Registration registration)
        {
            if (id != registration.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registration);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistrationExists(registration.Id))
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
            ViewData["CompetitionId"] = new SelectList(_context.Competitions, "Id", "Id", registration.CompetitionId);
            ViewData["DogId"] = new SelectList(_context.Dogs, "Id", "DogName", registration.DogId);
            ViewData["ParticipantId"] = new SelectList(_context.Participants, "Id", "FirstName", registration.ParticipantId);
            ViewData["ShowId"] = new SelectList(_context.Shows, "Id", "Id", registration.ShowId);
            return View(registration);
        }

        // GET: Registrations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registration = await _context.Registrations
                .Include(r => r.Competition)
                .Include(r => r.Dog)
                .Include(r => r.Participant)
                .Include(r => r.Show)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registration == null)
            {
                return NotFound();
            }

            return View(registration);
        }

        // POST: Registrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registration = await _context.Registrations.FindAsync(id);
            _context.Registrations.Remove(registration);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistrationExists(int id)
        {
            return _context.Registrations.Any(e => e.Id == id);
        }
    }
}
