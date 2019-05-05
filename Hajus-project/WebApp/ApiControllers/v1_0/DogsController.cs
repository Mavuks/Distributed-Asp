using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Domain;
using Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ApiControllers.v1_0
{
    [ApiVersion( "1.0" )]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class DogsController : ControllerBase
    {
       
        
        private readonly IAppBLL _bll;

        public DogsController(IAppBLL bll)
        {
            
            _bll = bll;
        }

        // GET: api/Dogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.Dog>>> GetDogs()
        {
            return (await _bll.Dog.AllForUserAsync(User.GetUserId()))
                .Select(e => PublicApi.v1.Mappers.DogMapper.MapFromInternal(e)).ToList();
        }

        // GET: api/Dogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.Dog>> GetDog(int id)
        {
            var dog = PublicApi.v1.Mappers.DogMapper.MapFromInternal(await _bll.Dog.FindAsync(id));

            if (dog == null)
            {
                return NotFound();
            }

            return dog;
        }

        // PUT: api/Dogs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDog(int id, PublicApi.v1.DTO.Dog dog)
        {
            if (id != dog.Id)
            {
                return BadRequest();
            }

            _bll.Dog.Update(PublicApi.v1.Mappers.DogMapper.MapFromExternal(dog));
            
            
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Dogs
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.Dog>> PostDog(PublicApi.v1.DTO.Dog dog)
        {
            await _bll.Dog.AddAsync(PublicApi.v1.Mappers.DogMapper.MapFromExternal(dog));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetDog", new { id = dog.Id }, dog);
        }

        // DELETE: api/Dogs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Dog>> DeleteDog(int id)
        {
            var dog = await _bll.Dog.FindAsync(id);
            if (dog == null)
            {
                return NotFound();
            }

            _bll.Dog.Remove(dog);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
        
    }
}