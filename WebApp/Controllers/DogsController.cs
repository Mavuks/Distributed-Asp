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
//            var appDbContext = _context.Dogs.Include(d => d.AppUser).Include(d => d.Award).Include(d => d.Breed);
//            return View(await appDbContext.ToListAsync());
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

//            var dog = await _context.Dogs
//                .Include(d => d.AppUser)
//                .Include(d => d.Award)
//                .Include(d => d.Breed)
//                .FirstOrDefaultAsync(m => m.Id == id);

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
            
            
//            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id");
//            ViewData["AwardId"] = new SelectList(_context.Awards, "Id", "Id");
//            ViewData["BreedId"] = new SelectList(_context.Breeds, "Id", "Id");


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
            
//            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", dog.AppUserId);

//            ViewData["AwardId"] = new SelectList(_context.Awards, "Id", "Id", dog.AwardId);
//            ViewData["BreedId"] = new SelectList(_context.Breeds, "Id", "Id", dog.BreedId);

            
            return View(vm);
        }
        
        
        // GET: Dogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
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
            
            var vm = new DogCreateViewModel()
            {
                AppUserSelectList = new SelectList( await _uow.BaseRepository<AppUser>().AllAsync(),nameof(AppUser.Id),nameof(AppUser.FirstLastName), dog.AppUserId ),
                AwardSelectList = new SelectList(await _uow.Award.AllAsync(),nameof(Award.Id), nameof(Award.Place), dog.AwardId),
                BreedSelectList = new SelectList(await _uow.Breed.AllAsync(), nameof(Breed.Id), nameof(Breed.BreedName), dog.BreedId)
                
            };
            
            
//            ViewData["AppUserId"] = new SelectList(await _uow.BaseRepository<AppUser>().AllAsync(), "Id", "Id", dog.AppUserId);
//            ViewData["AwardId"] = new SelectList(await _uow.BaseRepository<Award>().AllAsync(), "Id", "Id", dog.AwardId);
//            ViewData["BreedId"] = new SelectList(await _uow.BaseRepository<Breed>().AllAsync(), "Id", "Id", dog.BreedId);
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
            
//            ViewData["AppUserId"] = new SelectList(await _uow.BaseRepository<AppUser>().AllAsync(), "Id", "Id", dog.AppUserId);
//            ViewData["AwardId"] = new SelectList(await _uow.BaseRepository<Award>().AllAsync(), "Id", "Id", dog.AwardId);
//            ViewData["BreedId"] = new SelectList(await _uow.BaseRepository<Breed>().AllAsync(), "Id", "Id", dog.BreedId);
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
