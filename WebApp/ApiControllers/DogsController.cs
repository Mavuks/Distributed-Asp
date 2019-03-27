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
    public class DogsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DogsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Dogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dog>>> GetDogs()
        {
            return await _context.Dogs.ToListAsync();
        }

        // GET: api/Dogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dog>> GetDog(int id)
        {
            var dog = await _context.Dogs.FindAsync(id);

            if (dog == null)
            {
                return NotFound();
            }

            return dog;
        }

        // PUT: api/Dogs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDog(int id, Dog dog)
        {
            if (id != dog.Id)
            {
                return BadRequest();
            }

            _context.Entry(dog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DogExists(id))
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

        // POST: api/Dogs
        [HttpPost]
        public async Task<ActionResult<Dog>> PostDog(Dog dog)
        {
            _context.Dogs.Add(dog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDog", new { id = dog.Id }, dog);
        }

        // DELETE: api/Dogs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Dog>> DeleteDog(int id)
        {
            var dog = await _context.Dogs.FindAsync(id);
            if (dog == null)
            {
                return NotFound();
            }

            _context.Dogs.Remove(dog);
            await _context.SaveChangesAsync();

            return dog;
        }

        private bool DogExists(int id)
        {
            return _context.Dogs.Any(e => e.Id == id);
        }
    }
}
