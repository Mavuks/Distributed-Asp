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
    public class ShowsController : Controller
    {
        

        
        private readonly IAppBLL _bll;

        public ShowsController(IAppBLL bll)
        {
            
            _bll = bll;
        }

        // GET: Shows
        public async Task<IActionResult> Index()
        {
            //var appDbContext = _context.Shows.Include(s => s.Dog).Include(s => s.Location).Include(s => s.Participant);
            return View(await _bll.Show.AllAsync());
        }

        // GET: Shows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var show = await _bll.Show.FindAsync(id.Value);
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
               LocationSelectList = new SelectList(await _bll.Location.AllAsync(),
                   nameof( BLL.App.DTO.Location.Id),
                   nameof(Location.Locations)),
//                ParticipantSelectList = new SelectList(await _bll.Participant.AllAsync(),
//                    nameof( BLL.App.DTO.Participant.Id),
//                    nameof(Participant.FirstName))
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
                await _bll.Show.AddAsync(vm.Show);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            vm.LocationSelectList = new SelectList(await _bll.Location.AllAsync(),
                nameof( BLL.App.DTO.Location.Id),
                nameof( BLL.App.DTO.Location.Locations), vm.Show.LocationId);
           
            
            return View(vm);
        }

        // GET: Shows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var show = await _bll.Show.FindAsync(id.Value);
            if (show == null)
            {
                return NotFound();
            }
            
            var vm = new ShowCreateViewModel()
            {
                Show = show,
              LocationSelectList = new SelectList(await _bll.Location.AllAsync(),nameof(Location.Id), nameof(Location.Locations), show.LocationId),
               
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
                _bll.Show.Update(vm.Show);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            vm.LocationSelectList = new SelectList(await _bll.Location.AllAsync(), nameof(Location.Id),
                nameof(Location.Locations), vm.Show.LocationId);
         

            return View(vm);
        }

        // GET: Shows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var show = await _bll.Show.FindAsync(id);
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
            
            _bll.Show.Remove(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

       
    }
}
