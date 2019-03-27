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
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class ShowsController : Controller
    {
        

        private readonly IAppUnitOfWork _uow;

        public ShowsController( IAppUnitOfWork uow)
        {
           
            _uow = uow;
        }

        // GET: Shows
        public async Task<IActionResult> Index()
        {
            //var appDbContext = _context.Shows.Include(s => s.Dog).Include(s => s.Location).Include(s => s.Participant);
            return View(await _uow.Show.AllAsync());
        }

        // GET: Shows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var show = await _uow.Show.FindAsync(id);
            if (show == null)
            {
                return NotFound();
            }

            return View(show);
        }

        // GET: Shows/Create
        public async Task<IActionResult> Create()
        {

            var vm = new ShowCreateViewModel()
            {
                DogSelectList = new SelectList(await _uow.Dog.AllAsync(),nameof(Dog.Id),nameof(Dog.DogName)),
                LocationSelectList = new SelectList(await _uow.Location.AllAsync(),nameof(Location.Id), nameof(Location.Locations)),
                ParticipantSelectList = new SelectList(await _uow.Participant.AllAsync(),nameof(Participant.Id),nameof(Participant.FirstName))
            };
            
            
            return View(vm);
        }

        // POST: Shows/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ShowCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _uow.Show.AddAsync(vm.Show);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            vm.DogSelectList = new SelectList(await _uow.Dog.AllAsync(), nameof(Dog.Id), nameof(Dog.DogName), vm.Show.DogId);
            vm.LocationSelectList = new SelectList(await _uow.Location.AllAsync(), nameof(Location.Id),
                nameof(Location.Locations), vm.Show.LocationId);
            vm.ParticipantSelectList = new SelectList(await _uow.Participant.AllAsync(), nameof(Participant.Id),
                nameof(Participant.FirstName), vm.Show.ParticipantId);
            
            return View(vm);
        }

        // GET: Shows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var show = await _uow.Show.FindAsync(id);
            if (show == null)
            {
                return NotFound();
            }
            
            var vm = new ShowCreateViewModel()
            {
                DogSelectList = new SelectList(await _uow.Dog.AllAsync(),nameof(Dog.Id),nameof(Dog.DogName), show.DogId),
                LocationSelectList = new SelectList(await _uow.Location.AllAsync(),nameof(Location.Id), nameof(Location.Locations), show.LocationId),
                ParticipantSelectList = new SelectList(await _uow.Participant.AllAsync(),nameof(Participant.Id),nameof(Participant.FirstName), show.ParticipantId)
            };

            
            
            return View(vm);
        }

        // POST: Shows/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ShowCreateViewModel vm)
        {
            if (id != vm.Show.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.Show.Update(vm.Show);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            vm.DogSelectList = new SelectList(await _uow.Dog.AllAsync(), nameof(Dog.Id), nameof(Dog.DogName), vm.Show.DogId);
            vm.LocationSelectList = new SelectList(await _uow.Location.AllAsync(), nameof(Location.Id),
                nameof(Location.Locations), vm.Show.LocationId);
            vm.ParticipantSelectList = new SelectList(await _uow.Participant.AllAsync(), nameof(Participant.Id),
                nameof(Participant.FirstName), vm.Show.ParticipantId);

            return View(vm);
        }

        // GET: Shows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var show = await _uow.Show.FindAsync(id);
            if (show == null)
            {
                return NotFound();
            }

            return View(show);
        }

        // POST: Shows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            _uow.Show.Remove(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

       
    }
}
