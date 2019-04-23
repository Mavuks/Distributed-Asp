using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
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
       
        private readonly IAppBLL _bll;

        public CompetitionsController(IAppBLL bll)
        {
            
            _bll = bll;
        }

        // GET: Competitions
        public async Task<IActionResult> Index()
        {

            return View(await _bll.Competition.AllAsync());
        }

        // GET: Competitions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competition = await _bll.Competition.FindAsync(id);
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
                DogSelectList = new SelectList(await _bll.Dog.AllAsync(), nameof(Dog.Id), nameof(Dog.DogName)),
                LocationSelectList = new SelectList(await _bll.Location.AllAsync(), nameof(Location.Id),
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
                await _bll.Competition.AddAsync(vm.Competition);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

           
            vm.LocationSelectList = new SelectList(await _bll.Location.AllAsync(), nameof(Location.Id),
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

            var competition = await _bll.Competition.FindAsync(id);
            if (competition == null)
            {
                return NotFound();
            }
            
            var vm = new CompetitionsCreateViewModel()
            {
                Competition = competition,
             LocationSelectList = new SelectList(await _bll.Location.AllAsync(), nameof(Location.Id), nameof(Location.Locations), competition.LocationId),

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
                _bll.Competition.Update(vm.Competition);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            vm.LocationSelectList = new SelectList(await _bll.Location.AllAsync(), nameof(Location.Id),
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

            var competition = await _bll.Competition.FindAsync(id);
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

            _bll.Competition.Remove(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}


