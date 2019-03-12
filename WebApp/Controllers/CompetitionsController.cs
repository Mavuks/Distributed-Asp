using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain;

namespace WebApp.Controllers
{
    public class CompetitionsController : Controller
    {
        private readonly AppDbContext _context;

        public CompetitionsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Competitions
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Competitions.Include(c => c.Dog).Include(c => c.Location).Include(c => c.Participant);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Competitions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competition = await _context.Competitions
                .Include(c => c.Dog)
                .Include(c => c.Location)
                .Include(c => c.Participant)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (competition == null)
            {
                return NotFound();
            }

            return View(competition);
        }

        // GET: Competitions/Create
        public IActionResult Create()
        {
            ViewData["DogId"] = new SelectList(_context.Dogs, "Id", "DogName");
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id");
            ViewData["ParticipantId"] = new SelectList(_context.Participants, "Id", "FirstName");
            return View();
        }

        // POST: Competitions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Comment,Award,Start,End,DogId,LocationId,ParticipantId,Id")] Competition competition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(competition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DogId"] = new SelectList(_context.Dogs, "Id", "DogName", competition.DogId);
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id", competition.LocationId);
            ViewData["ParticipantId"] = new SelectList(_context.Participants, "Id", "FirstName", competition.ParticipantId);
            return View(competition);
        }

        // GET: Competitions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competition = await _context.Competitions.FindAsync(id);
            if (competition == null)
            {
                return NotFound();
            }
            ViewData["DogId"] = new SelectList(_context.Dogs, "Id", "DogName", competition.DogId);
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id", competition.LocationId);
            ViewData["ParticipantId"] = new SelectList(_context.Participants, "Id", "FirstName", competition.ParticipantId);
            return View(competition);
        }

        // POST: Competitions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,Comment,Award,Start,End,DogId,LocationId,ParticipantId,Id")] Competition competition)
        {
            if (id != competition.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(competition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompetitionExists(competition.Id))
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
            ViewData["DogId"] = new SelectList(_context.Dogs, "Id", "DogName", competition.DogId);
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id", competition.LocationId);
            ViewData["ParticipantId"] = new SelectList(_context.Participants, "Id", "FirstName", competition.ParticipantId);
            return View(competition);
        }

        // GET: Competitions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competition = await _context.Competitions
                .Include(c => c.Dog)
                .Include(c => c.Location)
                .Include(c => c.Participant)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (competition == null)
            {
                return NotFound();
            }

            return View(competition);
        }

        // POST: Competitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var competition = await _context.Competitions.FindAsync(id);
            _context.Competitions.Remove(competition);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompetitionExists(int id)
        {
            return _context.Competitions.Any(e => e.Id == id);
        }
    }
}
