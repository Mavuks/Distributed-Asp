using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Domain;
using ee.itcollege.mavuks.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ApiControllers.v1_0
{
    [ApiVersion( "1.0" )]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class DogsController : ControllerBase
    {
       
        
        private readonly IAppBLL _bll;

        public DogsController(IAppBLL bll)
        {
            
            _bll = bll;
        }

        /// <summary>
        /// Get all Dog Objects.
        /// </summary>
        /// <returns></returns>
        // GET: api/Dogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.Dog>>> GetDogs()
        {
            return (await _bll.Dog.AllForUserAsync(User.GetUserId()))
                .Select(e => PublicApi.v1.Mappers.DogMapper.MapFromInternal(e)).ToList();
        }

        
        /// <summary>
        /// Get all dog Objects by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Dogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.Dog>> GetDog(int id)
        {
            var dog = PublicApi.v1.Mappers.DogMapper.MapFromInternal(await _bll.Dog.FindForUserAsync(id, User.GetUserId()));

            if (dog == null)
            {
                return NotFound();
            }

            dog.Registrations = (await _bll.Registration.AllForDogRegisAsync(dog.Id))
                .Select(e => PublicApi.v1.Mappers.RegistrationMapper.MapFromInternal(e))
                .ToList();

            return dog;
        }

        
        /// <summary>
        /// Pug Dog objects by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dog"></param>
        /// <returns></returns>
        // PUT: api/Dogs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDog(int id, PublicApi.v1.DTO.Dog dog)
        {
            if (id != dog.Id)
            {
                return BadRequest();
            }

            dog.AppUserId = User.GetUserId();
            
            // check, that the Person being used is really belongs to logged in user
            if (!await _bll.Dog.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }
            
            
            
            _bll.Dog.Update(PublicApi.v1.Mappers.DogMapper.MapFromExternal(dog));
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        
        /// <summary>
        /// Post dog objects.
        /// </summary>
        /// <param name="dog"></param>
        /// <returns></returns>
        // POST: api/Dogs
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.Dog>> PostDog(PublicApi.v1.DTO.Dog dog)
        {
            if (!await _bll.Dog.BelongsToUserAsync(dog.Id, User.GetUserId()))
            {
                return NotFound();
            }
            
            
            dog = PublicApi.v1.Mappers.DogMapper.MapFromInternal(
                _bll.Dog.Add(PublicApi.v1.Mappers.DogMapper.MapFromExternal(dog)));
            
            await _bll.Dog.AddAsync(PublicApi.v1.Mappers.DogMapper.MapFromExternal(dog));
            await _bll.SaveChangesAsync();
            
            dog = PublicApi.v1.Mappers.DogMapper.MapFromInternal(
                _bll.Dog.GetUpdatesAfterUOWSaveChanges(
                    PublicApi.v1.Mappers.DogMapper.MapFromExternal(dog)));

            return CreatedAtAction("GetDog", new 
            {
                version = HttpContext.GetRequestedApiVersion().ToString(),
                id = dog.Id
            }, dog);;
        }

        
        /// <summary>
        /// Delete dog object by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/Dogs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Dog>> DeleteDog(int id)
        {
           
            if (!await _bll.Dog.BelongsToUserAsync(id, User.GetUserId()))
            {
                return NotFound();
            }

            _bll.Dog.Remove(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }
        
    }
}
