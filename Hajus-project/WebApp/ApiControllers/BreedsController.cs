using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.Mappers;
using Contracts.BLL.App;
using Contracts.DAL.App;
using DAL.App.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Breed = DAL.App.DTO.Breed;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
 
    public class BreedsController : ControllerBase
    {
        
        
        private readonly IAppBLL _bll;

        public BreedsController( IAppBLL bll)
        {
            
            _bll = bll;
        }

        // GET: api/Breeds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BreedWithDogCounts>>> GetBreeds()
        {

            return (await _bll.Breed.GetAllWithBreedCountAsync())
                .Select(e => BreedMapper.MapFromExternal(e)).ToList();
        }

        // GET: api/Breeds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Breed>> GetBreed(int id)
        {
            var breed = BreedMapper.MapFromExternal(await _bll.Breed.FindAsync(id));

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

            _bll.Breed.Update(BreedMapper.MapFromExternal(breed));
            await _bll.SaveChangesAsync();

            

            return NoContent();
        }

        // POST: api/Breeds
        [HttpPost]
        public async Task<ActionResult<Breed>> PostBreed(Breed breed)
        {
            await _bll.Breed.AddAsync(BreedMapper.MapFromExternal(breed));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetBreed", new { id = breed.Id }, breed);
        }

        // DELETE: api/Breeds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Breed>> DeleteBreed(int id)
        {
            var breed = await _bll.Breed.FindAsync(id);
            if (breed == null)
            {
                return NotFound();
            }

            _bll.Breed.Remove(breed);
            await _bll.SaveChangesAsync();

            return breed;
        }

       
    }
}
