using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace WebApp.Controllers
{
    public class SchoolingsController : Controller
    {
        private readonly AppDbContext _context;

        public SchoolingsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Schoolings
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Schoolings.Include(s => s.Dog).Include(s => s.Material);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Schoolings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schooling = await _context.Schoolings
                .Include(s => s.Dog)
                .Include(s => s.Material)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schooling == null)
            {
                return NotFound();
            }

            return View(schooling);
        }

        // GET: Schoolings/Create
        public IActionResult Create()
        {
            ViewData["DogId"] = new SelectList(_context.Dogs, "Id", "DogName");
            ViewData["MaterialId"] = new SelectList(_context.Materials, "Id", "Id");
            return View();
        }

        // POST: Schoolings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SchoolingName,Start,End,MaterialId,DogId,Id")] Schooling schooling)
        {
            if (ModelState.IsValid)
            {
                _context.Add(schooling);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DogId"] = new SelectList(_context.Dogs, "Id", "DogName", schooling.DogId);
            ViewData["MaterialId"] = new SelectList(_context.Materials, "Id", "Id", schooling.MaterialId);
            return View(schooling);
        }

        // GET: Schoolings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schooling = await _context.Schoolings.FindAsync(id);
            if (schooling == null)
            {
                return NotFound();
            }
            ViewData["DogId"] = new SelectList(_context.Dogs, "Id", "DogName", schooling.DogId);
            ViewData["MaterialId"] = new SelectList(_context.Materials, "Id", "Id", schooling.MaterialId);
            return View(schooling);
        }

        // POST: Schoolings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SchoolingName,Start,End,MaterialId,DogId,Id")] Schooling schooling)
        {
            if (id != schooling.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(schooling);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SchoolingExists(schooling.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DogId"] = new SelectList(_context.Dogs, "Id", "DogName", schooling.DogId);
            ViewData["MaterialId"] = new SelectList(_context.Materials, "Id", "Id", schooling.MaterialId);
            return View(schooling);
        }

        // GET: Schoolings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schooling = await _context.Schoolings
                .Include(s => s.Dog)
                .Include(s => s.Material)
                .FirstOrDefaultAsync(m => m.Id == id);
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
            var schooling = await _context.Schoolings.FindAsync(id);
            _context.Schoolings.Remove(schooling);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SchoolingExists(int id)
        {
            return _context.Schoolings.Any(e => e.Id == id);
        }
    }
}
