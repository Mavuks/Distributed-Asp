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
    public class AwardsController : Controller
    {
        

        private readonly IAppUnitOfWork _uow;

        public AwardsController(IAppUnitOfWork uow)
        {
            
            _uow = uow;
        }

        // GET: Awards
        public async Task<IActionResult> Index()
        {
            var award = await _uow.Award.AllAsync();

            return View(award);
        }

        // GET: Awards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var award = await _uow.Award.FindAsync(id);
            if (award == null)
            {
                return NotFound();
            }

            return View(award);
        }

        // GET: Awards/Create
        public async Task<IActionResult> Create()
        {
            var vm = new AwardCreateViewModel()
            {
                CompetitionSelectList = new SelectList(await _uow.Competition.AllAsync(),nameof(Competition.Id),nameof(Competition.Title)),
                ShowSelectList = new SelectList(await _uow.Show.AllAsync(),nameof(Show.Id),nameof(Show.Title))
                
            };

            return View(vm);
        }

        // POST: Awards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AwardCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _uow.Award.AddAsync(vm.Award);
                
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }


            vm.CompetitionSelectList = new SelectList(await _uow.Competition.AllAsync(), nameof(Competition.Id),
                nameof(Competition.Title), vm.Award.CompetitionId);

            vm.ShowSelectList = new SelectList(await _uow.Show.AllAsync(), nameof(Show.Id), nameof(Show.Title),
                vm.Award.ShowId);

            return View(vm);
        }

        // GET: Awards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var award = await _uow.Award.FindAsync(id);
            if (award == null)
            {
                return NotFound();
            }

            var vm = new AwardCreateViewModel()
            {
                CompetitionSelectList = new SelectList(await _uow.Competition.AllAsync(), nameof(Competition.Id),
                    nameof(Competition.Title), award.CompetitionId),
                ShowSelectList = new SelectList(await _uow.Show.AllAsync(), nameof(Show.Id), nameof(Show.Title),
                    award.ShowId)
            };

            return View(vm);
        }

        // POST: Awards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AwardCreateViewModel vm)
        {
            if (id != vm.Award.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.Award.Update(vm.Award);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            vm.CompetitionSelectList = new SelectList(await _uow.Competition.AllAsync(), nameof(Competition.Id),
                nameof(Competition.Title), vm.Award.CompetitionId);

            vm.ShowSelectList = new SelectList(await _uow.Show.AllAsync(), nameof(Show.Id), nameof(Show.Title),
                vm.Award.ShowId);

            return View(vm);
        }

        // GET: Awards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var award = await _uow.Award.FindAsync(id);
            if (award == null)
            {
                return NotFound();
            }

            return View(award);
        }

        // POST: Awards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _uow.Award.Remove(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
