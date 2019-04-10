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

            return View(await _uow.Competition.AllAsync());
        }

        // GET: Competitions/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: Competitions/Create
        public async Task<IActionResult> Create()
        {

            var vm = new CompetitionsCreateViewModel()
            {
                DogSelectList = new SelectList(await _uow.Dog.AllAsync(), nameof(Dog.Id), nameof(Dog.DogName)),
                LocationSelectList = new SelectList(await _uow.Location.AllAsync(), nameof(Location.Id),
                    nameof(Location.Locations)),
                

            };

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

           
            vm.LocationSelectList = new SelectList(await _uow.Location.AllAsync(), nameof(Location.Id),
                nameof(Location.Locations), vm.Competition.LocationId);
            

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
                Competition = competition,
             LocationSelectList = new SelectList(await _uow.Location.AllAsync(), nameof(Location.Id), nameof(Location.Locations), competition.LocationId),

            };

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
            
            vm.LocationSelectList = new SelectList(await _uow.Location.AllAsync(), nameof(Location.Id),
                nameof(Location.Locations), vm.Competition.LocationId);


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


