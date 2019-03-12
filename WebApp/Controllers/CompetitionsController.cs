using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain;
using Identity;

namespace WebApp.Controllers
{
    public class CompetitionsController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public CompetitionsController(IAppUnitOfWork uow)
        {
            
            _uow = uow;
        }

        // GET: Competitions
        public async Task<IActionResult> Index()
        {
//            var appDbContext = _context.Competitions.Include(c => c.Dog).Include(c => c.Location).Include(c => c.Participant);
//            return View(await appDbContext.ToListAsync());

            var competitions = await _uow.Competition.AllAsync(User.GetUserId());
            return View(competitions);
        }

        // GET: Competitions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

//            var competition = await _context.Competitions
//                .Include(c => c.Dog)
//                .Include(c => c.Location)
//                .Include(c => c.Participant)
//                .FirstOrDefaultAsync(m => m.Id == id);
            var competition = await _uow.Competition.FindAsync(id);
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
                await _uow.Competition.AddAsync(competition);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DogId"] = new SelectList(await _uow.BaseRepository<Dog>().AllAsync(), "Id", "DogName", competition.DogId);
            ViewData["LocationId"] = new SelectList(await _uow.BaseRepository<Location>().AllAsync(), "Id", "Id", competition.LocationId);
            ViewData["ParticipantId"] = new SelectList(await _uow.BaseRepository<Participant>().AllAsync(), "Id", "FirstName", competition.ParticipantId);
            return View(competition);
        }

        // GET: Competitions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competition = await _uow.Competition.FindAsync(id);
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

            var competition = await _uow.Competition.AllAsync(User.GetUserId());
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
            
            _uow.Competition.Remove(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

}
