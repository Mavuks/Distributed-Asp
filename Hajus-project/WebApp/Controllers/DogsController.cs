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
using Domain.Identity;
using Identity;
using Microsoft.AspNetCore.Authorization;
using WebApp.ViewModels;

namespace WebApp.Controllers
{ 
    [Authorize]
    public class DogsController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        public DogsController( IAppUnitOfWork uow)
        {
            
            _uow = uow;
        }

        // GET: Dogs
        public async Task<IActionResult> Index()
        {

            var dogs = await _uow.Dog.AllAsync(User.GetUserId());
            return View(dogs);
        }

        // GET: Dogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dog = await _uow.Dog.FindAsync(id);
            if (dog == null)
            {
                return NotFound();
            }

            return View(dog);
        }

        // GET: Dogs/Create
        public  async Task<IActionResult> Create()
        {

            var vm = new DogCreateViewModel()
            {
                AppUserSelectList = new SelectList( await _uow.BaseRepository<AppUser>().AllAsync(),nameof(AppUser.Id),nameof(AppUser.FirstLastName) ),
                AwardSelectList = new SelectList(await _uow.Award.AllAsync(),nameof(Award.Id), nameof(Award.Place)),
                BreedSelectList = new SelectList(await _uow.Breed.AllAsync(), nameof(Breed.Id), nameof(Breed.BreedName))
                
            };
           
            return View(vm);
        }

        // POST: Dogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DogCreateViewModel vm)
        {
            
            
            if (ModelState.IsValid)
            {
                await _uow.Dog.AddAsync(vm.Dog);
                await _uow.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }

            vm.AppUserSelectList = new SelectList(await _uow.BaseRepository<AppUser>().AllAsync(), nameof(AppUser.Id),
                nameof(AppUser.FirstLastName), vm.Dog.AppUserId);
            vm.AwardSelectList = new SelectList(await _uow.Award.AllAsync(), nameof(Award.Id), nameof(Award.Place), vm.Dog.AwardId);
            vm.BreedSelectList  = new SelectList(await _uow.Breed.AllAsync(), nameof(Breed.Id),
                nameof(Breed.BreedName), vm.Dog.BreedId );


            
            return View(vm);
        }
        
        
        // GET: Dogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dog = await _uow.Dog.FindAsync((int)id);
            if (dog == null)
            {
                return NotFound();
            }
            
            var vm = new DogCreateViewModel()
            {
                Dog = dog,
                AppUserSelectList = new SelectList( await _uow.BaseRepository<AppUser>().AllAsync(),nameof(AppUser.Id),nameof(AppUser.FirstLastName), dog.AppUserId ),
                AwardSelectList = new SelectList(await _uow.Award.AllAsync(),nameof(Award.Id), nameof(Award.Place), dog.AwardId),
                BreedSelectList = new SelectList(await _uow.Breed.AllAsync(), nameof(Breed.Id), nameof(Breed.BreedName), dog.BreedId)
                
            };

            return View(vm);
        }

        // POST: Dogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DogCreateViewModel vm)
        {
            if (id != vm.Dog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.Dog.Update(vm.Dog);
                await _uow.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }
            
            vm.AppUserSelectList = new SelectList(await _uow.BaseRepository<AppUser>().AllAsync(), nameof(AppUser.Id),
                nameof(AppUser.FirstLastName), vm.Dog.AppUserId);
            vm.AwardSelectList = new SelectList(await _uow.Award.AllAsync(), nameof(Award.Id), nameof(Award.Place), vm.Dog.AwardId);
            vm.BreedSelectList  = new SelectList(await _uow.Breed.AllAsync(), nameof(Breed.Id),
                nameof(Breed.BreedName), vm.Dog.BreedId );

            return View(vm);
        }

        // GET: Dogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dog = await _uow.Dog.FindAsync(id);
                
            if (dog == null)
            {
                return NotFound();
            }

            return View(dog);
        }

        // POST: Dogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _uow.Dog.Remove(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

       
    }
}
