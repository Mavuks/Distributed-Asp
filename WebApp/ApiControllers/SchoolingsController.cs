using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolingsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SchoolingsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Schoolings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Schooling>>> GetSchoolings()
        {
            return await _context.Schoolings.ToListAsync();
        }

        // GET: api/Schoolings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Schooling>> GetSchooling(int id)
        {
            var schooling = await _context.Schoolings.FindAsync(id);

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

            _context.Entry(schooling).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SchoolingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Schoolings
        [HttpPost]
        public async Task<ActionResult<Schooling>> PostSchooling(Schooling schooling)
        {
            _context.Schoolings.Add(schooling);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSchooling", new { id = schooling.Id }, schooling);
        }

        // DELETE: api/Schoolings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Schooling>> DeleteSchooling(int id)
        {
            var schooling = await _context.Schoolings.FindAsync(id);
            if (schooling == null)
            {
                return NotFound();
            }

            _context.Schoolings.Remove(schooling);
            await _context.SaveChangesAsync();

            return schooling;
        }

        private bool SchoolingExists(int id)
        {
            return _context.Schoolings.Any(e => e.Id == id);
        }
    }
}
