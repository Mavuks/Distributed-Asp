using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App;
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
       
        private readonly IAppUnitOfWork _uow;

        public DogsController( IAppUnitOfWork uow)
        {
            _uow = uow;
            
        }

        // GET: api/Dogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dog>>> GetDogs()
        {
            var dogs = await _uow.Dog.AllAsync();
            return new ActionResult<IEnumerable<Dog>>(dogs);
        }

        // GET: api/Dogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dog>> GetDog(int id)
        {
            var dog = await _uow.Dog.FindAsync(id);

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

            _uow.Dog.Update(dog);
            await _uow.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Dogs
        [HttpPost]
        public async Task<ActionResult<Dog>> PostDog(Dog dog)
        {
            await _uow.Dog.AddAsync(dog);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetDog", new { id = dog.Id }, dog);
        }

        // DELETE: api/Dogs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Dog>> DeleteDog(int id)
        {
            var dog = await _uow.Dog.FindAsync(id);
            if (dog == null)
            {
                return NotFound();
            }

            _uow.Dog.Remove(dog);
            await _uow.SaveChangesAsync();

            return dog;
        }
        
    }
}
