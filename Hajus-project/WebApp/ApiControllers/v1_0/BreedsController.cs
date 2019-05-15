using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Microsoft.AspNetCore.Mvc;
using PublicApi.v1.Mappers;

namespace WebApp.ApiControllers.v1_0
{
    [ApiVersion( "1.0" )]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
 
    public class BreedsController : ControllerBase
    {
        
        
        private readonly IAppBLL _bll;

        public BreedsController( IAppBLL bll)
        {
            
            _bll = bll;
        }

        
        /// <summary>
        /// Get all Breed Objects
        /// </summary>
        /// <returns>Array of all Breed With counts </returns>
        // GET: api/Breeds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.BreedWithDogCounts>>> GetBreeds()
        {

            return (await _bll.Breed.GetAllWithBreedCountAsync())
                .Select(e => PublicApi.v1.Mappers.BreedMapper.MapFromInternal(e)).ToList();
        }

        
        /// <summary>
        /// Get all Breed objects by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Breeds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.Breed>> GetBreed(int id)
        {
            var breed = PublicApi.v1.Mappers.BreedMapper.MapFromInternal(await _bll.Breed.FindAsync(id));

            if (breed == null)
            {
                return NotFound();
            }

            return breed;
        }
        
        
        /// <summary>
        /// Put all breed objects
        /// </summary>
        /// <param name="id"></param>
        /// <param name="breed"></param>
        /// <returns></returns>
        // PUT: api/Breeds/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBreed(int id, PublicApi.v1.DTO.Breed breed)
        {
            if (id != breed.Id)
            {
                return BadRequest();
            }

            _bll.Breed.Update(PublicApi.v1.Mappers.BreedMapper.MapFromExternal(breed));
            await _bll.SaveChangesAsync();

            

            return NoContent();
        }
        /// <summary>
        /// Post all breed objects
        /// </summary>
        /// <param name="breed"></param>
        /// <returns></returns>
        // POST: api/Breeds
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.Breed>> PostBreed(PublicApi.v1.DTO.Breed breed)
        {
            
            breed = PublicApi.v1.Mappers.BreedMapper.MapFromInternal(
                await _bll.Breed.AddAsync(PublicApi.v1.Mappers.BreedMapper.MapFromExternal(breed)));
            
            
            //await _bll.Breed.AddAsync(BreedMapper.MapFromExternal(breed));
            await _bll.SaveChangesAsync();

            breed = PublicApi.v1.Mappers.BreedMapper.MapFromInternal(
                _bll.Breed.GetUpdatesAfterUOWSaveChanges(
                    PublicApi.v1.Mappers.BreedMapper.MapFromExternal(breed)));
            
            
            
            return CreatedAtAction(
                nameof(GetBreed), new
                {
                    version = HttpContext.GetRequestedApiVersion().ToString(),
                    id = breed.Id
                }, breed);
        }
        
        /// <summary>
        /// Delete all breed objects
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/Breeds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.Breed>> DeleteBreed(int id)
        {
            var breed = await _bll.Breed.FindAsync(id);
            if (breed == null)
            {
                return NotFound();
            }

            _bll.Breed.Remove(breed);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

       
    }
}
