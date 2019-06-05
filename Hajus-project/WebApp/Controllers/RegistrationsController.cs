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
using ee.itcollege.mavuks.Identity;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class RegistrationsController : Controller
    {
        
        private readonly IAppBLL _bll;

        public RegistrationsController(IAppBLL bll)
        {
            
            _bll = bll;
        }

        // GET: Registrations
        public async Task<IActionResult> Index()
        {
         
            return View(await _bll.Registration.AllForUserAsync(User.GetUserId()));
        }

        // GET: Registrations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registration = await _bll.Registration.FindAsync(id.Value);
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
                CompetitionSelectList = new SelectList(await _bll.Competition.AllAsync(), nameof( BLL.App.DTO.Competition.Id),nameof( BLL.App.DTO.Competition.Title)),
                DogSelectList = new SelectList(await _bll.Dog.AllAsync(), nameof( BLL.App.DTO.Dog.Id), nameof( BLL.App.DTO.Dog.DogName)),
                ParticipantSelectList = new SelectList(await _bll.Participant.AllAsync(), nameof( BLL.App.DTO.Participant.Id), nameof( BLL.App.DTO.Participant.FirstName)),
                ShowSelectList = new SelectList(await _bll.Show.AllAsync(), nameof( BLL.App.DTO.Show.Id), nameof( BLL.App.DTO.Show.Title)),
                SchoolingSelectList =  new SelectList(await _bll.Schooling.AllAsync(), nameof(BLL.App.DTO.Schooling.Id),  nameof(BLL.App.DTO.Schooling.SchoolingName))
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
                await _bll.Registration.AddAsync(vm.Registration);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }


            vm.CompetitionSelectList = new SelectList(await _bll.Competition.AllAsync(), nameof( BLL.App.DTO.Competition.Id),
                nameof( BLL.App.DTO.Competition.Title), vm.Registration.CompetitionId);
            vm.DogSelectList = new SelectList(await _bll.Dog.AllAsync(), nameof( BLL.App.DTO.Dog.Id), nameof( BLL.App.DTO.Dog.DogName), vm.Registration.DogId);
            vm.ParticipantSelectList = new SelectList(await _bll.Participant.AllAsync(), nameof( BLL.App.DTO.Participant.Id),
                nameof( BLL.App.DTO.Participant.FirstName), vm.Registration.ParticipantId);
            vm.ShowSelectList = new SelectList(await _bll.Show.AllAsync(), nameof( BLL.App.DTO.Show.Id), nameof( BLL.App.DTO.Show.Title), vm.Registration.ShowId);
            vm.SchoolingSelectList = new SelectList(await _bll.Schooling.AllAsync(), nameof(BLL.App.DTO.Schooling.Id),
                nameof(BLL.App.DTO.Schooling.SchoolingName), vm.Registration.SchoolingId);

            return View(vm);
        }

        // GET: Registrations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registration = await _bll.Registration.FindAsync(id.Value);
            if (registration == null)
            {
                return NotFound();
            }
            
            var vm = new RegistrationsCreateViewModel()
            {
                Registration = registration,
                CompetitionSelectList = new SelectList(await _bll.Competition.AllAsync(), nameof( BLL.App.DTO.Competition.Id),nameof( BLL.App.DTO.Competition.Title), registration.CompetitionId),
                DogSelectList = new SelectList(await _bll.Dog.AllAsync(), nameof( BLL.App.DTO.Dog.Id), nameof( BLL.App.DTO.Dog.DogName), registration.DogId),
                ParticipantSelectList = new SelectList(await _bll.Participant.AllAsync(), nameof( BLL.App.DTO.Participant.Id), nameof( BLL.App.DTO.Participant.FirstName), registration.ParticipantId),
                ShowSelectList = new SelectList(await _bll.Show.AllAsync(), nameof( BLL.App.DTO.Show.Id), nameof( BLL.App.DTO.Show.Title), registration.ShowId),
                SchoolingSelectList =  new SelectList(await _bll.Schooling.AllAsync(), nameof(BLL.App.DTO.Schooling.Id),  nameof(BLL.App.DTO.Schooling.SchoolingName))
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
                _bll.Registration.Update(vm.Registration);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            vm.CompetitionSelectList = new SelectList(await _bll.Competition.AllAsync(), nameof(Competition.Id),
                nameof(Competition.Title), vm.Registration.CompetitionId);
            vm.DogSelectList = new SelectList(await _bll.Dog.AllAsync(), nameof(Dog.Id), nameof(Dog.DogName), vm.Registration.DogId);
            vm.ParticipantSelectList = new SelectList(await _bll.Participant.AllAsync(), nameof(Participant.Id),
                nameof(Participant.FirstName), vm.Registration.ParticipantId);
            vm.ShowSelectList = new SelectList(await _bll.Show.AllAsync(), nameof(Show.Id), nameof(Show.Title), vm.Registration.ShowId);
            vm.SchoolingSelectList = new SelectList(await _bll.Schooling.AllAsync(), nameof(BLL.App.DTO.Schooling.Id),
                nameof(BLL.App.DTO.Schooling.SchoolingName), vm.Registration.SchoolingId);

            return View(vm);
        }

        // GET: Registrations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registration = await _bll.Registration.FindAsync(id);
            
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
            _bll.Registration.Remove(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    
    }
}
