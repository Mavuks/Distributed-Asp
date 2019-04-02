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
    public class RegistrationsController : Controller
    {
        

        private readonly IAppUnitOfWork _uow;

        public RegistrationsController(IAppUnitOfWork uow)
        {
            
            _uow = uow;
        }

        // GET: Registrations
        public async Task<IActionResult> Index()
        {
         
            return View(await _uow.Registration.AllAsync());
        }

        // GET: Registrations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registration = await _uow.Registration.FindAsync(id);
            if (registration == null)
            {
                return NotFound();
            }

            return View(registration);
        }

        // GET: Registrations/Create
        public async Task<IActionResult> Create()
        {

            var vm = new RegistrationsCreateViewModel()
            {
                CompetitionSelectList = new SelectList(await _uow.Competition.AllAsync(), nameof(Competition.Id),nameof(Competition.Title)),
                DogSelectList = new SelectList(await _uow.Dog.AllAsync(), nameof(Dog.Id), nameof(Dog.DogName)),
                ParticipantSelectList = new SelectList(await _uow.Participant.AllAsync(), nameof(Participant.Id), nameof(Participant.FirstName)),
                ShowSelectList = new SelectList(await _uow.Show.AllAsync(), nameof(Show.Id), nameof(Show.Title))
            };

            return View(vm);
        }

        // POST: Registrations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegistrationsCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _uow.Registration.AddAsync(vm.Registration);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }


            vm.CompetitionSelectList = new SelectList(await _uow.Competition.AllAsync(), nameof(Competition.Id),
                nameof(Competition.Title), vm.Registration.CompetitionId);
            vm.DogSelectList = new SelectList(await _uow.Dog.AllAsync(), nameof(Dog.Id), nameof(Dog.DogName), vm.Registration.DogId);
            vm.ParticipantSelectList = new SelectList(await _uow.Participant.AllAsync(), nameof(Participant.Id),
                nameof(Participant.FirstName), vm.Registration.ParticipantId);
            vm.ShowSelectList = new SelectList(await _uow.Show.AllAsync(), nameof(Show.Id), nameof(Show.Title), vm.Registration.ShowId);

            return View(vm);
        }

        // GET: Registrations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registration = await _uow.Registration.FindAsync(id);
            if (registration == null)
            {
                return NotFound();
            }
            
            var vm = new RegistrationsCreateViewModel()
            {
                Registration = registration,
                CompetitionSelectList = new SelectList(await _uow.Competition.AllAsync(), nameof(Competition.Id),nameof(Competition.Title), registration.CompetitionId),
                DogSelectList = new SelectList(await _uow.Dog.AllAsync(), nameof(Dog.Id), nameof(Dog.DogName), registration.DogId),
                ParticipantSelectList = new SelectList(await _uow.Participant.AllAsync(), nameof(Participant.Id), nameof(Participant.FirstName), registration.ParticipantId),
                ShowSelectList = new SelectList(await _uow.Show.AllAsync(), nameof(Show.Id), nameof(Show.Title), registration.ShowId)
            };

            return View(vm);
        }

        // POST: Registrations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RegistrationsCreateViewModel vm)
        {
            if (id != vm.Registration.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.Registration.Update(vm.Registration);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            vm.CompetitionSelectList = new SelectList(await _uow.Competition.AllAsync(), nameof(Competition.Id),
                nameof(Competition.Title), vm.Registration.CompetitionId);
            vm.DogSelectList = new SelectList(await _uow.Dog.AllAsync(), nameof(Dog.Id), nameof(Dog.DogName), vm.Registration.DogId);
            vm.ParticipantSelectList = new SelectList(await _uow.Participant.AllAsync(), nameof(Participant.Id),
                nameof(Participant.FirstName), vm.Registration.ParticipantId);
            vm.ShowSelectList = new SelectList(await _uow.Show.AllAsync(), nameof(Show.Id), nameof(Show.Title), vm.Registration.ShowId);

            return View(vm);
        }

        // GET: Registrations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registration = await _uow.Registration.FindAsync(id);
            
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
            _uow.Registration.Remove(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    
    }
}
