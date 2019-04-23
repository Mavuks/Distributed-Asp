using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Contracts.DAL.App;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain;
using Domain.Identity;
using Identity;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolingsController : ControllerBase
    {
        
        private readonly IAppBLL _bll;

        public SchoolingsController(IAppBLL bll)
        {
            
            _bll = bll;
        }

        // GET: api/Schoolings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Schooling>>> GetSchoolings()
        {
            return await _bll.Schooling.AllForUserAsync(User.GetUserId());
        }

        // GET: api/Schoolings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Schooling>> GetSchooling(int id)
        {
            var schooling = await _bll.Schooling.FindAsync(id);

            if (schooling == null)
            {
                return NotFound();
            }

            return schooling;
        }

        // PUT: api/Schoolings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSchooling(int id, Schooling schooling)
        {
            if (id != schooling.Id)
            {
                return BadRequest();
            }

            _bll.Schooling.Update(schooling);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Schoolings
        [HttpPost]
        public async Task<ActionResult<Schooling>> PostSchooling(Schooling schooling)
        {
            await _bll.Schooling.AddAsync(schooling);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetSchooling", new { id = schooling.Id }, schooling);
        }

        // DELETE: api/Schoolings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Schooling>> DeleteSchooling(int id)
        {
            var schooling = await _bll.Schooling.FindAsync(id);
            if (schooling == null)
            {
                return NotFound();
            }

            _bll.Schooling.Remove(schooling);
            await _bll.SaveChangesAsync();

            return schooling;
        }

    }
}
