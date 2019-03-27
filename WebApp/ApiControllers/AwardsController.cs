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
    public class AwardsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AwardsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Awards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Award>>> GetAwards()
        {
            return await _context.Awards.ToListAsync();
        }

        // GET: api/Awards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Award>> GetAward(int id)
        {
            var award = await _context.Awards.FindAsync(id);

            if (award == null)
            {
                return NotFound();
            }

            return award;
        }

        // PUT: api/Awards/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAward(int id, Award award)
        {
            if (id != award.Id)
            {
                return BadRequest();
            }

            _context.Entry(award).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AwardExists(id))
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

        // POST: api/Awards
        [HttpPost]
        public async Task<ActionResult<Award>> PostAward(Award award)
        {
            _context.Awards.Add(award);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAward", new { id = award.Id }, award);
        }

        // DELETE: api/Awards/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Award>> DeleteAward(int id)
        {
            var award = await _context.Awards.FindAsync(id);
            if (award == null)
            {
                return NotFound();
            }

            _context.Awards.Remove(award);
            await _context.SaveChangesAsync();

            return award;
        }

        private bool AwardExists(int id)
        {
            return _context.Awards.Any(e => e.Id == id);
        }
    }
}
