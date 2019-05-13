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
using DAL.App.EF.Repositories;
using Domain;
using ee.itcollege.mavuks.Identity;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class SchoolingsController : Controller
    {
        

        
        private readonly IAppBLL _bll;

        public SchoolingsController(IAppBLL bll)
        {
            _bll = bll;
            
        }

        // GET: Schoolings
        public async Task<IActionResult> Index()
        {
        
            return View(await _bll.Schooling.AllForUserAsync(User.GetUserId()));
        }

        // GET: Schoolings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schooling = await _bll.Schooling.FindAsync(id);
            if (schooling == null)
            {
                return NotFound();
            }

            return View(schooling);
        }

        // GET: Schoolings/Create
        public async Task<IActionResult> Create()
        {

            var vm = new SchoolingCreateViewModel()
            {
              
                MaterialSelectList = new SelectList(await _bll.Material.AllAsync(),nameof( BLL.App.DTO.Material.Id), nameof( BLL.App.DTO.Material.MaterialName) )

            };

            return View(vm);
        }

        // POST: Schoolings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SchoolingCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _bll.Schooling.AddAsync(vm.Schooling);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

           
            vm.MaterialSelectList = new SelectList(await _bll.Material.AllAsync(), nameof( BLL.App.DTO.Material.Id),
                nameof( BLL.App.DTO.Material.MaterialName), vm.Schooling.MaterialId);

            return View(vm);
        }

        // GET: Schoolings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schooling = await _bll.Schooling.FindAsync(id);
            if (schooling == null)
            {
                return NotFound();
            }
            
            var vm = new SchoolingCreateViewModel()
            {
                Schooling = schooling,
             MaterialSelectList = new SelectList(await _bll.Material.AllAsync(),nameof(Material.Id), nameof(Material.MaterialName), schooling.MaterialId)

            };

            return View(vm);
        }

        // POST: Schoolings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SchoolingCreateViewModel vm)
        {
            if (id != vm.Schooling.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _bll.Schooling.Update(vm.Schooling);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            
           
            vm.MaterialSelectList = new SelectList(await _bll.Material.AllAsync(), nameof(Material.Id),
                nameof(Material.MaterialName), vm.Schooling.MaterialId);


            return View(vm);
        }

        // GET: Schoolings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schooling = await _bll.Schooling.FindAsync(id);
            if (schooling == null)
            {
                return NotFound();
            }

            return View(schooling);
        }

        // POST: Schoolings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _bll.Schooling.Remove(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

       
    }
}
