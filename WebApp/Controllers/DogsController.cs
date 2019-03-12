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
        public IActionResult Create()
        {
            
            return View();
        }

        // POST: Dogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DogName,DateOfBirth,DateOfDeath,Sex,BreedId,Owner,AppUserId,AwardId,Id")] Dog dog)
        {
            dog.AppUserId = User.GetUserId();
            
            if (ModelState.IsValid)
            {
                await _uow.Dog.AddAsync(dog);
                await _uow.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }
            
            return View(dog);
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
            ViewData["AppUserId"] = new SelectList(await _uow.BaseRepository<AppUser>().AllAsync(), "Id", "Id", dog.AppUserId);
            ViewData["AwardId"] = new SelectList(await _uow.BaseRepository<Award>().AllAsync(), "Id", "Id", dog.AwardId);
            ViewData["BreedId"] = new SelectList(await _uow.BaseRepository<Breed>().AllAsync(), "Id", "Id", dog.BreedId);
            return View(dog);
        }

        // POST: Dogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DogName,DateOfBirth,DateOfDeath,Sex,BreedId,Owner,AppUserId,AwardId,Id")] Dog dog)
        {
            if (id != dog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.Dog.Update(dog);
                await _uow.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }
            ViewData["AppUserId"] = new SelectList(await _uow.BaseRepository<AppUser>().AllAsync(), "Id", "Id", dog.AppUserId);
            ViewData["AwardId"] = new SelectList(await _uow.BaseRepository<Award>().AllAsync(), "Id", "Id", dog.AwardId);
            ViewData["BreedId"] = new SelectList(await _uow.BaseRepository<Breed>().AllAsync(), "Id", "Id", dog.BreedId);
            return View(dog);
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
