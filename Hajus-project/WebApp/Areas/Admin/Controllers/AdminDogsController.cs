using System.Threading.Tasks;
using Contracts.BLL.App;
using Domain;
using ee.itcollege.mavuks.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.ViewModels;

namespace WebApp.Areas.Admin.Controllers
{ 
    [Area("Admin")]
    public class AdminDogsController : Controller
    {
        
        private readonly IAppBLL _bll;

        public AdminDogsController(IAppBLL bll)
        {
            
            _bll = bll;
        }

        // GET: Dogs
        public async Task<IActionResult> Index()
        {

            var dogs = await _bll.Dog.AllAsync();
            return View(dogs);
        }

        // GET: Dogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dog = await _bll.Dog.FindAsync(id);
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
                BreedSelectList = new SelectList(await _bll.Breed.AllAsync(), nameof(Breed.Id), nameof(Breed.BreedName))
                
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
                await _bll.Dog.AddAsync(vm.Dog);
                await _bll.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }

          vm.BreedSelectList  = new SelectList(await _bll.Breed.AllAsync(),
              nameof( BLL.App.DTO.Breed.Id),
                nameof( BLL.App.DTO.Breed.BreedName), vm.Dog.BreedId );


            
            return View(vm);
        }
        
        
        // GET: Dogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dog = await _bll.Dog.FindAsync((int)id);
            if (dog == null)
            {
                return NotFound();
            }
            
            var vm = new DogCreateViewModel()
            {
                Dog = dog,
            
             BreedSelectList = new SelectList(await _bll.Breed.AllAsync(),
                 nameof( BLL.App.DTO.Breed.Id),
                 nameof( BLL.App.DTO.Breed.BreedName),
                 dog.BreedId)
                
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
                _bll.Dog.Update(vm.Dog);
                await _bll.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }
            
             vm.BreedSelectList  = new SelectList(await _bll.Breed.AllAsync(), 
             nameof( BLL.App.DTO.Breed.Id),
                nameof( BLL.App.DTO.Breed.BreedName),
                vm.Dog.BreedId );

            return View(vm);
        }

        // GET: Dogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dog = await _bll.Dog.FindAsync(id);
                
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
            _bll.Dog.Remove(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

       
    }
}
