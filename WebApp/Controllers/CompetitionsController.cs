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
using WebApp.ViewModels;

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

//            var competitions = await _uow.Competition.AllAsync(User.GetUserId());
            return View(await _uow.Competition.AllAsync());
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
        public async Task<IActionResult> Create()
        {

            var vm = new CompetitionsCreateViewModel()
            {
                DogSelectList = new SelectList(await _uow.Dog.AllAsync(), nameof(Dog.Id), nameof(Dog.DogName)),
                LocationSelectList = new SelectList(await _uow.Location.AllAsync(), nameof(Location.Id),
                    nameof(Location.Locations)),
                ParticipantSelectList = new SelectList(await _uow.Participant.AllAsync(), nameof(Participant.Id), nameof(Participant.FirstName))

            };
            
            //  ViewData["DogId"] = new SelectList(_context.Dogs, "Id", "DogName");
            //   ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id");
            //  ViewData["ParticipantId"] = new SelectList(_context.Participants, "Id", "FirstName");
            return View(vm);
        }

        // POST: Competitions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( CompetitionsCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _uow.Competition.AddAsync(vm.Competition);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            vm.DogSelectList = new SelectList(await _uow.Dog.AllAsync(), nameof(Dog.Id), nameof(Dog.DogName), vm.Competition.DogId);
            vm.LocationSelectList = new SelectList(await _uow.Location.AllAsync(), nameof(Location.Id),
                nameof(Location.Locations), vm.Competition.LocationId);
            vm.ParticipantSelectList = new SelectList(await _uow.Participant.AllAsync(), nameof(Participant.Id),
                nameof(Participant.FirstName), vm.Competition.ParticipantId);



//            ViewData["DogId"] = new SelectList(await _uow.BaseRepository<Dog>().AllAsync(), "Id", "DogName",
//                competition.DogId);
//            ViewData["LocationId"] = new SelectList(await _uow.BaseRepository<Location>().AllAsync(), "Id", "Id",
//                competition.LocationId);
//            ViewData["ParticipantId"] = new SelectList(await _uow.BaseRepository<Participant>().AllAsync(), "Id",
//                "FirstName", competition.ParticipantId);
            return View(vm);
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
            
            var vm = new CompetitionsCreateViewModel()
            {
             DogSelectList   =  new SelectList(await _uow.Dog.AllAsync(), nameof(Dog.Id), nameof(Dog.DogName), competition.DogId),
             LocationSelectList = new SelectList(await _uow.Location.AllAsync(), nameof(Location.Id), nameof(Location.Locations), competition.LocationId),
             ParticipantSelectList = new SelectList(await _uow.Participant.AllAsync(), nameof(Participant.Id),
                 nameof(Participant.FirstName), competition.ParticipantId)
            };
                
//            ViewData["DogId"] = new SelectList(await _uow.BaseRepository<Dog>().AllAsync(), "Id", "DogName",
//                competition.DogId);
//            ViewData["LocationId"] = new SelectList(await _uow.BaseRepository<Location>().AllAsync(), "Id", "Id",
//                competition.LocationId);
//            ViewData["ParticipantId"] = new SelectList(await _uow.BaseRepository<Participant>().AllAsync(), "Id",
//                "FirstName", competition.ParticipantId);
            return View(vm);
        }

        // POST: Competitions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CompetitionsCreateViewModel vm)
        {
            if (id != vm.Competition.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.Competition.Update(vm.Competition);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            vm.DogSelectList = new SelectList(await _uow.Dog.AllAsync(), nameof(Dog.Id), nameof(Dog.DogName), vm.Competition.DogId);
            vm.LocationSelectList = new SelectList(await _uow.Location.AllAsync(), nameof(Location.Id),
                nameof(Location.Locations), vm.Competition.LocationId);
            vm.ParticipantSelectList = new SelectList(await _uow.Participant.AllAsync(), nameof(Participant.Id),
                nameof(Participant.FirstName), vm.Competition.ParticipantId);

//            ViewData["DogId"] = new SelectList(await _uow.BaseRepository<Dog>().AllAsync(), "Id", "DogName",
//                competition.DogId);
//            ViewData["LocationId"] = new SelectList(await _uow.BaseRepository<Location>().AllAsync(), "Id", "Id",
//                competition.LocationId);
//            ViewData["ParticipantId"] = new SelectList(await _uow.BaseRepository<Participant>().AllAsync(), "Id",
//                "FirstName", competition.ParticipantId);
            return View(vm);
        }

        // GET: Competitions/Delete/5
        public async Task<IActionResult> Delete(int? id)
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
}


