using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Domain;
using ee.itcollege.mavuks.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ApiControllers.v1_0
{
    [ApiVersion( "1.0" )]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class RegistrationsController : ControllerBase
    {
        
        private readonly IAppBLL _bll;

        public RegistrationsController( IAppBLL bll)
        {
            
            _bll = bll;
        }
        
        
        /// <summary>
        /// Get Registrations objects.
        /// </summary>
        /// <returns></returns>
        // GET: api/Registrations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicApi.v1.DTO.Registration>>> GetRegistrations()
        {
            return (await _bll.Registration.AllForUserAsync(User.GetUserId()))
                .Select(e => PublicApi.v1.Mappers.RegistrationMapper.MapFromInternal(e)).ToList();
        }

        
        /// <summary>
        /// Get Registrations objects by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Registrations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublicApi.v1.DTO.Registration>> GetRegistration(int id)
        {
            var registration = PublicApi.v1.Mappers.RegistrationMapper.MapFromInternal(
                await _bll.Registration.FindAsync(id));

            if (registration == null)
            {
                return NotFound();
            }

            return registration;
        }

        
        /// <summary>
        /// Put Registrations objects by id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="registration"></param>
        /// <returns></returns>
        // PUT: api/Registrations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegistration(int id, PublicApi.v1.DTO.Registration registration)
        {
            if (id != registration.Id)
            {
                return BadRequest();
            }

            _bll.Registration.Update(PublicApi.v1.Mappers.RegistrationMapper.MapFromExternal(registration));
            await _bll.SaveChangesAsync();
            
            return NoContent();
        }

        
        
        /// <summary>
        /// Post Registrations.
        /// </summary>
        /// <param name="registration"></param>
        /// <returns></returns>
        // POST: api/Registrations
        [HttpPost]
        public async Task<ActionResult<PublicApi.v1.DTO.Registration>> PostRegistration(PublicApi.v1.DTO.Registration registration)
        {
            await _bll.Registration.AddAsync(PublicApi.v1.Mappers.RegistrationMapper.MapFromExternal(registration));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetRegistration", new { id = registration.Id }, registration);
        }

        
        
        /// <summary>
        /// Delete registrations objects by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/Registrations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Registration>> DeleteRegistration(int id)
        {
            var registration = await _bll.Registration.FindAsync(id);
            if (registration == null)
            {
                return NotFound();
            }

            _bll.Registration.Remove(registration);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

    }
}
