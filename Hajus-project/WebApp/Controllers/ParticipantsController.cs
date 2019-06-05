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

namespace WebApp.Controllers
{
    public class ParticipantsController : Controller
    {
        
        
        private readonly IAppBLL _bll;

        public ParticipantsController(IAppBLL bll)
        {
            
            _bll = bll;
        }

        // GET: Participants
        public async Task<IActionResult> Index()
        {
            return View(await _bll.Participant.AllForUserAsync(User.GetUserId()));
        }

        // GET: Participants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participant = await _bll.Participant.FindAsync(id);
            if (participant == null)
            {
                return NotFound();
            }

            return View(participant);
        }

        // GET: Participants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Participants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Id")]  BLL.App.DTO.Participant participant)
        {
            if (ModelState.IsValid)
            {
                await _bll.Participant.AddAsync(participant);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(participant);
        }

        // GET: Participants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participant = await _bll.Participant.FindAsync(id);
            if (participant == null)
            {
                return NotFound();
            }
            return View(participant);
        }

        // POST: Participants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FirstName,LastName,Id")]  BLL.App.DTO.Participant participant)
        {
            if (id != participant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _bll.Participant.Update(participant);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(participant);
        }

        // GET: Participants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participant = await _bll.Participant.FindAsync(id.Value);
            if (participant == null)
            {
                return NotFound();
            }

            return View(participant);
        }

        // POST: Participants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            _bll.Participant.Remove(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
