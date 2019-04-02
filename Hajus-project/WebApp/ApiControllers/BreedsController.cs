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
    public class BreedsController : ControllerBase
    {
        
        private readonly IAppUnitOfWork _uow;

        public BreedsController(IAppUnitOfWork uow)
        {
            
            _uow = uow;
        }

        // GET: api/Breeds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Breed>>> GetBreeds()
        {
            var breeds = await _uow.Breed.AllAsync();
            return new ActionResult<IEnumerable<Breed>>(breeds);
        }

        // GET: api/Breeds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Breed>> GetBreed(int id)
        {
            var breed = await _uow.Breed.FindAsync(id);

            if (breed == null)
            {
                return NotFound();
            }

            return breed;
        }

        // PUT: api/Breeds/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBreed(int id, Breed breed)
        {
            if (id != breed.Id)
            {
                return BadRequest();
            }

            _uow.Breed.Update(breed);
            await _uow.SaveChangesAsync();

            

            return NoContent();
        }

        // POST: api/Breeds
        [HttpPost]
        public async Task<ActionResult<Breed>> PostBreed(Breed breed)
        {
            _uow.Breed.AddAsync(breed);
            await _uow.SaveChangesAsync();

            return CreatedAtAction("GetBreed", new { id = breed.Id }, breed);
        }

        // DELETE: api/Breeds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Breed>> DeleteBreed(int id)
        {
            var breed = await _uow.Breed.FindAsync(id);
            if (breed == null)
            {
                return NotFound();
            }

            _uow.Breed.Remove(breed);
            await _uow.SaveChangesAsync();

            return breed;
        }

       
    }
}
